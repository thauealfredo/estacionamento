using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Application.Dtos
{
    public class VeiculoDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Tipo { get; set; }

        public int IdVaga { get; set; }

        public int IdEstabelecimento { get; set; }

        public DateTime HrEntrada { get; set; }

        public DateTime? HrSaida { get; set; }
    }
}