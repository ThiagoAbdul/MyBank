namespace MyBank.DTOs.Inputs
{
    public class CustomerInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }

        public CustomerInputModel() { }

    }
    
}