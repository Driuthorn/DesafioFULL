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
            var titulo = new TituloEntity
            {
                Id = Guid.NewGuid(),
                NumeroTitulo = request.NumeroTitulo,
                NomeDevedor = request.NomeDevedor,
                CPFDevedor = request.CPFDevedor,
                Juros = request.Juros,
                Multa = request.Multa,
                QtdParcelas = request.QtdParcelas,
            };

            titulo.Parcelas = CreateParcelas(titulo.Id, request);

            _tituloRepository.Create(titulo);

            _tituloRepository.SaveChanges();

            return Task.FromResult(Unit.Value);
        }

        private List<Parcela> CreateParcelas(Guid tituloId, CreateTituloCommand request)
        {
            var parcelas = new List<Parcela>();

            for (int i = 1; i <= request.QtdParcelas; i++)
            {
                parcelas.Add(new Parcela
                {
                    Id = Guid.NewGuid(),
                    IdTitulo = tituloId,
                    NumeroParcela = i,
                    Valor = request.Valor / request.QtdParcelas,
                    Vencimento = request.DataVencimentoInicial.AddMonths(i-1)
                });
            }

            return parcelas;
        }
    }
}
