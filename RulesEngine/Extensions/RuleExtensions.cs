using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.Extensions
{
    public static class RuleExtensions
    {
        public static IList<IRule<T>> GetRulesWithExecutionOrder<T>(this IEnumerable<IRule<T>> rules,
            Func<IRule<T>, bool> condition = null) where T : class, new()
        {
            condition = condition ?? (rule => true);

            return rules.Where(r => r.Configuration.ExecutionOrder.HasValue)
                .Where(condition)
                .OrderBy(r => r.Configuration.ExecutionOrder)
                .ToList();
        }

        public static IList<IRule<T>> GetRulesWithoutExecutionOrder<T>(this IEnumerable<IRule<T>> rules,
            Func<IRule<T>, bool> condition = null) where T : class, new()
        {
            condition = condition ?? (k => true);

            return rules.Where(r => !r.Configuration.ExecutionOrder.HasValue)
                .Where(condition)
                .AsParallel()
                .ToList();
        }

        public static bool CanInvoke<T>(this IRule<T> rule, T model)
            where T : class, new()
        {
            return !rule.Configuration.Skip &&
                   (rule.Configuration.Constraint == null || rule.Configuration.Constraint.Invoke(model));
        }

        public static void AssignRuleName(this IRuleResult ruleResult, string ruleName)
        {
            if (ruleResult != null)
            {
                ruleResult.Name = ruleResult.Name ?? ruleName;
            }
        }
    }
}