using System.ComponentModel;

namespace XiaBags_Ecommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
