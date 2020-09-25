using estacionamento.Application.Interfaces;
using estacionamento.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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

            List<Relatorio> listaRelatorio = new List<Relatorio>();

            foreach (var item in veiculosAll)
            {
                    var veiculoOne = applicationServiceVeiculo.GetById(item.Id);
                    var estabelecimento = applicationServiceEstabelecimento.GetById(item.IdEstabelecimento);

                var relatorio = new Relatorio
                {
                    Nome = estabelecimento.Nome,
                    Endereco = estabelecimento.Endereco,
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

            var count = 0;

            foreach (var item in entrada)
            {
                if (item.HrSaida != null)
                {
                    count++;
                }
            }

            return Ok("Veiculos contabilizados: "+count);
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