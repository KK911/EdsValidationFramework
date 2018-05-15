using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class EmployeeBonusEligibilityRule : Rule<Employee>
    {
        public override void Initialize()
        {
            AddNestedRules(new EmployeeConsistentPerformerRule(), new EmployeeExperienceInCurrentRoleRule());
        }

        public override IRuleResult Apply()
        {
            return null;
        }
    }
}
