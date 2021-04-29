using System;
using System.Collections.Generic;

namespace DesafioBackend.Data.Database.Entities
{
    public class Titulo
    {
        public Guid Id { get; set; }
        public int NumeroTitulo { get; set; }
        public string NomeDevedor { get; set; }
        public string CPFDevedor { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public int QtdParcelas { get; set; }

        public ICollection<Parcela> Parcelas { get; set; }
    }
}
