using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Users;
using TestingApp.Domain.Enums;
using TestingApp.Service.DTOs.Users;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Users;

namespace TestingApp.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<User> _repository;
    private readonly IAuthService _authService;

    public UserService(IGenericRepository<User> repository, IMapper mapper, IAuthService authService)
    {
        mapper = _mapper;
        repository = _repository;
        _authService = authService;
    }

    public async Task<UserForViewModelDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
    {
        var existUser = await _repository.GetAsync(u => u.Email == userForCreationDTO.Email);
        if (existUser != null)
        {
            throw new TestingAppException(400, "User with that Email already exist");
        }

        userForCreationDTO.Password = userForCreationDTO.Password.Encrypt();

        var user = await _repository.CreateAsync(_mapper.Map<User>(userForCreationDTO));

        if (user != null) 
        {
            // Generating Token Useng Authoservice
            await _authService.GenerateToken(userForCreationDTO.Email, userForCreationDTO.Password);
        }

       return _mapper.Map<UserForViewModelDTO>(user);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var isRemoved = await _repository.DeleteAsync(u => u.Id == id);
        if (!isRemoved)
            throw new TestingAppException(404, "User not found");
        return true;
    }

    public async Task<IEnumerable<UserForViewModelDTO>> GetAllAsync(PaginationParams @params,
        Expression<Func<User,
            bool>> expression = null)
    {
        var users = _repository.GetAll(expression: expression, isTracking: false);

        return _mapper.Map<List<UserForViewModelDTO>>(await users.ToPagedList(@params).ToListAsync());
    }

    public async Task<UserForViewModelDTO> GetAsync(Expression<Func<User, bool>> expression)
    {
        var existUser = await _repository.GetAsync(expression);
        if (existUser == null)
        {
            throw new TestingAppException(404, "User not found");
        }
        return _mapper.Map<UserForViewModelDTO>(existUser);
    }

    public async Task<UserForViewModelDTO> UpdateAsync(long id, UserForUpdateDTO userForUpdateDTO)
    {
        var existUser = await _repository.GetAsync(u => u.Id == id);
        if (existUser == null)
        {
            throw new TestingAppException(404, "User not found ");
        }
        existUser.UpdatedAt = DateTime.UtcNow;

        existUser = await _repository.Update(_mapper.Map(userForUpdateDTO, existUser));
        return _mapper.Map<UserForViewModelDTO>(existUser);
    }
    public Task<bool> ChangeRoleAsync(long id, UserRole userRole)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePassword)
    {
        var user = await _repository.GetAsync(u => u.Email == userForChangePassword.Email);

        if (user == null)
            throw new TestingAppException(404, "User not found");

        if (user.Password != userForChangePassword.OldPassword.Encrypt())
            throw new TestingAppException(400, "Password is Incorrect");


        user.Password = userForChangePassword.NewPassword.Encrypt();

        await _repository.Update(user);
        return true;
    }
}
