using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestingApp.Data.IGenericRepositories;
using TestingApp.Domain.Entities.Users;
using TestingApp.Service.Exceptions;
using TestingApp.Service.Extensions;
using TestingApp.Service.Interfaces.Users;

namespace TestingApp.Service.Services.Users;

public class AuthService : IAuthService
{

    private readonly IGenericRepository<User> userRepository;
    private readonly IConfiguration configuration;

    public AuthService(IGenericRepository<User> userRepository, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
    }
    public async ValueTask<string> GenerateToken(string email, string password)
    {
        User user = await userRepository.GetAsync(u =>
            u.Email == email && u.Password.Equals(password.Encrypt()));

        if (user is null)
            throw new TestingAppException(400, "Login or Password is incorrect");


        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        byte[] tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

        SecurityTokenDescriptor tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString())
            }),
            Expires = DateTime.UtcNow.AddMonths(int.Parse(configuration["JWT:Lifetime"])),
            Issuer = configuration["JWT:Issuer"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);

    }
}
