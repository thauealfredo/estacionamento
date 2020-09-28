using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Domain.Services
{
    public class ServiceVeiculo: ServiceBase<Veiculo>, IServiceVeiculo
    {
        private readonly IRepositoryVeiculo repositoryVeiculo;

        public ServiceVeiculo(IRepositoryVeiculo repositoryVeiculo) : base(repositoryVeiculo)
        {
            this.repositoryVeiculo = repositoryVeiculo;
        }

    }
}