namespace ValidationDesign.Validation.ValidationRules
{
    public abstract class RangeValidationRule<TEntity, TField> : IValidationRule<TEntity>
        where TEntity : BulkImportEntity
    {
        protected abstract string FieldName { get; }
        protected abstract TField MinValue { get; }
        protected abstract TField MaxValue { get; }
        protected abstract string Actual { get; set; }
        public string Expected => $"The value of {FieldName} should be in between {MinValue} and {MaxValue}";
        public FailureAction OnFailure => FailureAction.StopRecord;
        protected abstract bool IsValueInRange(TEntity entity);

        public IValidationResult Apply(TEntity entityToValidate)
        {
            var result = new ValidationResult();
            if (IsValueInRange(entityToValidate))
            {
                result.IsSuccess = true;
                return result;
            }

            result.Errors.Add(new ValidationError(GetType().Name, Expected, Actual));
            return result;
        }
    }
}