using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceApp.Areas.Identity.Data;
using eCommerceApp.Data.Base;

namespace eCommerceApp.Models
{
    public class ShoppingCart : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        // #####



        // Relationships

		// CartItem
		public List<CartItem> CartItems { get; set; }

        // AppUser
        public string? AppUserId { get; set; }
    }
}
