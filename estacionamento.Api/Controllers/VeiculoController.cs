using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Controllers
{
    [Route("veiculo")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class VeiculoController : Controller
    {
        private readonly IApplicationServiceVeiculo applicationServiceVeiculo;
        private readonly IApplicationServiceEstabelecimento applicationServiceEstabelecimento;

        public VeiculoController(IApplicationServiceVeiculo applicationServiceVeiculo, IApplicationServiceEstabelecimento applicationServiceEstabelecimento)
        {
            this.applicationServiceVeiculo = applicationServiceVeiculo;
            this.applicationServiceEstabelecimento = applicationServiceEstabelecimento;
        }

        // GET
        /// <summary>
        /// Lista todos os veiculos cadastrados.
        /// </summary>
        [HttpGet]
        public ActionResult<VeiculoDto> Get()
        {
            return Ok(applicationServiceVeiculo.GetAll());
        }

        // GET
        /// <summary>
        /// Retorna um veiculo especifico
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<VeiculoDto> Get(int id)
        {
            return Ok(applicationServiceVeiculo.GetById(id));
        }

        // POST
        /// <summary>
        /// Registra um novo veiculo.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     ##Tipo 1 = carro;
        ///     ##Tipo 2 = moto;
        ///     {
        ///        "placa": "abc-2586",
        ///        "marca": "audi",
        ///        "modelo": "a5",
        ///        "tipo": 1,
        ///        "idVaga": 38,
        ///        "idEstabelecimento": 1
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public ActionResult Post([FromBody] VeiculoDto veiculoDto)
        {
            var estabelecimento = applicationServiceEstabelecimento.GetById(veiculoDto.IdEstabelecimento);

            if (estabelecimento.Id == 0)
            {
                return NotFound("Estabelecimento não encontrado");
            }

            try
            {
                if (veiculoDto == null)
                    return NotFound();

                applicationServiceVeiculo.Add(veiculoDto);
                return Ok("Veiculo cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // UPDATE ->
        /// <summary>
        /// Atualiza um veiculo
        /// </summary>
        ///   /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "id": 1,
        ///        "marca": "citroen",
        ///        "modelo": "c3"
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        public ActionResult Put([FromBody] VeiculoDto veiculoDto)
        {
            if (veiculoDto.Id == 0)
            {
                return NotFound("Veiculo inexistente");
            }

            try
            {
                if (veiculoDto == null)
                    return NotFound();

                var id = veiculoDto.Id;

                applicationServiceVeiculo.Update(veiculoDto);
                return Ok("Veiculo atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE
        /// <summary>
        /// Efetua a saida do veiculo do estabelecimento.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            applicationServiceVeiculo.Remove(id);
            return Ok("Veiculo removido com sucesso!");
        }
    }
}