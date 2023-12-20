using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.Users;

public class UserForCreationDTO
{
    [MaxLength(64, ErrorMessage = "First Name must be longer than 64 characters")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
}
