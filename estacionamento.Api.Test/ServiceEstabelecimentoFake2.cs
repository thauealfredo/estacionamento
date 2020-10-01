using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Api.Test
{
    public class ServiceEstabelecimentoFake : IApplicationServiceEstabelecimento
    {
        private List<EstabelecimentoDto> estabelecimentos = new List<EstabelecimentoDto>();

        public ServiceEstabelecimentoFake()
        {
            estabelecimentos = new List<EstabelecimentoDto>()
            {
                new EstabelecimentoDto()

                 {
                        Id = 1,
                        Nome = "EstacioneText",
                        CNPJ = 14660025356548,
                        Endereco = "R. Esmeralda Azul, 555 ",
                        Telefone = 1334642658,
                        VagaCarro = 80,
                        VagaMoto = 30
                },

                new EstabelecimentoDto()
                {
                        Id = 2,
                        Nome = "EstacioneTextTwo",
                        CNPJ = 78956325487512,
                        Endereco = "R. Esmeralda Verde, 456 ",
                        Telefone = 1320356458,
                        VagaCarro = 50,
                        VagaMoto = 40
                }
            };
        }

        public void Add(EstabelecimentoDto estabelecimentoDto)
        {
            estabelecimentos.Add(estabelecimentoDto);
        }

        public IEnumerable<EstabelecimentoDto> GetAll()
        {
            return estabelecimentos.ToList();
        }

        public EstabelecimentoDto GetById(int id)
        {
            return estabelecimentos.ToList().Where(c => c.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var rm = estabelecimentos.ToList().Where(c => c.Id == id).FirstOrDefault();
            estabelecimentos.Remove(rm);
        }

        public void Update(EstabelecimentoDto estabelecimentoDto)
        {
            var upd = estabelecimentos.ToList().Where(c => c.Id == estabelecimentoDto.Id).FirstOrDefault();
            estabelecimentos.Remove(upd);
            estabelecimentos.Add(estabelecimentoDto);
        }
    }
}