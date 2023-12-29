using System.ComponentModel.DataAnnotations;
using TestingApp.Service.Attributes;

namespace TestingApp.Service.DTOs.Users
{
    public  class UserForChangePasswordDTO
    {
        [Required]
        public string OldPassword {  get; set; }

        [Required, UserPassword]
        public string NewPassword { get; set; }
        
        [Required]
        public string Email { get; set; }

    }
}
