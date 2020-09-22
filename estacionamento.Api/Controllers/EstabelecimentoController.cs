using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
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

        // UPDATE -> PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] EstabelecimentoDto estabelecimentoDto)
        {
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
        [HttpDelete()]
        public ActionResult Delete([FromBody] EstabelecimentoDto estabelecimentoDto)
        {
            try
            {
                if (estabelecimentoDto == null)
                    return NotFound();

                applicationServiceEstabelecimento.Remove(estabelecimentoDto);
                return Ok("Estabelecimento removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
