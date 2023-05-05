using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using salamAliTask.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace salamAliTask.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? EName { get; set; }
        public string? AName { get; set; } 
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public int CatId { get; set; }
        public List<CustomField> CustomFields { get; set; }

    }

    }
