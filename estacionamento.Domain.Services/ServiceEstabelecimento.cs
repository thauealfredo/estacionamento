using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;

namespace estacionamento.Domain.Services
{
    public class ServiceEstabelecimento : ServiceBase<Estabelecimento>, IServiceEstabelecimento
    {
        private readonly IRepositoryEstabelecimento repositoryEstabelecimento;

        public ServiceEstabelecimento(IRepositoryEstabelecimento repositoryEstabelecimento)
            : base(repositoryEstabelecimento)
        {
            this.repositoryEstabelecimento = repositoryEstabelecimento;
        }
    }
}