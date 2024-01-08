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
        /// <summary>
        /// Create new user by {User}
        /// </summary>
        /// <param name="userForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserForCreationDTO userForCreationDTO)
            => Ok(await userService.CreateAsync(userForCreationDTO));

        /// <summary>
        /// Update user info by {Admin}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userForUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async ValueTask<IActionResult> UpdateAsync([FromRoute] int id, UserForUpdateDTO userForUpdateDTO)
            => Ok(await userService.UpdateAsync(id, userForUpdateDTO));

        /// <summary>
        /// Change user's role by {Admin}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRole"></param>
        /// <returns></returns>
        [HttpPatch("{id}"),Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRoleAsync([FromRoute] int id, UserRole userRole)
           => Ok(await userService.ChangeRoleAsync(id, userRole));

        /// <summary>
        /// Change password by {User}
        /// </summary>
        /// <param name="userForChangePasswordDTO"></param>
        /// <returns></returns>
        [HttpPatch("Change_Password"), Authorize(Roles = "User")]
        public async Task<IActionResult> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO)
            => Ok(await userService.ChangePasswordAsync(userForChangePasswordDTO));

        /// <summary>
        /// Get all user by {Admin}
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams @params)
           => Ok(await userService.GetAllAsync(@params));

       
        /// <summary>
        /// Get by Id by {Admin}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
           => Ok(await userService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete user by {Admin}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await userService.DeleteAsync(id));
    }
}
