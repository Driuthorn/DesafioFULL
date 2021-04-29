using MediatR;
using System;

namespace DesafioBackend.Domain.Commands.v1.Titulo.Create
{
    public class CreateTituloCommand : IRequest
    {
        public CreateTituloCommand()
        { }

        public int NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public string CPFDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public int QtdParcelas { get; set; }
        public decimal Valor { get; set; } 
        public DateTime DataVencimentoInicial { get; set; }

    }
}
