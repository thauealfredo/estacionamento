using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Domain.Entitys;
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

            foreach (var veiculoOne in veiculosAll)
            {
                var estabelecimento = applicationServiceEstabelecimento.GetById(veiculoOne.IdEstabelecimento);

                var relatorio = new RelatorioDto
                {
                    NomeEstabelecimento = estabelecimento.Nome,
                    EnderecoEstabelecimento = estabelecimento.Endereco,
                    Placa = veiculoOne.Placa,
                    Marca = veiculoOne.Marca,
                    Modelo = veiculoOne.Modelo,
                    Tipo = veiculoOne.Tipo,
                    HrEntrada = veiculoOne.HrEntrada,
                    HrSaida = veiculoOne.HrSaida,
                    IdVaga = veiculoOne.IdVaga
                };

                listaRelatorio.Add(relatorio);
            }
            return Ok(listaRelatorio);
        }

        [HttpGet("entradaSaida")]
        public ActionResult EntradaSaida()
        {
            var entrada = applicationServiceVeiculo.GetAll();

            var countSaida = 0;
            var countEntrada = 0;
            List<SaidaEntradaDto> listaRelatorio = new List<SaidaEntradaDto>();

            foreach (var item in entrada)
            {
                var estabelecimento = applicationServiceEstabelecimento.GetById(item.IdEstabelecimento);
               

                if (item.IdEstabelecimento > item.IdEstabelecimento + 1)
                {
                    countSaida = 0;
                    countEntrada=0;
                }

                if (item.HrSaida != null)
                {
                    countSaida++;
                    countEntrada++;
                }
                else
                {
                    countEntrada++;
                }

                var relatorio = new SaidaEntradaDto
                {
                    NomeEstabelecimento = estabelecimento.Nome,
                    EnderecoEstabelecimento = estabelecimento.Endereco,
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
            var entrada = applicationServiceVeiculo.GetAll();

            //float hrAtual = DateTime.Now.AddHours(1).Hour;
            float result = 0;
            float count = 0;
            float sum = 0;

            foreach (var item in entrada)
            {
                if (item.HrSaida != null)
                {
                    //veiculos que sairam
                    count++;

                    //quantidade de horas que o veiculo ficou
                    TimeSpan ts = (TimeSpan)(item.HrSaida - item.HrEntrada);

                    var horasTotais = (float)ts.TotalHours;

                    sum = horasTotais + sum;

                    // result = (sum / hrAtual) *count;
                    result = (sum / count);
                }
            }

            return Ok("Média de veiculos por hora: " + result);
        }
    }
}