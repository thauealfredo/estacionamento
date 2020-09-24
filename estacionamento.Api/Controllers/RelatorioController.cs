using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
            // pega todos estabelecimentos
            var esta = applicationServiceEstabelecimento.GetAll();

            // pega todos os veiculos
            var vx = applicationServiceVeiculo.GetAll();

            List<VeiculoDto> lista = new List<VeiculoDto>();
            List<EstabelecimentoDto> list = new List<EstabelecimentoDto>();


            foreach (var item in vx)
            {
                var estab = applicationServiceEstabelecimento.GetById(item.IdEstabelecimento);

                //pega veiculo de cada estabelecimento
                var veic = applicationServiceVeiculo.GetById(item.IdEstabelecimento);

            }

            return Ok();
        }
    }
}