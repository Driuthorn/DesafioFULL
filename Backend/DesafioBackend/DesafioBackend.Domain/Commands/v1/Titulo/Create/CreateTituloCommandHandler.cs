using DesafioBackend.CrossCutting.Exceptions.QueryExceptions;
using DesafioBackend.Data.Database.Entities;
using DesafioBackend.Data.Database.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TituloEntity = DesafioBackend.Data.Database.Entities.Titulo;

namespace DesafioBackend.Domain.Commands.v1.Titulo.Create
{
    public class CreateTituloCommandHandler : IRequestHandler<CreateTituloCommand>
    {
        private readonly ITituloRepository _tituloRepository;

        public CreateTituloCommandHandler(ITituloRepository tituloRepository)
        {
            _tituloRepository = tituloRepository;
        }

        public Task<Unit> Handle(CreateTituloCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var titulo = new TituloEntity
                {
                    Id = Guid.NewGuid(),
                    NumeroTitulo = request.Numero,
                    NomeDevedor = request.NomeDevedor,
                    CPFDevedor = request.CPFDevedor,
                    Juros = request.Juros,
                    Multa = request.Multa,
                    QtdParcelas = request.Parcelas.Count,
                };

                titulo.Parcelas = CreateParcelas(titulo.Id, request.Parcelas);

                _tituloRepository.Create(titulo);

                _tituloRepository.SaveChanges();

                return Task.FromResult(Unit.Value);
            }
            catch (Exception)
            {
                throw new CreateTituloException("Ocorreu um erro ao criar o Titulo, tente novamente em alguns instantes.");
            }
        }

        private List<Parcela> CreateParcelas(Guid tituloId, List<CreateTituloCommand.Parcela> parcelas)
        {
            var parcelasEntityList = new List<Parcela>();

            foreach (var parcela in parcelas)
            {
                var parcelaEntity = new Parcela
                {
                    Id = Guid.NewGuid(),
                    IdTitulo = tituloId,
                    NumeroParcela = parcela.Numero,
                    Valor = parcela.Valor,
                    Vencimento = parcela.DataVencimento
                };

                parcelasEntityList.Add(parcelaEntity);
            }

            return parcelasEntityList;
        }
    }
}
