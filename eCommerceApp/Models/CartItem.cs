using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eCommerceApp.Data.Base;

namespace eCommerceApp.Models
{
	public class CartItem : IEntityBase
    {
		[Key]
		public int Id { get; set; }

		// #####
		public int Quantity { get; set; }

		// Relationships

		// Product
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public Product Product { get; set; }

        // ShoppingCart
        public int ShoppingCartId { get; set; }
		[ForeignKey("ShoppingCartId")]
		public ShoppingCart ShoppingCart { get; set; }
	}
}
