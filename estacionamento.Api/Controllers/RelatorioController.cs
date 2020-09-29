using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Controllers
{
    [ApiController]
    [Route("relatorio")]
    public class RelatorioController : Controller
    {
        private readonly IApplicationServiceEstabelecimento applicationServiceEstabelecimento;

        private readonly IApplicationServiceVeiculo applicationServiceVeiculo;

        public RelatorioController(IApplicationServiceEstabelecimento applicationServiceEstabelecimento, IApplicationServiceVeiculo applicationServiceVeiculo)
        {
            this.applicationServiceEstabelecimento = applicationServiceEstabelecimento;
            this.applicationServiceVeiculo = applicationServiceVeiculo;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            var veiculosAll = applicationServiceVeiculo.GetAll();

            List<RelatorioDto> listaRelatorio = new List<RelatorioDto>();

            foreach (var veic in veiculosAll)
            {
                var estabelecimentoOne = applicationServiceEstabelecimento.GetById(veic.IdEstabelecimento);

                var relatorio = new RelatorioDto
                {
                    NomeEstabelecimento = estabelecimentoOne.Nome,
                    EnderecoEstabelecimento = estabelecimentoOne.Endereco,
                    Placa = veic.Placa,
                    Marca = veic.Marca,
                    Modelo = veic.Modelo,
                    Tipo = veic.Tipo,
                    HrEntrada = veic.HrEntrada,
                    HrSaida = veic.HrSaida,
                    IdVaga = veic.IdVaga
                };

                listaRelatorio.Add(relatorio);
            }
            return Ok(listaRelatorio);
        }

        [HttpGet("entradaSaida")]
        public ActionResult EntradaSaida()
        {
            var entrada = applicationServiceEstabelecimento.GetAll();

            List<SaidaEntradaDto> listaRelatorio = new List<SaidaEntradaDto>();

            foreach (var item in entrada)
            {
                /// lista veiculos pelo id do estabelecimento
                var veiculoOne = applicationServiceVeiculo.GetByIdEstabelecimento(item.Id);

                var countSaida = 0;
                var countEntrada = 0;

                foreach (var it in veiculoOne)
                {
                    if (it.HrSaida != null)
                    {
                        countSaida++;
                        countEntrada++;
                    }
                    else
                    {
                        countEntrada++;
                    }
                }

                var relatorio = new SaidaEntradaDto
                {
                    NomeEstabelecimento = item.Nome,
                    EnderecoEstabelecimento = item.Endereco,
                    VeiculosEntraram = countEntrada,
                    VeiculosSairam = countSaida
                };

                listaRelatorio.Add(relatorio);
            }

            return Ok(listaRelatorio);
        }

        [HttpGet("entradaSaidaHora")]
        public ActionResult EntradaSaidaHora()
        {
            var entrada = applicationServiceEstabelecimento.GetAll();

            List<SaidaEntradaHoraDto> listaRelatorio = new List<SaidaEntradaHoraDto>();

            foreach (var item in entrada)
            {
                /// lista veiculos pelo id do estabelecimento
                var veiculoOne = applicationServiceVeiculo.GetByIdEstabelecimento(item.Id);

                float result = 0;
                float count = 0; // quantidade de carros
                float sum = 0;

                /// para cada veiculo com o mesmo id do estabelecimento
                foreach (var it in veiculoOne)
                {
                    if (it.HrSaida != null)
                    {
                        TimeSpan ts = (TimeSpan)(it.HrSaida - it.HrEntrada);
                        var horasTotais = (int)ts.TotalHours;
                        sum = horasTotais + sum;
                        count++;
                        result = (sum / count);
                    }
                }

                var relatorio = new SaidaEntradaHoraDto
                {
                    NomeEstabelecimento = item.Nome,
                    EnderecoEstabelecimento = item.Endereco,
                    VeiculosPorHora = result
                };
                listaRelatorio.Add(relatorio);
            }

            return Ok(listaRelatorio);
        }
    }
}