using System.Net;

namespace TestingApp.Service.Exceptions;

public class HttpException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public int Code { get; set; }

    public string Message { get; set; }

    public HttpException(string message, int statusCode) : base(message)
    {
        Code = statusCode;
        Message = message;
        if (Enum.TryParse<HttpStatusCode>(statusCode.ToString(), out HttpStatusCode code))
            StatusCode = code;
    }
}
