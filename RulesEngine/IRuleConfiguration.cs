using System;

namespace RulesEngine
{
    public interface IRuleConfiguration<T>
    {
        /// <summary>
        /// A constraint that determines the model being evaluated meets the requirements of this rule.
        /// </summary>
        Predicate<T> Constraint { get; set; }

        /// <summary>
        /// Execution order of the rule.
        /// </summary>
        int? ExecutionOrder { get; set; }

        /// <summary>
        /// Skip execution of this rule.
        /// </summary>
        bool Skip { get; set; }

        /// <summary>
        /// Apply nested rules first before applying parent rule.
        /// </summary>
        bool ApplyNestedRulesFirst { get; set; }

        /// <summary>
        /// When set to true, all nested rules will use the same constraint as that of parent rule.
        /// </summary>
        bool NestedRulesInheritConstraint { get; set; }
    }
}