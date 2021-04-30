using System.Net;

namespace DesafioBackend.CrossCutting.Exceptions.QueryExceptions
{
    public class CreateTituloException : ApiCustomException
    {
        public CreateTituloException(string message) : base(message, HttpStatusCode.BadRequest)
        { }
    }
}
