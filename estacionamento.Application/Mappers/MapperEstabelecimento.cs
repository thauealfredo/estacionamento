using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Application.Mappers
{
    public class MapperEstabelecimento : IMapperEstabelecimento
    {
        public Estabelecimento MapperDtoToEntity(EstabelecimentoDto estabelecimentoDto)
        {
            var estabelecimento = new Estabelecimento()
            {
                Id = estabelecimentoDto.Id,
                Nome = estabelecimentoDto.Nome,
                CNPJ = estabelecimentoDto.CNPJ,
                Endereco = estabelecimentoDto.Endereco,
                Telefone = estabelecimentoDto.Telefone,
                VagaCarro = estabelecimentoDto.VagaCarro,
                VagaMoto = estabelecimentoDto.VagaMoto
            };

            return estabelecimento;
        }

        public EstabelecimentoDto MapperEntityToDto(Estabelecimento estabelecimento)
        {
            var estabelecimentoDto = new EstabelecimentoDto()
            {
                Id = estabelecimento.Id,
                Nome = estabelecimento.Nome,
                CNPJ = estabelecimento.CNPJ,
                Endereco = estabelecimento.Endereco,
                Telefone = estabelecimento.Telefone,
                VagaCarro = estabelecimento.VagaCarro,
                VagaMoto = estabelecimento.VagaMoto
            };

            return estabelecimentoDto;
        }

        public IEnumerable<EstabelecimentoDto> MapperListEstabelecimentosDto(IEnumerable<Estabelecimento> estabelecimentos)
        {
            var dto = estabelecimentos.Select(e => new EstabelecimentoDto
            {
                Id = e.Id,
                Nome = e.Nome,
                CNPJ = e.CNPJ,
                Endereco = e.Endereco,
                Telefone = e.Telefone,
                VagaCarro = e.VagaCarro,
                VagaMoto = e.VagaMoto
            });

            return dto;
        }
    }
}