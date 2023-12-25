namespace TestingApp.Service.Interfaces.Users;

public interface IAuthService
{
    ValueTask<string> GenerateToken(string username, string password);
}
