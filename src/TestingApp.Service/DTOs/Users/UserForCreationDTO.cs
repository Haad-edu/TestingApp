using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.Users;

public class UserForCreationDTO
{
    [MaxLength(64, ErrorMessage = "First Name must be longer than 64 characters")]
    public string FirstName { get; set; }

    [MaxLength(64, ErrorMessage = "Last Name must be longer than 64 characters")]
    public string LastName { get; set; }

    [MaxLength(128, ErrorMessage = "Email must be longer than 128 characters")]
    public string Email { get; set; }

    [MinLength(8, ErrorMessage = "Password must be shorter than 8 characters")]
    public string Password { get; set; }
}
