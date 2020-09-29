using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Controllers
{
    [Route("estabelecimento")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class EstabelecimentoController : Controller
    {
        private readonly IApplicationServiceEstabelecimento applicationServiceEstabelecimento;

        public EstabelecimentoController(IApplicationServiceEstabelecimento applicationServiceEstabelecimento)
        {
            this.applicationServiceEstabelecimento = applicationServiceEstabelecimento;
        }

        // GET api/values
        /// <summary>
        /// Lista os estabelecimentos.
        /// </summary>
        [HttpGet()]
        public ActionResult<EstabelecimentoDto> Get()
        {
            return Ok(applicationServiceEstabelecimento.GetAll());
        }

        // GET api/values/byid
        /// <summary>
        /// Retorna o estabelecimento escolhido.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<EstabelecimentoDto> Get(int id)
        {
            return Ok(applicationServiceEstabelecimento.GetById(id));
        }

        // POST api/values
        /// <summary>
        /// Registra novos estabelecimentos.
        /// </summary>
        ///  ///   /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "nome": "EstacioneAq",
        ///        "cnpj": 12345678910111,
        ///        "endereco": "R. Alameda santos, 514 ",
        ///        "telefone": 1334642658,
        ///        "vagaCarro": 80,
        ///        "vagaMoto": 30
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        public ActionResult Post([FromBody] EstabelecimentoDto estabelecimentoDto)
        {
            try
            {
                if (estabelecimentoDto == null)
                    return NotFound();

                applicationServiceEstabelecimento.Add(estabelecimentoDto);
                return Ok("Estabelecimento cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // UPDATE -
        /// <summary>
        /// Atualiza um estabelecimento.
        /// </summary>
        ///   /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "id"
        ///        "nome": "EstacioneAqui"
        ///     }
        ///
        /// </remarks>
        [HttpPut()]
        public ActionResult Put([FromBody] EstabelecimentoDto estabelecimentoDto)
        {
            //var dtoOld = applicationServiceEstabelecimento.GetById(estabelecimentoDto.Id);

            if (estabelecimentoDto.Id == 0)
            {
                return NotFound("Estabelecimento inexistente");
            }

            try
            {
                if (estabelecimentoDto == null)
                    return NotFound();

                applicationServiceEstabelecimento.Update(estabelecimentoDto);
                return Ok("Estabelecimento atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE
        /// <summary>
        /// Apaga um estabelecimento.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var estabelecimentoDto = applicationServiceEstabelecimento.GetById(id);

            try
            {
                if (estabelecimentoDto == null)
                    return NotFound();

                applicationServiceEstabelecimento.Remove(id);
                return Ok("Estabelecimento removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}