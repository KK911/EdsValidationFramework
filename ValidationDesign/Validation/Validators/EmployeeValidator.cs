using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidationDesign.Extensions;
using ValidationDesign.Validation.ValidationRules;

namespace ValidationDesign.Validation.Validators
{
    public class EmployeeValidator : IValidator<Employee>
    {
        public IList<IValidationRule<Employee>> ValidationRules => new List<IValidationRule<Employee>>
        {
            new EmployeeNumberRequiredValidationRule(),
            new EmployeeSalaryRangeValidationRule(),
            new GenericRequiredFieldValidationRule(nameof(Employee.Dob), typeof(DateTime)),
            new EmployeeCustomValidationRule()
        };

        public IValidationSummary Validate(Employee employee)
        {
            var summary = new ValidationSummary { AllowRecordImport = true };
            var errors = new ConcurrentBag<ValidationError>();

            Parallel.ForEach(ValidationRules, rule =>
            {
                var validationResult = rule.Apply(employee);
                if (!validationResult.IsSuccess)
                    summary.AllowRecordImport = false;
                errors.AddRange(validationResult.Errors);
            });
            summary.ErrorSummary.AddRange(errors);
            return summary;
        }
    }
}
