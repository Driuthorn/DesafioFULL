using System;
using System.Net;

namespace DesafioBackend.CrossCutting.Exceptions
{
    public class ApiCustomException : Exception
    {
        public HttpStatusCode ResponseCode { get; }
        public string CustomMessage { get; }

        public ApiCustomException(string customMessage, HttpStatusCode responseCode)
        {
            CustomMessage = customMessage;
            ResponseCode = responseCode;
        }
    }
}
