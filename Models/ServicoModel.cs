namespace DriveTech.Models
{
	public class ServicoModel
	{
		public int Id { get; set; }
		public string Proprietario { get; set; } = string.Empty;
		public string Placa { get; set; } = string.Empty;
		public string Marca { get; set; } = string.Empty;
		public string Modelo { get; set; } = string.Empty;
		public string Cor { get; set; } = string.Empty;
		public DateOnly Cadastro { get; set; }
		public DateTime Atualizacao { get; set; } = DateTime.Now;
		public string? Observacoes { get; set; } = string.Empty;
		public byte[]? Imagem { get; set; }
		public string TipoImagem { get; set; } = string.Empty;
	}
}
