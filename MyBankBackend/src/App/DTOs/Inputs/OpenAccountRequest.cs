namespace MyBank.DTOs.Inputs
{
    public record OpenAccountRequest(
        CustomerInputModel Customer,
        string Password
    );
}