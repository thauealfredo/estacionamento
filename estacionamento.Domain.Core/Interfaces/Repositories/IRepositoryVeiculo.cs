using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryVeiculo : IRepositoryBase<Veiculo>
    {
        IEnumerable<Veiculo> GetByIdEstabelecimento(int id);
    }
}