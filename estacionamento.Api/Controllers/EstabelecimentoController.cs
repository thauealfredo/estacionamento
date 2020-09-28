using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Controllers
{
    [Route("estabelecimento")]
    [ApiController]
    public class EstabelecimentoController : Controller
    {
        private readonly IApplicationServiceEstabelecimento applicationServiceEstabelecimento;

        public EstabelecimentoController(IApplicationServiceEstabelecimento applicationServiceEstabelecimento)
        {
            this.applicationServiceEstabelecimento = applicationServiceEstabelecimento;
        }

        // GET api/values
        [HttpGet()]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceEstabelecimento.GetAll());
        }

        // GET api/values/byid
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceEstabelecimento.GetById(id));
        }

        // POST api/values
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

        // DELETE api/values/5
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