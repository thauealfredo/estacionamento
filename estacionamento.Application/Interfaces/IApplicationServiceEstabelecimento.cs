using estacionamento.Application.Dtos;
using System.Collections.Generic;

namespace estacionamento.Application.Interfaces
{
    public interface IApplicationServiceEstabelecimento
    {
        void Add(EstabelecimentoDto estabelecimentoDto);

        void Update(EstabelecimentoDto estabelecimentoDto);

        void Remove(int id);

        IEnumerable<EstabelecimentoDto> GetAll();

        EstabelecimentoDto GetById(int id);
    }
}