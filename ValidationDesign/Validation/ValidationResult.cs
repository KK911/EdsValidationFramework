using System.Collections.Generic;

namespace ValidationDesign.Validation
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult()
        {
            Errors = new List<ValidationError>();
        }
        public IList<ValidationError> Errors { get; set; }

        public bool IsSuccess { get; set; }
    }
}