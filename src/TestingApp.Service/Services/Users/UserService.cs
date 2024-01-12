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
    private readonly IGenericRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IGenericRepository<User> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserForViewModelDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
    {
        var existUser = await repository.GetAsync(u => u.Email == userForCreationDTO.Email);
        if (existUser is not null)
            throw new TestingAppException(400, "This user already exist");

        userForCreationDTO.Password = userForCreationDTO.Password.Encrypt();
        var createdUser = await repository.CreateAsync(mapper.Map<User>(userForCreationDTO));
        
        return mapper.Map<UserForViewModelDTO>(createdUser);
    }

    public Task<bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePassword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeRoleAsync(long id, UserRole userRole)
    {
        throw new NotImplementedException();
    }


    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserForViewModelDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserForViewModelDTO> GetAsync(Expression<Func<User, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<UserForViewModelDTO> UpdateAsync(long id, UserForUpdateDTO userForUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
