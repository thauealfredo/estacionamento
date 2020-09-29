using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Domain.Core.Interfaces.Services
{
    public interface IServiceVeiculo : IServiceBase<Veiculo>
    {
        IEnumerable<Veiculo> GetByIdEstabelecimento(int id);
    };
}