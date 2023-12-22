using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Users;

public class UserForModificationDTO
{
    [MaxLength(64, ErrorMessage = "First Name must be longer than 64 characters")]
    public string FirstName { get; set; }

    [MaxLength(64, ErrorMessage = "First Name must be longer than 64 characters")]
    public string LastName { get; set; }
}
