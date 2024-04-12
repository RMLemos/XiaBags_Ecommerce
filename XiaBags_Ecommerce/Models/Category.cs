using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XiaBags_Ecommerce.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Write the name of the category.")]
        [StringLength(100, ErrorMessage = "The maximum length is 100 characters.")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Write a description for the category.")]
        [StringLength(200, ErrorMessage = "The maximum length is 200 characters.")]
        [Display(Name = "Description")]
        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastUpdatedAt { get; set; }
    }
}
