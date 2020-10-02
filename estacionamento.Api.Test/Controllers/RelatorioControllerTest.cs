using estacionamento.Api.Controllers;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace estacionamento.Api.Test.Controllers
{
    public class RelatorioControllerTest
    {
        private RelatorioController _controller;
        private IApplicationServiceRelatorio _service;
        private IApplicationServiceEstabelecimento _serviceEstab;
        private IApplicationServiceVeiculo _serviceVeic;

        public RelatorioControllerTest()
        {
            _service = new ServiceRelatorioFake();
            _serviceVeic = new ServiceVeiculoFake();
            _serviceEstab = new ServiceEstabelecimentoFake();
            _controller = new RelatorioController(_serviceEstab, _serviceVeic, _service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsCompletedReport()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsANSummaryOfEntranceAndExit()
        {
            // Act
            var okResult = _controller.EntradaSaida();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsANSummaryOfEntranceAndExitPerHour()
        {
            // Act
            var okResult = _controller.EntradaSaidaHora();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ChecksWhetherAllVehiclesHaveLeft()
        {
            var okResult = _controller.EntradaSaida().Result as OkObjectResult;

            // Assert
            var list = Assert.IsType<List<SaidaEntradaDto>>(okResult.Value);
            foreach (var it in list)
            {
                Assert.Equal(it.VeiculosEntraram, it.VeiculosSairam);
            }
        }

        [Fact]
        public void Get_WhenCalled_ChecksIfTheNumberOfVehiclesThatLeftTheParkingLotIsGreaterThan0()
        {
            var okResult = _controller.EntradaSaidaHora().Result as OkObjectResult;

            // Assert
            var list = Assert.IsType<List<SaidaEntradaHoraDto>>(okResult.Value);
            foreach (var it in list)
            {
                Assert.True(it.VeiculosPorHora > 0);
            }
        }
    }
}