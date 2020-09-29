using System;
using System.Collections.Generic;
using System.Text;

namespace estacionamento.Application.Dtos
{
    public class SaidaEntradaHoraDto
    {
        public string NomeEstabelecimento { get; set; }

        public string EnderecoEstabelecimento { get; set; }

        public float VeiculosPorHora { get; set; }
    }
}
