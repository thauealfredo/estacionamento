using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceVeiculo : IApplicationServiceVeiculo
    {
        private readonly IServiceVeiculo<Veiculo> serviceVeiculo;
        private readonly IMapperVeiculo mapperVeiculo;

        public ApplicationServiceVeiculo(IServiceVeiculo<Veiculo> serviceVeiculo, IMapperVeiculo mapperVeiculo)
        {
            this.serviceVeiculo = serviceVeiculo;
            this.mapperVeiculo = mapperVeiculo;
        }

        public void Add(VeiculoDto veiculoDto)
        {
            // pregando o DTO e covertendo para entidade
            var veiculo = mapperVeiculo.MapperDtoToEntity(veiculoDto);
            serviceVeiculo.Add(veiculo); // adicionando no banco
        }

        public IEnumerable<VeiculoDto> GetAll()
        {
            var veiculos = serviceVeiculo.GetAll();
            return mapperVeiculo.MapperListVeiculosDto(veiculos);
        }

        public VeiculoDto GetById(int id)
        {
            var veiculo = serviceVeiculo.GetById(id);
            return mapperVeiculo.MapperEntityToDto(veiculo);
        }

        public void Remove(int id)
        {
            var veiculo = serviceVeiculo.GetById(id);
            veiculo.HrSaida = DateTime.Now.AddHours(1);
            serviceVeiculo.Update(veiculo);
        }

        public void Update(VeiculoDto veiculoDto)
        {
            var veiculo = mapperVeiculo.MapperDtoToEntity(veiculoDto);
            serviceVeiculo.Update(veiculo);
        }
    }
}