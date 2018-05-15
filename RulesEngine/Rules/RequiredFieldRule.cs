using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public abstract class RequiredFieldRule<T> : Rule<T>
        where T : class, new()
    {
        protected abstract bool FieldExists(T entity);

        public override IRuleResult Apply()
        {
            return new RuleResult {Result = FieldExists(Model)};
        }
    }
}