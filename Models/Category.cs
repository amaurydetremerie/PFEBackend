using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PFEBackend.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int? ParentId { get; set; }


        // Pour les propriétés de navigation
        public virtual Category? Parent { get; set; }

        public virtual ICollection<Category>? ChildCategories { get; set;}
    }
}
