using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceEstabelecimento : IApplicationServiceEstabelecimento
    {
        private readonly IServiceEstabelecimento serviceEstabelecimento;
        private readonly IMapperEstabelecimento mapperEstabelecimento;

        public ApplicationServiceEstabelecimento(IServiceEstabelecimento serviceEstabelecimento, IMapperEstabelecimento mapperEstabelecimento)
        {
            this.serviceEstabelecimento = serviceEstabelecimento;
            this.mapperEstabelecimento = mapperEstabelecimento;
        }

        public void Add(EstabelecimentoDto estabelecimentoDto)
        {
            // pregando o DTO e covertendo para entidade
            var estabelecimento = mapperEstabelecimento.MapperDtoToEntity(estabelecimentoDto);
            serviceEstabelecimento.Add(estabelecimento); // adicionando no banco
        }

        public IEnumerable<EstabelecimentoDto> GetAll()
        {
            var estabelecimentos = serviceEstabelecimento.GetAll();

            return mapperEstabelecimento.MapperListEstabelecimentosDto(estabelecimentos);
        }

        public EstabelecimentoDto GetById(int id)
        {
            var estabelecimento = serviceEstabelecimento.GetById(id);
            return mapperEstabelecimento.MapperEntityToDto(estabelecimento);
        }

        public void Remove(int id)
        {
            var estabelecimento = serviceEstabelecimento.GetById(id);
            serviceEstabelecimento.Remove(estabelecimento);
        }

        public void Update(EstabelecimentoDto estabelecimentoDto)
        {
            var estabOld = serviceEstabelecimento.GetById(estabelecimentoDto.Id);

            var estabelecimento = mapperEstabelecimento.MapperDtoToEntity(estabelecimentoDto);

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