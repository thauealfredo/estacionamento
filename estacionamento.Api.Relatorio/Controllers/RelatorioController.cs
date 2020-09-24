using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace estacionamento.Api.Relatorio.Controllers
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
        public IActionResult Index()
        {
            var esta = applicationServiceEstabelecimento.GetAll();
            foreach (var item in esta)
            {
              var veic =  applicationServiceVeiculo.GetById(item.Id);
            }
            
            return View();
        }
    }
}