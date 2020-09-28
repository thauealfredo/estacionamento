using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Application.Mappers
{
    public class MapperVeiculo : IMapperVeiculo
    {
        public Veiculo MapperDtoToEntity(VeiculoDto veiculoDto)
        {
            var veiculo = new Veiculo()
            {
                Id = veiculoDto.Id,
                Placa = veiculoDto.Placa,
                Marca = veiculoDto.Marca,
                Modelo = veiculoDto.Modelo,
                Tipo = veiculoDto.Tipo,
                IdEstabelecimento = veiculoDto.IdEstabelecimento,
                IdVaga = veiculoDto.IdVaga,
                HrEntrada = veiculoDto.HrEntrada,
                HrSaida = veiculoDto.HrSaida
            };

            return veiculo;
        }

        public VeiculoDto MapperEntityToDto(Veiculo veiculo)
        {
            var veiculoDto = new VeiculoDto()
            {
                Id = veiculo.Id,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Tipo = veiculo.Tipo,
                IdEstabelecimento = veiculo.IdEstabelecimento,
                IdVaga = veiculo.IdVaga,
                HrEntrada = veiculo.HrEntrada,
                HrSaida = veiculo.HrSaida
            };

            return veiculoDto;
        }

        public IEnumerable<VeiculoDto> MapperListVeiculosDto(IEnumerable<Veiculo> veiculos)
        {
            var dto = veiculos.Select(v => new VeiculoDto
            {
                Id = v.Id,
                Placa = v.Placa,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Tipo = v.Tipo,
                IdEstabelecimento = v.IdEstabelecimento,
                IdVaga = v.IdVaga,
                HrEntrada = v.HrEntrada,
                HrSaida = v.HrSaida,
            });

            return dto;
        }
    }
}