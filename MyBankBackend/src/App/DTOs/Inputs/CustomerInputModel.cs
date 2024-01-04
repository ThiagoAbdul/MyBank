using System.ComponentModel.DataAnnotations;

namespace MyBank.DTOs.Inputs
{
    public class CustomerInputModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string BirthDate { get; set; }

        public CustomerInputModel() { }

    }
    
}