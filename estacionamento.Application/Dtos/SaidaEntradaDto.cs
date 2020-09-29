namespace estacionamento.Application.Dtos
{
    public class SaidaEntradaDto
    {
        public string NomeEstabelecimento { get; set; }

        public string EnderecoEstabelecimento { get; set; }

        public int VeiculosEntraram { get; set; }

        public int VeiculosSairam { get; set; }
    }
}