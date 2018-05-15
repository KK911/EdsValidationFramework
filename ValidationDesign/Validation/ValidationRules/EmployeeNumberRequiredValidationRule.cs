using ValidationDesign.Entities;

namespace ValidationDesign.Validation.ValidationRules
{
    public class EmployeeNumberRequiredValidationRule : RequiredFieldValidationRule<Employee>
    {
        protected override string Actual { get; set; }
        protected override string FieldName => "EmployeeNumber";

        protected override bool FieldExists(Employee employee)
        {
            Actual = $"Actual value received was: {employee.EmployeeNumber}";
            return !string.IsNullOrWhiteSpace(employee.EmployeeNumber);
        }
    }
}