namespace ValidationDesign.Validation.ValidationRules
{
    public abstract class RequiredFieldValidationRule<T> : IValidationRule<T>
        where T : BulkImportEntity
    {
        protected abstract string FieldName { get; }
        protected abstract string Actual { get; set; }
        public string Expected => $"{FieldName} in {typeof(T).Name} is a required field.";
        public FailureAction OnFailure => FailureAction.StopRecord;
        protected abstract bool FieldExists(T bulkImportEntity);

        public IValidationResult Apply(T entityToValidate)
        {
            var result = new ValidationResult();
            if (FieldExists(entityToValidate))
            {
                result.IsSuccess = true;
                return result;
            }

            result.Errors.Add(new ValidationError(GetType().Name, Expected, Actual));
            return result;
        }
    }
}