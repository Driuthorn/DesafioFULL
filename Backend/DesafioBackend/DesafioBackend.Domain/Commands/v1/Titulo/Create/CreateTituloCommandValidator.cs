using FluentValidation;

namespace DesafioBackend.Domain.Commands.v1.Titulo.Create
{
    public class CreateTituloCommandValidator : AbstractValidator<CreateTituloCommand>
    {
        public CreateTituloCommandValidator()
        {
            RuleFor(c => c.CPFDevedor).NotEmpty().WithMessage("CPF é obrigatório")
                .MaximumLength(11).WithMessage("Tamanho máximo de 11 caracteres");

            RuleFor(c => c.Juros).NotEmpty().WithMessage("Juros é obrigatório");
            RuleFor(c => c.Multa).NotEmpty().WithMessage("Multa é obrigatório");
            RuleFor(c => c.NomeDevedor).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.Numero).NotEmpty().WithMessage("Numero do titulo é obrigatório");
            RuleFor(c => c.Parcelas).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("É obrigatório pelo menos 1 Parcela")
                .Must(c => c.Count > 0).WithMessage("É obrigatório pelo menos 1 Parcela");
        }
    }
}
