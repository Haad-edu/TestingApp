namespace TestingApp.Service.Interfaces.Users;

public interface IAuthService
{
    ValueTask<string> GenerateToken(string email, string password);
}
