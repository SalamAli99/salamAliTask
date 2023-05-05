using System.ComponentModel.DataAnnotations;

namespace salamAliTask.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string? CatEName { get; set; }
        public string? CatAName { get; set; }
    }
}
