using System.ComponentModel;

namespace XiaBags_Ecommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string ImageThumbnailURL { get; set; }

        public bool StockInHand { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
    }
}
