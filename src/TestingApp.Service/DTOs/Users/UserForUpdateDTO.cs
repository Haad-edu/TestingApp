using System.ComponentModel.DataAnnotations;

namespace TestingApp.Service.DTOs.Users;

public class UserForUpdateDTO
{
    [MaxLength(64, ErrorMessage = "First Name must be less than 64 characters")]
    public string FirstName { get; set; }

    [MaxLength(64, ErrorMessage = "First Name must be less than 64 characters")]
    public string LastName { get; set; }

    [MaxLength(64, ErrorMessage = "Email should be less than 64 characters")]
    public string Email { get; set; }   
}
