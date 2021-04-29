using FluentValidation;

namespace DesafioBackend.Domain.Commands.v1.Titulo.Create
{
    public class CreateTituloCommandValidator : AbstractValidator<CreateTituloCommand>
    {
        public CreateTituloCommandValidator()
        {
        }
    }
}
