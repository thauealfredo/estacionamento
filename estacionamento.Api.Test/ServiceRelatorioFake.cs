using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Api.Test
{
    public class ServiceRelatorioFake : IApplicationServiceRelatorio
    {
        private List<RelatorioDto> relatorio = new List<RelatorioDto>();
        private List<SaidaEntradaDto> saidaEntrada = new List<SaidaEntradaDto>();
        private List<SaidaEntradaHoraDto> saidaEntradaHora = new List<SaidaEntradaHoraDto>();

        public IEnumerable<RelatorioDto> Relatorio(EstabelecimentoDto estabelecimentoDto, VeiculoDto veiculoDto)
        {
            relatorio = new List<RelatorioDto>()
            {
               new RelatorioDto()
            {
                NomeEstabelecimento = "EstabelecimentoTxt",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 854",
                Placa = "hhh-7895",
                Marca = "H-Marca",
                Modelo = "H-788",
                Tipo = 1,
                IdVaga = 448,
                HrEntrada = DateTime.Now,
                HrSaida = DateTime.Now.AddHours(1)
              },
                new RelatorioDto()
            {
                NomeEstabelecimento = "EstabelecimentoTxT",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 854",
                Placa = "kkk-2367",
                Marca = "K-Marca",
                Modelo = "K-99",
                Tipo = 2,
                IdVaga = 228,
                HrEntrada = DateTime.Now,
                HrSaida = DateTime.Now.AddHours(1)
              },
                 new RelatorioDto()
            {
                NomeEstabelecimento = "EstabelecimentoXXX",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 154",
                Placa = "ppp-7895",
                Marca = "P-Marca",
                Modelo = "P-90",
                Tipo = 1,
                IdVaga = 48,
                HrEntrada = DateTime.Now,
                HrSaida = DateTime.Now.AddHours(1)
              }
            };

            return relatorio.ToList();
        }

        public IEnumerable<SaidaEntradaDto> SaidaEntradaDto(EstabelecimentoDto estabelecimentoDto, int entrada, int saida)
        {
            saidaEntrada = new List<SaidaEntradaDto>()
            {
               new SaidaEntradaDto()
            {
                NomeEstabelecimento = "EstabelecimentoTxt",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 854",
                VeiculosEntraram = 3,
                VeiculosSairam = 3,
              },
                new SaidaEntradaDto()
            {
                NomeEstabelecimento = "EstabelecimentoXXX",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 154",
                VeiculosEntraram =1,
                VeiculosSairam = 1
              }
            };

            return saidaEntrada.ToList();
        }

        public IEnumerable<SaidaEntradaHoraDto> SaidaEntradaHoraDto(EstabelecimentoDto estabelecimentoDto, float result)
        {
            saidaEntradaHora = new List<SaidaEntradaHoraDto>()
            {
               new SaidaEntradaHoraDto()
            {
                NomeEstabelecimento = "EstabelecimentoTxt",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 854",
               VeiculosPorHora=1
              },
                new SaidaEntradaHoraDto()
            {
                NomeEstabelecimento = "EstabelecimentoXXX",
                EnderecoEstabelecimento = "Rua Rubi Vermelho, 154",
                VeiculosPorHora = 1,
              }
            };

            return saidaEntradaHora.ToList();
        }
    }
}