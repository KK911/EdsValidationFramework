using System;
using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public abstract class RangeRule<TEntity, TField> : Rule<TEntity>
        where TEntity : class, new()
        where TField: IComparable
    {
        protected abstract TField MinValue { get; }
        protected abstract TField MaxValue { get; }
        protected abstract bool IsValueInRange(TEntity entity);
        public override IRuleResult Apply()
        {
            return new RuleResult { Result = IsValueInRange(Model) };
        }
    }
}