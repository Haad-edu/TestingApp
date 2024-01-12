using System.ComponentModel.DataAnnotations;
using TestingApp.Domain.Enums;

namespace TestingApp.Service.DTOs.Users;

public class UserForCreationDTO
{
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
