using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceApp.Data.Base;

namespace eCommerceApp.Models
{
    public class Category : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        // #####

        public String Name { get; set; }
        public String Image { get; set; }

        // Relationships

        // Product
        public List<Product> Products { get; set; }
    }
}
