using DesafioBackend.Data.Database.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackend.Data.Query.Queries.v1.Titulo.Get
{
    public class GetTituloQueryHandler : IRequestHandler<GetTituloQuery, GetTituloQueryResponse>
    {
        private readonly ITituloRepository _tituloRepository;
        private readonly IParcelaRepository _parcelaRepository;

        public GetTituloQueryHandler(ITituloRepository tituloRepository, IParcelaRepository parcelaRepository)
        {
            _tituloRepository = tituloRepository;
            _parcelaRepository = parcelaRepository;
        }

        public Task<GetTituloQueryResponse> Handle(GetTituloQuery request, CancellationToken cancellationToken)
        {
            var queryResponse = new GetTituloQueryResponse();
            var dbTitulos = _tituloRepository.Get();

            foreach(var titulo in dbTitulos)
            {
                var parcelas = GetTituloParcelas(titulo.Juros, titulo.Multa, titulo.Id, out decimal valorOriginal, out int diasEmAtraso);

                queryResponse.Titulos.Add(new GetTituloQueryResponse.Titulo
                {
                    Id = titulo.Id,
                    DiasEmAtraso = diasEmAtraso,
                    ValorAtual = Math.Round(parcelas.Sum(x => x.Valor), 2),
                    ValorOriginal = valorOriginal,
                    NomeDevedor = titulo.NomeDevedor,
                    Numero = titulo.NumeroTitulo,
                    QtdParcelas = titulo.QtdParcelas,
                    Parcelas = parcelas,
                });
            }


            return Task.FromResult(queryResponse);
        }

        private List<GetTituloQueryResponse.Parcela> GetTituloParcelas(decimal juros, decimal multa, Guid IdTitulo, out decimal valorOriginal, out int diasEmAtraso)
        {
            var queryResponseParcelas = new List<GetTituloQueryResponse.Parcela>();
            diasEmAtraso = 0;

            var parcelas = _parcelaRepository.Find(x => x.IdTitulo == IdTitulo).ToList();

            valorOriginal = decimal.Round(parcelas.Sum(x => x.Valor), 2);

            foreach(var parcela in parcelas)
            {
                var diasDiff = (DateTime.Now - parcela.Vencimento).Days;

                decimal valorMulta = 0;
                decimal valorJuros = 0;

                if (diasDiff > 0)
                {
                    valorMulta = parcela.Valor * (multa/100);
                    valorJuros = parcela.Valor * Convert.ToDecimal(diasDiff) * (juros / 100 / 30);

                    diasEmAtraso = diasDiff > diasEmAtraso ? diasDiff : diasEmAtraso;
                }

                queryResponseParcelas.Add(new GetTituloQueryResponse.Parcela
                {
                    Numero = parcela.NumeroParcela,
                    Valor = Math.Round(parcela.Valor + valorMulta + valorJuros, 2),
                    DataVencimento = parcela.Vencimento
                });
            }

            return queryResponseParcelas.OrderBy(x => x.DataVencimento).ToList();
        }
    }
}
