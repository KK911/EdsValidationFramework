using System;

namespace RulesEngine.Models
{
    public class RuleConfiguration<T> : IRuleConfiguration<T>
    {
        public Predicate<T> Constraint { get; set; }
        public int? ExecutionOrder { get; set; }
        public bool Skip { get; set; }
        public bool ApplyNestedRulesFirst { get; set; }
        public bool NestedRulesInheritConstraint { get; set; }
    }
}