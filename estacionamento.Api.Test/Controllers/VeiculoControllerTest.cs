using estacionamento.Api.Controllers;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace estacionamento.Api.Test
{
    public class VeiculoControllerTest
    {
        private VeiculoController _controller;
        private IApplicationServiceVeiculo _service;

        public VeiculoControllerTest()
        {
            _service = new ServiceVeiculoFake();
            _controller = new VeiculoController(_service, null);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(2)]
        public void Get_WhenCalled_ReturnsAllVehicles(int id)
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<VeiculoDto>>(okResult.Value);
            Assert.Equal(id, items.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Get_WhenCalled_ReturnsOneVehicle(int id)
        {
            // Act
            var okResult = _controller.Get(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Get_WhenCalled_ReturnsAllVehicleByEstablishment(int id)
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<VeiculoDto>>(okResult.Value);

            items.ToList().Where(c => c.IdEstabelecimento == id);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Post_WhenCalled_AddNewVehicle()
        {
            // Act

            var dto = new VeiculoDto
            {
                Id =1,
                Marca = "MarcaX",
                Modelo = "Z-Model",
                Placa = "ccc-3333",
                Tipo = 1,
                IdVaga = 558,
                IdEstabelecimento = 1,
                HrEntrada = DateTime.Now,
                HrSaida = DateTime.Now.AddHours(1)
            };

            var okResult = _controller.Post(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Put_WhenCalled_UpdateAVehicle(int id)
        {
            // Act

            List<EstabelecimentoDto> dtos = new List<EstabelecimentoDto>();

            var dto = new VeiculoDto
            {
                Id = id,
                Marca = "V- Marc"
            };

            var okResult = _controller.Put(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Delete_WhenCalled_DeleteAVehicle(int id)
        {
            // Act
            var okResult = _controller.Delete(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }


        [Theory]
        [InlineData(1)]
        public void Delete_WhenCalled_DeleteAVehicleAndVerifyExitTime(int id)
        {
            // Act
            _controller.Delete(id);
            var getVehicle = _controller.Get(id).Result as OkObjectResult;

            // Assert
            Assert.IsType<OkObjectResult>(getVehicle);
        }
    }
}
