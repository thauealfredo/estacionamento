using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace estacionamento.Application
{
    public class ApplicationServiceVeiculo : IApplicationServiceVeiculo
    {
        private readonly IServiceVeiculo serviceVeiculo;
        private readonly IMapperVeiculo mapperVeiculo;

        public ApplicationServiceVeiculo(IServiceVeiculo serviceVeiculo, IMapperVeiculo mapperVeiculo)
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

        public IEnumerable<VeiculoDto> GetByIdEstabelecimento(int id)
        {
            var veiculos = serviceVeiculo.GetByIdEstabelecimento(id);
            return mapperVeiculo.MapperListVeiculosDto(veiculos);
        }

        public void Remove(int id)
        {
            var veiculo = serviceVeiculo.GetById(id);
            veiculo.HrSaida = DateTime.Now.AddHours(1);
            serviceVeiculo.Update(veiculo);
        }

        public void Update(VeiculoDto veiculoDto)
        {
            // var veicOld = serviceVeiculo.GetById(veiculoDto.Id);

            /// dados atuais
            var veiculo = mapperVeiculo.MapperDtoToEntity(veiculoDto);

            //if (veiculo.Placa == null)
            //{
            //    veiculo.Placa = veicOld.Placa;
            //}
            //if (veiculo.Marca == null)
            //{
            //    veiculo.Marca = veicOld.Marca;
            //}
            //if (veiculo.Modelo == null)
            //{
            //    veiculo.Modelo = veicOld.Modelo;
            //}

            //if (veiculo.Tipo == 0)
            //{
            //    veiculo.Tipo = veicOld.Tipo;
            //}

            //if (veiculo.IdVaga == 0)
            //{
            //    veiculo.IdVaga = veicOld.IdVaga;
            //}

            //if (veiculo.IdEstabelecimento == 0)
            //{
            //    veiculo.IdEstabelecimento = veicOld.IdEstabelecimento;
            //}

            serviceVeiculo.Update(veiculo);
        }
    }
}