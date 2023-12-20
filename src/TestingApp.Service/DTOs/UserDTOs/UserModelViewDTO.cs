using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.UserDTOs;

public class UserModelViewDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public UserRole UserRole { get; set; }
    public DateTime? CreatedAt { get; set; }
}
