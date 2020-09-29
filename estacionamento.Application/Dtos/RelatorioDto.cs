using System;

namespace estacionamento.Application.Dtos
{
    public class RelatorioDto
    {
        public string NomeEstabelecimento { get; set; }

        public string EnderecoEstabelecimento { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Tipo { get; set; }

        public int IdVaga { get; set; }

        public DateTime HrEntrada { get; set; }

        public DateTime? HrSaida { get; set; }
    }
}