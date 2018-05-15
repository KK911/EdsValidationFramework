using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class EmployeeConsistentPerformerRule : Rule<Employee>
    {
        public override IRuleResult Apply()
        {
            var result = new RuleResult();
            switch (Model.EmployeeRating)
            {
                case "Exceeds Expectation":
                case "Outstanding":
                    result.Result = true;
                    break;
                case "Underperformer":
                case "Meets Expectation":
                default:
                    result.Result = false;
                    break;
            }

            return result;
        }
    }
}