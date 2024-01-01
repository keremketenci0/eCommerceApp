using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eCommerceApp.Areas.Identity.Data;

namespace eCommerceApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        // #####

        public string Email { get; set; }

        // Relationships
    }
}
