using ValidationDesign.Entities;

namespace ValidationDesign.Validation.ValidationRules
{
    public class EmployeeSalaryRangeValidationRule : RangeValidationRule<Employee, int>
    {
        protected override string Actual { get; set; }
        protected override string FieldName => "Salary";
        protected override int MinValue => 75000;
        protected override int MaxValue => 250000;
        protected override bool IsValueInRange(Employee employee)
        {
            Actual = $"Actual value received was: {employee.Salary}";
            return employee.Salary >= MinValue && employee.Salary <= MaxValue;
        }
    }
}