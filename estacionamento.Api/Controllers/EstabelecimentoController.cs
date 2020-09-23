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

        // UPDATE -> PUT api/values/5
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

                //if (estabelecimentoDto.Nome == null)
                //{
                //    estabelecimentoDto.Nome = dtoOld.Nome;
                //}
                //else if (estabelecimentoDto.CNPJ == 0)
                //{
                //    estabelecimentoDto.CNPJ = dtoOld.CNPJ;
                //}
                //else if (estabelecimentoDto.Endereco == null)
                //{
                //    estabelecimentoDto.Endereco = dtoOld.Endereco;
                //}
                //else if (estabelecimentoDto.Telefone == 0)
                //{
                //    estabelecimentoDto.Telefone = dtoOld.Telefone;
                //}
                //else if (estabelecimentoDto.VagaCarro == 0)
                //{
                //    estabelecimentoDto.VagaCarro = dtoOld.VagaCarro;
                //}
                //else if (estabelecimentoDto.VagaMoto == 0)
                //{
                //    estabelecimentoDto.VagaMoto = dtoOld.VagaMoto;
                //}

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