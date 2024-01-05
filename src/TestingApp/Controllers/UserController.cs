using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Enums;
using TestingApp.Service.DTOs.Users;
using TestingApp.Service.Interfaces.Users;

namespace TestingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(UserForCreationDTO userForCreationDTO)
            => Ok(await userService.CreateAsync(userForCreationDTO));

        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserForUpdateDTO userForUpdateDTO)
            => Ok(await userService.UpdateAsync(id, userForUpdateDTO));

        [HttpPatch("{id}")]
        public async ValueTask<IActionResult> ChangeRoleAsync([FromRoute] int id, UserRole userRole)
           => Ok(await userService.ChangeRoleAsync(id, userRole));

        [HttpPatch("Change_Password")]
        public async ValueTask<IActionResult> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO)
            => Ok(await userService.ChangePasswordAsync(userForChangePasswordDTO));

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
           => Ok(await userService.GetAllAsync(@params));

       
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
           => Ok(await userService.GetAsync(u => u.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await userService.DeleteAsync(id));
    }
}
