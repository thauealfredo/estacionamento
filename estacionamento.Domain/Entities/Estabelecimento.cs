using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace estacionamento.Domain.Entitys
{
    public class Estabelecimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public long CNPJ { get; set; }

        public string Endereco { get; set; }

        public int Telefone { get; set; }
        public int VagaCarro { get; set; }

        public int VagaMoto { get; set; }
    }
}