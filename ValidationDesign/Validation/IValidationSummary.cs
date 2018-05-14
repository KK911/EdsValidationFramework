using System.Collections.Generic;

namespace ValidationDesign.Validation
{
    public interface IValidationSummary
    {
        List<ValidationError> ErrorSummary { get; }
        bool AllowRecordImport { get; }
    }
}