using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AmazonFresh.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+(?: [a-zA-Z]+)*$", ErrorMessage = "Invalid name format")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [PastDate(100)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Remote("CheckEmail", "Validation")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{3}[-.]\d{3}[-.]\d{4}$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Home Address is required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Invalid address format")]
        public string HomeAddress { get; set; }
        public DateTime CustomerCreation { get;set; }
    }
}
