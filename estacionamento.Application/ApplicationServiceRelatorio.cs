using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceRelatorio : IApplicationServiceRelatorio
    {
        public IEnumerable<RelatorioDto> Relatorio(EstabelecimentoDto estabelecimentoDto, VeiculoDto veiculoDto)
        {
            List<RelatorioDto> listaRelatorio = new List<RelatorioDto>();
            var relatorio = new RelatorioDto
            {
                NomeEstabelecimento = estabelecimentoDto.Nome,
                EnderecoEstabelecimento = estabelecimentoDto.Endereco,
                Placa = veiculoDto.Placa,
                Marca = veiculoDto.Marca,
                Modelo = veiculoDto.Modelo,
                Tipo = veiculoDto.Tipo,
                HrEntrada = veiculoDto.HrEntrada,
                HrSaida = veiculoDto.HrSaida,
                IdVaga = veiculoDto.IdVaga
            };

            listaRelatorio.Add(relatorio);
            return listaRelatorio;
        }

        public IEnumerable<SaidaEntradaDto> SaidaEntradaDto(EstabelecimentoDto estabelecimentoDto, int entrada, int saida)
        {
            List<SaidaEntradaDto> listaRelatorio = new List<SaidaEntradaDto>();
            var relatorio = new SaidaEntradaDto
            {
                NomeEstabelecimento = estabelecimentoDto.Nome,
                EnderecoEstabelecimento = estabelecimentoDto.Endereco,
                VeiculosEntraram = entrada,
                VeiculosSairam = saida
            };
            listaRelatorio.Add(relatorio);
            return listaRelatorio;
        }

        public IEnumerable<SaidaEntradaHoraDto> SaidaEntradaHoraDto(EstabelecimentoDto estabelecimentoDto, float result)
        {
            List<SaidaEntradaHoraDto> listaRelatorio = new List<SaidaEntradaHoraDto>();
            var relatorio = new SaidaEntradaHoraDto
            {
                NomeEstabelecimento = estabelecimentoDto.Nome,
                EnderecoEstabelecimento = estabelecimentoDto.Endereco,
                VeiculosPorHora = result
            };

            listaRelatorio.Add(relatorio);

            return listaRelatorio;
        }
    }
}