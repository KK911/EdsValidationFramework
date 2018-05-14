using System.Collections.Generic;

namespace ValidationDesign
{
    public abstract class BulkImportEntity
    {
        public string ExternalId { get; set; }
        public IDictionary<string, string> ExtendedData { get; set; }
    }
}
