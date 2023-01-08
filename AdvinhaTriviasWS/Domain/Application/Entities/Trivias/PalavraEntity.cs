using System;
namespace AdvinhaTriviasWS.Domain.Application.Entities.Trivias
{
	public class PalavraEntity
	{
		public long Id { get; set; }
		public long TriviaId { get; set; }
		public TriviaEntity Trivia { get; set; } = null!;
		public string Texto { get; set; } = string.Empty;
		public int Ordem { get; set; }
	}
}