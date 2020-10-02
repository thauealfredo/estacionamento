using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace estacionamento.Api.Test
{
    public class ServiceVeiculoFake : IApplicationServiceVeiculo
    {
        private List<VeiculoDto> veiculos = new List<VeiculoDto>();

        public ServiceVeiculoFake()
        {
            veiculos = new List<VeiculoDto>()
            {
                new VeiculoDto()

                 {
                        Id = 1,
                        Marca= "MarcaX",
                        Modelo="X-Model",
                        Placa="aaa-1111",
                        Tipo=1,
                        IdVaga =558,
                        IdEstabelecimento=1,
                        HrEntrada = DateTime.Now,
                        HrSaida = DateTime.Now.AddHours(1)
                },

                new VeiculoDto()
                {
                        Id = 2,
                        Marca= "MarcaY",
                        Modelo="Y-Model",
                        Placa="bbb-2222",
                        Tipo=1,
                        IdVaga =658,
                        IdEstabelecimento=2,
                        HrEntrada = DateTime.Now,
                        HrSaida = DateTime.Now.AddHours(1)
                }
            };
        }

        public void Add(VeiculoDto veiculoDto)
        {
            veiculos.Add(veiculoDto);
        }

        public IEnumerable<VeiculoDto> GetAll()
        {
            return veiculos.ToList();
        }

        public VeiculoDto GetById(int id)
        {
            return veiculos.ToList().Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<VeiculoDto> GetByIdEstabelecimento(int id)
        {
            return veiculos.ToList().Where(c => c.IdEstabelecimento == id);
        }

        public void Remove(int id)
        {
            var rm = veiculos.ToList().Where(c => c.Id == id).FirstOrDefault();
            var aux = rm;
            aux.HrSaida = DateTime.Now.AddHours(1);
            veiculos.Remove(rm);
            veiculos.Add(aux);
        }

        public void Update(VeiculoDto VeiculoDto)
        {
            var upd = veiculos.ToList().Where(c => c.Id == VeiculoDto.Id).FirstOrDefault();
            veiculos.Remove(upd);
            veiculos.Add(VeiculoDto);
        }
    }
}