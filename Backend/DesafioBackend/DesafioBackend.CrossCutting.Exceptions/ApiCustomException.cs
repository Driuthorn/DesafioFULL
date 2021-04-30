using System;
using System.Net;

namespace DesafioBackend.CrossCutting.Exceptions
{
    public class ApiCustomException : Exception
    {
        public HttpStatusCode ResponseCode { get; }

        public ApiCustomException(string message, HttpStatusCode responseCode) : base(message)
        {
            ResponseCode = responseCode;
        }
    }
}
