using RulesEngine.Models;
using System;
using System.Collections.Generic;

namespace RulesEngine.Rules
{
    public abstract class Rule<T> : IRule<T> where T : class, new()
    {
        private readonly List<IRule<T>> _rules = new List<IRule<T>>();

        public T Model { get; set; }
        public IRuleConfiguration<T> Configuration { get; set; } = new RuleConfiguration<T>();
        public Exception UnhandledException { get; set; }

        public virtual void Initialize() { }
        public virtual void BeforeApply() { }
        public abstract IRuleResult Apply();
        public virtual void AfterApply() { }

        public IList<IRule<T>> GetNestedRules() => _rules;
        public void AddNestedRules(params IRule<T>[] nestedRules) => _rules.AddRange(nestedRules);

        public bool HasNestedRules => _rules.Count > 0;
    }
}