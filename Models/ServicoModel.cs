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
		public DateTime Cadastro { get; set; } = DateTime.Now;
		public string? Observacoes { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
        public decimal? Valor { get; set; }
		public bool Alerta { get; set; } = false;
		public string? MensagemAlerta { get; set; } = string.Empty;
    }
}
