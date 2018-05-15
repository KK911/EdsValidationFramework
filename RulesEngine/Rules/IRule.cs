using System;
using System.Collections.Generic;

namespace RulesEngine.Rules
{
    public interface IRule<T>
        where T : class, new()
    {
        T Model { get; set; }
        void Initialize();
        void BeforeApply();
        IRuleResult Apply();
        void AfterApply();
        Exception UnhandledException { get; set; }
        IRuleConfiguration<T> Configuration { get; set; }

        bool HasNestedRules { get; }
        IList<IRule<T>> GetNestedRules();
        void AddNestedRules(params IRule<T>[] nestedRules);
    }
}