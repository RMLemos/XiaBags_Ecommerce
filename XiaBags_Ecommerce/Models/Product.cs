using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XiaBags_Ecommerce.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Write the name of the product.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "The {0} must have at least {2} characters and the maximum length is {1} characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write a description for the product.")]
        [Display(Name = "Description")]
        [MinLength(10, ErrorMessage = "The description of the product must have at least {1} characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Write the price of the product.")]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "The established price varies from 1 to 999,99")]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        [StringLength(200, ErrorMessage = "The maximum length is {1} characters.")]
        public string ImageURL { get; set; }

        [Display(Name = "The path to the small image")]
        [StringLength(200, ErrorMessage = "The maximum length is {1} characters.")]
        public string ImageThumbnailURL { get; set; }

        [Display(Name = "In stock")]
        public bool StockInHand { get; set; }

        [Display(Name = "Categories")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime CreatedAt { get; set; }
        // public DateTime CreatedAt { get; set; } = DateTime.Now; Add DateTime in the database

        [DataType(DataType.DateTime)]
        public DateTime? LastUpdatedAt { get; set; }
    }
}
