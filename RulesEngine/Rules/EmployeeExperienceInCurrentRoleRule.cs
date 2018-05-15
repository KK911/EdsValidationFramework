using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class EmployeeExperienceInCurrentRoleRule : Rule<Employee>
    {
        public override IRuleResult Apply() => new RuleResult { Result = Model.NumYearsInCurrentRole >= 2 };
    }
}
