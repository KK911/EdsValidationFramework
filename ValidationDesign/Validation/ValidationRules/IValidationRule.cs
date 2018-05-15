using ValidationDesign.Entities;

namespace ValidationDesign.Validation.ValidationRules
{
    public interface IValidationRule<in T>
        where T : BulkImportEntity
    {
        string Expected { get; }
        FailureAction OnFailure { get; }
        IValidationResult Apply(T entityToValidate);
    }
}