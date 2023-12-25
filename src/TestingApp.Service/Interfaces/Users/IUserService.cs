using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestingApp.Domain.Configurations;
using TestingApp.Domain.Entities.Users;
using TestingApp.Domain.Enums;
using TestingApp.Service.DTOs.Users;

namespace TestingApp.Service.Interfaces.Users
{
    public interface IUserService
    {
        public Task<UserForViewModelDTO> CreateAsync(UserForCreationDTO userForCreationDTO);

        public Task<UserForViewModelDTO> UpdateAsync(long id, UserForUpdateDTO userForUpdateDTO);

        public Task<bool> DeleteAsync(long id);

        public Task<IEnumerable<UserForViewModelDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<User, bool>> expression = null);

        public Task<IEnumerable<UserForViewModelDTO>> GetAllByDegreeAndFullNameAsync(PaginationParams paginationParams, string degree, string fullName);

        public Task<UserForViewModelDTO> GetAsync(Expression<Func<User, bool>> expression);

        public Task<bool> ChangeRoleAsync(long id, UserRole userRole);

    }
}
