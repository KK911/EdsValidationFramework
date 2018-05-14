using System.Collections.Generic;

namespace ValidationDesign.Validation
{
    public class ValidationSummary : IValidationSummary
    {
        public ValidationSummary()
        {
            ErrorSummary = new List<ValidationError>();
        }

        public List<ValidationError> ErrorSummary { get; set; }
        public bool AllowRecordImport { get; set; }
    }
}