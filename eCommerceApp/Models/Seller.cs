using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceApp.Data.Base;

namespace eCommerceApp.Models
{
    public class Seller : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        // #####

        public string Name { get; set; }

        // Relationships

        // Product
        public List<Product> Products { get; set; }
    }
}
