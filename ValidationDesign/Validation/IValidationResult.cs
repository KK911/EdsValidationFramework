using System.Collections.Generic;

namespace ValidationDesign.Validation
{
    public interface IValidationResult
    {
        IList<ValidationError> Errors { get; }
        bool IsSuccess { get; }
    }
}