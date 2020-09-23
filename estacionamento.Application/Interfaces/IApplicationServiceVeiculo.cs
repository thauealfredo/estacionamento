using estacionamento.Application.Dtos;
using System.Collections.Generic;

namespace estacionamento.Application.Interfaces
{
    public interface IApplicationServiceVeiculo
    {
        void Add(VeiculoDto veiculoDto);

        void Update(VeiculoDto veiculoDto);

        void Remove(int id);

        IEnumerable<VeiculoDto> GetAll();

        VeiculoDto GetById(int id);
    }
}