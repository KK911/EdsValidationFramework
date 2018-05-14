using System.Collections.Generic;
using ValidationDesign.Validation.ValidationRules;

namespace ValidationDesign.Validation.Validators
{
    public interface IValidator<T>
        where T : BulkImportEntity
    {
        IList<IValidationRule<T>> ValidationRules { get; }
        IValidationSummary Validate(T entity);
    }
}