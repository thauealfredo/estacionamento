using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace estacionamento.Api.Controllers
{
    [Route("veiculo")]
    [ApiController]
    public class VeiculoController : Controller
    {
        private readonly IApplicationServiceVeiculo applicationServiceVeiculo;

        public VeiculoController(IApplicationServiceVeiculo applicationServiceVeiculo)
        {
            this.applicationServiceVeiculo = applicationServiceVeiculo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceVeiculo.GetAll());
        }

        // GET api/values/byid
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceVeiculo.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] VeiculoDto veiculoDto)
        {
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

        // UPDATE -> PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                if (veiculoDto == null)
                    return NotFound();

                applicationServiceVeiculo.Update(veiculoDto);
                return Ok("Veiculo atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] VeiculoDto veiculoDto)
        {
            try
            {
                if (veiculoDto == null)
                    return NotFound();

                applicationServiceVeiculo.Remove(veiculoDto);
                return Ok("Veiculo removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}