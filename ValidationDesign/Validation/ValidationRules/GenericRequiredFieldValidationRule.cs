using System;
using ValidationDesign.Entities;

namespace ValidationDesign.Validation.ValidationRules
{
    /// <summary>
    /// Use this class to add Required Field validation in a generic fashion
    /// without having to write entity specific class. This method uses reflection
    /// and does not provide compile time type safety. So use caution.
    /// </summary>
    public class GenericRequiredFieldValidationRule : RequiredFieldValidationRule<BulkImportEntity>
    {
        public GenericRequiredFieldValidationRule(string fieldToValidate, Type fieldType)
        {
            FieldName = fieldToValidate;
            FieldType = fieldType;
        }

        protected override string Actual { get; set; }
        protected override string FieldName { get; }
        private Type FieldType { get; }
        protected override bool FieldExists(BulkImportEntity bulkImportEntity)
        {
            // Using reflection, get the value of field and check if the field value is not null;
            return true;
        }
    }
}