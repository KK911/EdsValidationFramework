using RulesEngine.Models;

namespace RulesEngine.Rules
{
    public class EmployeeSalaryRangeRule : RangeRule<Employee, int>
    {
        protected override int MinValue => 75000;
        protected override int MaxValue => 150000;
        protected override bool IsValueInRange(Employee entity)
        {
            return entity.Salary >= MinValue && entity.Salary <= MaxValue;
        }
    }
}