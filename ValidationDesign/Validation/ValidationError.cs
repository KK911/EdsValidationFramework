namespace ValidationDesign.Validation
{
    public class ValidationError
    {
        public ValidationError(string errorCode)
            : this(errorCode, null, null)
        {
        }

        public ValidationError(string errorCode, string expected)
            : this(errorCode, expected, null)
        {
        }

        public ValidationError(string errorCode, string expected, string actual)
        {
            ErrorCode = errorCode;
            Expected = expected;
            Actual = actual;
        }

        public string ErrorCode { get; set; }
        public string Expected { get; set; }
        public string Actual { get; set; }
    }
}