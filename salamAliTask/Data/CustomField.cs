using System.ComponentModel.DataAnnotations;

namespace salamAliTask.Data
{
    public class CustomField
    {
        [Key]
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
