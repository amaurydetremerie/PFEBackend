using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PFEBackend.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Types Type { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public States State { get; set; }

        public bool Deleted { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Places Place { get; set; }

        public double Price { get; set; }

        [Required]
        public string Seller { get; set; }

        [Required]
        public string SellerEMail { get; set; }

        public int CountReport { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
    }

    public enum States
    {
        Published,
        Sold,
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
