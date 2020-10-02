using AutoMapper;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceEstabelecimento : IApplicationServiceEstabelecimento
    {
        private readonly IServiceEstabelecimento serviceEstabelecimento;
        private IMapper mapper;

        public ApplicationServiceEstabelecimento(IServiceEstabelecimento serviceEstabelecimento, IMapper mapper)
        {
            this.serviceEstabelecimento = serviceEstabelecimento;
            this.mapper = mapper;
        }

        public void Add(EstabelecimentoDto estabelecimentoDto)
        {
            // pregando o DTO e covertendo para entidade

            var map = mapper.Map<Estabelecimento>(estabelecimentoDto);
            serviceEstabelecimento.Add(map); // adicionando no banco
        }

        public IEnumerable<EstabelecimentoDto> GetAll()
        {
            var estabelecimentos = serviceEstabelecimento.GetAll();
            return mapper.Map<List<EstabelecimentoDto>>(estabelecimentos);
        }

        public EstabelecimentoDto GetById(int id)
        {
            var estabelecimento = serviceEstabelecimento.GetById(id);
            return mapper.Map<EstabelecimentoDto>(estabelecimento);
        }

        public void Remove(int id)
        {
            var estabelecimento = serviceEstabelecimento.GetById(id);
            serviceEstabelecimento.Remove(estabelecimento);
        }

        public void Update(EstabelecimentoDto estabelecimentoDto)
        {
            var estabOld = serviceEstabelecimento.GetById(estabelecimentoDto.Id);

            var estabelecimento = mapper.Map<Estabelecimento>(estabelecimentoDto);

            if (estabelecimento.Nome == null)
            {
                estabelecimento.Nome = estabOld.Nome;
            }
            if (estabelecimento.Endereco == null)
            {
                estabelecimento.Endereco = estabOld.Endereco;
            }
            if (estabelecimento.CNPJ == 0)
            {
                estabelecimento.CNPJ = estabOld.CNPJ;
            }
            if (estabelecimento.Telefone == 0)
            {
                estabelecimento.Telefone = estabOld.Telefone;
            }

            if (estabelecimento.VagaCarro == 0)
            {
                estabelecimento.VagaCarro = estabOld.VagaCarro;
            }

            if (estabelecimento.VagaMoto == 0)
            {
                estabelecimento.VagaMoto = estabOld.VagaMoto;
            }

            serviceEstabelecimento.Update(estabelecimento);
        }
    }
}