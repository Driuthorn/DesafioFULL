using System;

namespace DesafioBackend.Data.Database.Entities
{
    public class Parcela
    {
        public Guid Id { get; set; }
        public Guid IdTitulo { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; } 

        public Titulo Titulo { get; set; }
    }
}
