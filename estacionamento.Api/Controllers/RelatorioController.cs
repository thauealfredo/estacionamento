using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Api.Controllers
{
    [ApiController]
    [Route("relatorio")]
    [Produces("application/json", "application/xml")]
    public class RelatorioController : Controller
    {
        private readonly IApplicationServiceEstabelecimento applicationServiceEstabelecimento;

        private readonly IApplicationServiceVeiculo applicationServiceVeiculo;

        private readonly IApplicationServiceRelatorio applicationServiceRelatorio;

        public RelatorioController(
            IApplicationServiceEstabelecimento applicationServiceEstabelecimento, 
            IApplicationServiceVeiculo applicationServiceVeiculo,
            IApplicationServiceRelatorio applicationServiceRelatorio)
        {
            this.applicationServiceEstabelecimento = applicationServiceEstabelecimento;
            this.applicationServiceVeiculo = applicationServiceVeiculo;
            this.applicationServiceRelatorio = applicationServiceRelatorio;
        }

        /// <summary>
        /// Gera um relatório de todos os veiculos cadastrados.
        /// </summary>
        [HttpGet()]
        public ActionResult<RelatorioDto> Get()
        {
            var veiculosAll = applicationServiceVeiculo.GetAll();
            List<RelatorioDto> relatorioList = new List<RelatorioDto>();

            foreach (var veic in veiculosAll)
            {
                var estabelecimentoOne = applicationServiceEstabelecimento.GetById(veic.IdEstabelecimento);

                var relatorioOne = applicationServiceRelatorio.Relatorio(estabelecimentoOne, veic);

                relatorioList.Add(relatorioOne.Last());
            }
            return Ok(relatorioList);
        }

        /// <summary>
        /// Gera relatório de entrada e saida por estabelecimento.
        /// </summary>
        [HttpGet("entradaSaida")]
        public ActionResult<SaidaEntradaDto> EntradaSaida()
        {
            var entrada = applicationServiceEstabelecimento.GetAll();

            List<SaidaEntradaDto> listaRelatorio = new List<SaidaEntradaDto>();

            foreach (var estab in entrada)
            {
                // lista veiculos pelo id do estabelecimento
                var veiculoOne = applicationServiceVeiculo.GetByIdEstabelecimento(estab.Id);

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

                var relatorioOne = applicationServiceRelatorio.SaidaEntradaDto(estab,countEntrada, countSaida);

                listaRelatorio.Add(relatorioOne.Last());
            }

            return Ok(listaRelatorio);
        }

        /// <summary>
        /// Gera uma média de entrada por hora em cada estabelecimento.
        /// </summary>
        [HttpGet("entradaSaidaHora")]
        public ActionResult<SaidaEntradaHoraDto> EntradaSaidaHora()
        {
            var entrada = applicationServiceEstabelecimento.GetAll();

            List<SaidaEntradaHoraDto> listaRelatorio = new List<SaidaEntradaHoraDto>();

            foreach (var estab in entrada)
            {
                // lista veiculos pelo id do estabelecimento
                var veiculoOne = applicationServiceVeiculo.GetByIdEstabelecimento(estab.Id);

                float result = 0;
                float count = 0; // quantidade de carros
                float sum = 0;

                // para cada veiculo com o mesmo id do estabelecimento
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

                var relatorioOne = applicationServiceRelatorio.SaidaEntradaHoraDto(estab, result);
               
                listaRelatorio.Add(relatorioOne.Last());
            }

            return Ok(listaRelatorio);
        }
    }
}