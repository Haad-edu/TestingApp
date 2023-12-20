using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.UserDTOs;

public class UserModificationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole UserRole { get; set; }
}
