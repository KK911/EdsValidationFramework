namespace ValidationDesign.Validation.ValidationRules
{
    public class EmployeeCustomValidationRule : IValidationRule<Employee>
    {
        public string Expected => "EmployeeRating can only be one these values: \"Underperformer\", \"Meets Expectation\", \"Exceeds Expectation\", \"Outstanding\"";
        public FailureAction OnFailure => FailureAction.AllowRecordWithWarning;
        public IValidationResult Apply(Employee entityToValidate)
        {
            var result = new ValidationResult();
            switch (entityToValidate.EmployeeRating)
            {
                case "Underperformer":
                case "Meets Expectation":
                case "Exceeds Expectation":
                case "Outstanding":
                    result.IsSuccess = true;
                    break;
                default:
                    result.IsSuccess = false;
                    result.Errors.Add(new ValidationError(GetType().Name, Expected, $"Value received was: {entityToValidate.EmployeeRating}"));
                    break;
            }

            return result;
        }
    }
}