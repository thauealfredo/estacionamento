using estacionamento.Application.Dtos;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Application.Interfaces.Mappers
{
    public interface IMapperVeiculo
    {
        Veiculo MapperDtoToEntity(VeiculoDto veiculoDto);

        IEnumerable<VeiculoDto> MapperListVeiculosDto(IEnumerable<Veiculo> veiculos);

        VeiculoDto MapperEntityToDto(Veiculo veiculo);
    }
}