using System.ComponentModel.DataAnnotations;

namespace PostApp.Api.Contract.Authentication;

public class RegisterManagerRequestDto
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, and one digit")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email must be a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Manager Number is required")]
    [StringLength(20, MinimumLength = 1, ErrorMessage = "Manager Number must be between 1 and 20 characters")]
    public string ManagerNumber { get; set; } = string.Empty;
}