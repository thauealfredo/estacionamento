using estacionamento.Api.Controllers;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace estacionamento.Api.Test
{
    public class EstabelecimentoControllerTest
    {
        private EstabelecimentoController _controller;
        private IApplicationServiceEstabelecimento _service;

        public EstabelecimentoControllerTest()
        {
            _service = new ServiceEstabelecimentoFake();
            _controller = new EstabelecimentoController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllEstablishments()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAValidEstablishment()
        {
            // Act
            var okResult = _controller.Get(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }


        [Theory]
        [InlineData(0)]
        public void Get_WhenCalled_ReturnsAnIValidEstablishment(int id)
        {
            // Act
            var notFResult = _controller.Get(id);
            // Assert
            Assert.IsType<OkObjectResult>(notFResult.Result);
        }


        [Fact]
        public void Post_WhenCalled_AddNewEstablishment()
        {
            // Act

            List<EstabelecimentoDto> dtos = new List<EstabelecimentoDto>();

            var dto = new EstabelecimentoDto
            {
                Id = 1,
                Nome = "tesxt Texc",
                CNPJ = 12345678912356,
                Telefone = 1336656476,
                Endereco = "rua test",
                VagaCarro = 35,
                VagaMoto = 55
            };


            var okResult = _controller.Post(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(1)]
        public void Put_WhenCalled_UpdateAEstablishmentIsValid(int id)
        {
            // Act

            List<EstabelecimentoDto> dtos = new List<EstabelecimentoDto>();

            var dto = new EstabelecimentoDto
            {
                Id = id,
                Nome = " Texc azul"
            };

            var okResult = _controller.Put(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(0)]
        public void Put_WhenCalled_UpdateAEstablishmentIsNotValid(int id)
        {
            // Act

            List<EstabelecimentoDto> dtos = new List<EstabelecimentoDto>();

            var dto = new EstabelecimentoDto
            {
                Id = id,
                Nome = " Texc azul"
            };

            var notFResult = _controller.Put(dto);
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFResult);
        }


        [Theory]
        [InlineData(1)]
        public void Delete_WhenCalled_DeleteAValidEstablishment(int id)
        {
            // Act
            var okResult = _controller.Delete(id);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Theory]
        [InlineData(0)]
        public void Delete_WhenCalled_DeleteAnInvalidEstablishment(int id)
        {
            // Act
            var Result = _controller.Delete(id);
            // Assert
            Assert.IsType<NotFoundResult>(Result);
        }
    }
}