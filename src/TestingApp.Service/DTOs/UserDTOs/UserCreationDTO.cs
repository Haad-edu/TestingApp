using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.UserDTOs;

public class UserCreationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole UserRole { get; set; }
}
