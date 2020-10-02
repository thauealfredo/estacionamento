using estacionamento.Application.Dtos;
using System.Collections.Generic;

namespace estacionamento.Application.Interfaces
{
    public interface IApplicationServiceRelatorio
    {
        IEnumerable<RelatorioDto> Relatorio(EstabelecimentoDto estabelecimentoDto, VeiculoDto veiculoDto);

        IEnumerable<SaidaEntradaDto> SaidaEntradaDto(EstabelecimentoDto estabelecimentoDto, int entrada, int saida);

        IEnumerable<SaidaEntradaHoraDto> SaidaEntradaHoraDto(EstabelecimentoDto estabelecimentoDto, float result);
    }
}