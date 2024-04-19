using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XiaBags_Ecommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Write the name.")]
        [StringLength(50, ErrorMessage = "The maximum length is 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write the last name.")]
        [StringLength(50, ErrorMessage = "The maximum length is 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Write the address.")]
        [StringLength(100, ErrorMessage = "The maximum length is 100 characters.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Write the postal code.")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "The {0} must have at least {1} characters and the maximum length is {2} characters.")]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Write the name of the city.")]
        [StringLength(50, ErrorMessage = "The maximum length is 50 characters.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Write the name of the district.")]
        [StringLength(50, ErrorMessage = "The maximum length is 50 characters.")]
        [Display(Name = "District")]
        public string District { get; set; }

        [Required(ErrorMessage = "Write a phone number.")]
        [StringLength(25, ErrorMessage = "The maximum length is 25 characters.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Write an email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "Write a correct email.")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Order")]
        public decimal TotalOrder { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Items Order")]
        public int TotalItemsOrder { get; set; }

        [Display(Name = "Date of the order")]
        [DataType(DataType.Text)] //Poderia ser datetime
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Sent at")]
        [DataType(DataType.Text)] //Poderia ser datetime
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? OrderSentDate { get; set; }

        public List<OrderDetail> ItemsOrder { get; set; }
    }
}
