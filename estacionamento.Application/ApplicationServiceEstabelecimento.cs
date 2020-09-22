using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceEstabelecimento : IApplicationServiceEstabelecimento
    {
        private readonly IServiceEstabelecimento<Estabelecimento> serviceEstabelecimento;
        private readonly IMapperEstabelecimento mapperEstabelecimento;

        public ApplicationServiceEstabelecimento(IServiceEstabelecimento<Estabelecimento> serviceEstabelecimento, IMapperEstabelecimento mapperEstabelecimento)
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

        public EstabelecimentoDto GetByid(int id)
        {
            var estabelecimento = serviceEstabelecimento.GetById(id);
            return mapperEstabelecimento.MapperEntityToDto(estabelecimento);
        }

        public void Remove(EstabelecimentoDto estabelecimentoDto)
        {
            var estabelecimento = mapperEstabelecimento.MapperDtoToEntity(estabelecimentoDto);
            serviceEstabelecimento.Remove(estabelecimento);
        }

        public void Update(EstabelecimentoDto estabelecimentoDto)
        {
            var estabelecimento = mapperEstabelecimento.MapperDtoToEntity(estabelecimentoDto);
            serviceEstabelecimento.Update(estabelecimento);
        }
    }
}