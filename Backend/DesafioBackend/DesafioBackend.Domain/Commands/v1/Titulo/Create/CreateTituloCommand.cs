using MediatR;
using System;
using System.Collections.Generic;

namespace DesafioBackend.Domain.Commands.v1.Titulo.Create
{
    public class CreateTituloCommand : IRequest
    {
        public int Numero { get; set; }
        public string NomeDevedor { get; set; }
        public string CPFDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public List<Parcela> Parcelas { get; set; }

        public class Parcela
        {
            public int Numero { get; set; }
            public decimal Valor { get; set; }
            public DateTime DataVencimento { get; set; }
        }
    }
}
