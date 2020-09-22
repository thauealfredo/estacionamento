using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Entitys;
using System;
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
                Placa = veiculoDto.Placa,
                Marca = veiculoDto.Marca,
                Modelo = veiculoDto.Modelo,
                Tipo = veiculoDto.Tipo,
                HrEntrada = veiculoDto.HrEntrada,
                HrSaida = veiculoDto.HrSaida,
                IdEstabelecimento = veiculoDto.IdEstabelecimento,
                IdVaga = veiculoDto.IdVaga
            };

            return veiculo;
        }

        public VeiculoDto MapperEntityToDto(Veiculo veiculo)
        {
            var veiculoDto = new VeiculoDto()
            {
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Tipo = veiculo.Tipo,
                HrEntrada = veiculo.HrEntrada,
                HrSaida = veiculo.HrSaida,
                IdEstabelecimento = veiculo.IdEstabelecimento,
                IdVaga = veiculo.IdVaga
            };

            return veiculoDto;
        }

        public IEnumerable<VeiculoDto> MapperListVeiculosDto(IEnumerable<Veiculo> veiculos)
        {
            var dto = veiculos.Select(v => new VeiculoDto 
            {
                Placa = v.Placa,
                Marca = v.Marca,
                Modelo = v.Modelo,
                Tipo = v.Tipo,
                HrEntrada = v.HrEntrada,
                HrSaida = v.HrSaida,
                IdEstabelecimento = v.IdEstabelecimento,
                IdVaga = v.IdVaga
            });

            return dto;
        }
    }
}