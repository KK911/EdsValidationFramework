using System.Collections.Generic;
using RulesEngine.Rules;

namespace RulesEngine.Core
{
    public class RuleEngine<T>
        where T : class, new()
    {
        private readonly T _model;
        private readonly List<IRule<T>> _rules = new List<IRule<T>>();
        private RuleService<T> _ruleService;

        public RuleEngine(T instance)
        {
            _model = instance;
        }

        public void AddRules(params IRule<T>[] rules) => _rules.AddRange(rules);

        public IRuleResult[] Execute()
        {
            _ruleService = new RuleService<T>(_model, _rules);

            _ruleService.Invoke();

            return _ruleService.GetRuleResults();
        }
    }

    public static class RuleEngineExtensions
    {
        public static RuleEngine<T> ApplyRules<T>(this RuleEngine<T> @this, params IRule<T>[] rules)
            where T : class, new()
        {
            @this.AddRules(rules);
            return @this;
        }
    }
}
