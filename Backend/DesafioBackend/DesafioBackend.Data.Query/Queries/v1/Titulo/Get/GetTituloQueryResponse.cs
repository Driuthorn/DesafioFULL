using System;
using System.Collections.Generic;

namespace DesafioBackend.Data.Query.Queries.v1.Titulo.Get
{
    public class GetTituloQueryResponse
    {
        public GetTituloQueryResponse()
        {
            Titulos = new List<Titulo>();
        }
        public List<Titulo> Titulos { get; set; }

        #region Nested Classes
        public class Titulo
        {
            public Guid Id { get; set; } 
            public int NumeroTitulo { get; set; }
            public string NomeDevedor { get; set; }
            public int QtdParcelas { get; set; }
            public decimal ValorOriginal { get; set; }
            public int DiasEmAtraso { get; set; }
            public decimal ValorAtual { get; set; }
            public List<Parcela> Parcelas { get; set; }
        }

        public class Parcela
        {
            public int NumeroParcela { get; set; }
            public decimal Valor { get; set; }
            public DateTime Vencimento { get; set; }
        }
        #endregion
    }
}
