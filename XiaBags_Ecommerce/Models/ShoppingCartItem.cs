using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XiaBags_Ecommerce.Models
{
    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    {
        public int ShoppingCartItemID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
