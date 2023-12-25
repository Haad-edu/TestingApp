using TestingApp.Service.Interfaces.Users;

namespace TestingApp.Service.Services
{
    public class AuthService : IAuthService
    {
        public ValueTask<string> GenerateToken(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
