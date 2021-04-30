using DesafioBackend.Api.Infrastructure.Pipelines;
using DesafioBackend.Data.Database.Interface;
using DesafioBackend.Data.Database.Repository;
using DesafioBackend.Data.Query.Queries.v1.Titulo.Get;
using DesafioBackend.Domain.Commands.v1.Titulo.Create;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Serilog;
using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;

namespace DesafioBackend.Api.Infrastructure.IoC
{
    public class Bootstrapper
    {
        private readonly Assembly _domainAssembly = typeof(CreateTituloCommandHandler).Assembly;
        private readonly Assembly _queryAssembly = typeof(GetTituloQueryHandler).Assembly;

        public void Inject(Container container)
        {
            container.Register(() => Log.Logger, Lifestyle.Singleton);
            container.RegisterSingleton(typeof(IValidator<>), _domainAssembly, _queryAssembly);

            InjectRepositories(container);
            InjectMediator(container, _domainAssembly, _queryAssembly);
        }


        private void InjectMediator(Container container, params Assembly[] assemblies)
        {
            var mediators = new[] { typeof(IMediator).GetTypeInfo().Assembly };
            assemblies.Concat(mediators);
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IRequestHandler<>), assemblies);

            container.Collection.Register(typeof(IPipelineBehavior<,>), Enumerable.Empty<Type>());
            container.Collection.Register(typeof(IRequestPreProcessor<>), Enumerable.Empty<Type>());
            container.Collection.Register(typeof(IRequestPostProcessor<,>), Enumerable.Empty<Type>());

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[] { typeof(ValidatorRequestBehavior<,>) });
        }

        private void InjectRepositories(Container container)
        {
            container.Register<ITituloRepository, TituloRepository>(Lifestyle.Scoped);
            container.Register<IParcelaRepository, ParcelaRepository>(Lifestyle.Scoped);
        }
    }
}
