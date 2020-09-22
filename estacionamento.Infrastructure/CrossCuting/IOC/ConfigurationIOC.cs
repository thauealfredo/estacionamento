using Autofac;
using estacionamento.Application;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Application.Mappers;
using estacionamento.Domain.Core.Interfaces.Repositorys;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using estacionamento.Domain.Services;
using estacionamento.Infrastructure.Data.Repositorys;

namespace estacionamento.Infrastructure.CrossCuting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceEstabelecimento>().As<IApplicationServiceEstabelecimento>();
            builder.RegisterType<ApplicationServiceVeiculo>().As<IApplicationServiceVeiculo>();

            builder.RegisterType<ServiceEstabelecimento<Estabelecimento>>().As<IServiceEstabelecimento<Estabelecimento>>();
            builder.RegisterType<ServiceVeiculo<Veiculo>>().As<IServiceVeiculo<Veiculo>>();

            builder.RegisterType<RepositoryEstabelecimento<Estabelecimento>>().As<IRepositoryEstabelecimento<Estabelecimento>>();
            builder.RegisterType<RepositoryVeiculo<Veiculo>>().As<IRepositoryVeiculo<Veiculo>>();

            builder.RegisterType<MapperEstabelecimento>().As<IMapperEstabelecimento>();
            builder.RegisterType<MapperVeiculo>().As<IMapperVeiculo>();

            #endregion IOC
        }
    }
}