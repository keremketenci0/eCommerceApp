using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using eCommerceApp.Data.Base;

namespace eCommerceApp.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(3);
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // #####

        public String Name { get; set; }
        public double Price { get; set; }
        public String Image { get; set; }

        // Relationships

        // Seller
        public int SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        // Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
