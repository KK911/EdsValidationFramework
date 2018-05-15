using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class EmployeeNumberRequiredFieldRule : RequiredFieldRule<Employee>
    {
        protected override bool FieldExists(Employee employee)
        {
            return !string.IsNullOrWhiteSpace(employee.EmployeeNumber);
        }
    }
}