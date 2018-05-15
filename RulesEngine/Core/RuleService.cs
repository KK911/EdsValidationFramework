using RulesEngine.Extensions;
using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.Core
{
    internal class RuleService<T>
        where T : class, new()
    {
        private readonly T _model;
        private readonly IList<IRule<T>> _rules;
        private readonly ICollection<IRuleResult> _ruleResults = new List<IRuleResult>();

        public RuleService(T model, IList<IRule<T>> rules)
        {
            _model = model;
            _rules = rules;
        }

        public void Invoke() => Execute(_rules);
        public IRuleResult[] GetRuleResults() => _ruleResults.ToArray();

        private void Execute(IList<IRule<T>> rules)
        {
            InitializeRules(rules);

            foreach (var rule in SortByExecutionOrder(rules))
            {
                ApplyNestedRules(rule.Configuration.ApplyNestedRulesFirst, rule);

                if (!rule.CanInvoke(_model))
                    continue;

                try
                {
                    rule.BeforeApply();
                    var ruleResult = rule.Apply();
                    rule.AfterApply();

                    AddToRuleResults(ruleResult, rule.GetType().Name);
                }
                catch (Exception ex)
                {
                    rule.UnhandledException = ex;
                    // Check if there is a specific error handler for this rule.
                    // If not, call generic error handler.
                }

                ApplyNestedRules(!rule.Configuration.ApplyNestedRulesFirst, rule);
            }
        }

        private void ApplyNestedRules(bool applyNow, IRule<T> rule)
        {
            if (applyNow && rule.HasNestedRules)
            {
                Execute(SortByExecutionOrder(rule.GetNestedRules()));
            }
        }

        private void InitializeRules(IList<IRule<T>> rules, IRule<T> parentRule = null)
        {
            foreach (var rule in rules)
            {
                // We will be doing a lot more here in actual implementation like
                //  resolving dependencies, setting configuration values and such.
                InitializeRule(rule, parentRule);
                if (rule.HasNestedRules)
                    InitializeRules(rule.GetNestedRules(), rule);
            }
        }

        private void InitializeRule(IRule<T> rule, IRule<T> parentRule)
        {
            rule.Model = _model;
            rule.Initialize();

            if (parentRule != null && parentRule.Configuration.NestedRulesInheritConstraint)
            {
                rule.Configuration.Constraint = parentRule.Configuration.Constraint;
                rule.Configuration.NestedRulesInheritConstraint = true;
            }
        }

        private void AddToRuleResults(IRuleResult ruleResult, string ruleName)
        {
            ruleResult.AssignRuleName(ruleName);
            if (ruleResult != null)
                _ruleResults.Add(ruleResult);
        }

        private static IList<IRule<T>> SortByExecutionOrder(IList<IRule<T>> rules)
        {
            return rules.GetRulesWithExecutionOrder()
                .Concat(rules.GetRulesWithoutExecutionOrder())
                .ToList();
        }
    }
}
