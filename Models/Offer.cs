using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFEBackend.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Types Type { get; set; }

        [Required]
        public States State { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public Places Place { get; set; }

        public double Price { get; set; }

        [Required]
        public string Seller { get; set; }

        public int count_report { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Parent { get; set; }
    }

    public enum States
    {
        Published,
        Sell,
        Invisible
    }

    public enum Types
    {
        Give,
        Sale,
        Service
    }

    public enum Places
    {
        Woluwe,
        Ixelles,
        Louvain
    }
}
