namespace estacionamento.Domain.Entitys
{
    public class Estabelecimento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CNPJ { get; set; }

        public string Endereco { get; set; }

        public int Telefone { get; set; }
        public int VagaCarro { get; set; }

        public int VagaMoto { get; set; }
    }
}