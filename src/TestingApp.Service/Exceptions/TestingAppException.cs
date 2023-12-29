using System.Net;

namespace TestingApp.Service.Exceptions;

public class TestingAppException : Exception
{
    public int Code { get; set; }
    public TestingAppException(int code, string message) : base(message)
    {
        Code = code;
    }
}
