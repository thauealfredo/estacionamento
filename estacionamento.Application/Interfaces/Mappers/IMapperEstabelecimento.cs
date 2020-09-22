using estacionamento.Application.Dtos;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Application.Interfaces.Mappers
{
    public interface IMapperEstabelecimento
    {
        Estabelecimento MapperDtoToEntity(EstabelecimentoDto estabelecimentoDto);

        IEnumerable<EstabelecimentoDto> MapperListEstabelecimentosDto(IEnumerable<Estabelecimento> estabelecimentos);

        EstabelecimentoDto MapperEntityToDto(Estabelecimento estabelecimento);
    }
}