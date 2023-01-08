using System;

namespace AdvinhaTriviasWS.Domain.Application.Entities.Trivias;

public class TriviaEntity
{
	public long Id { get; set; }
	public string Titulo { get; set; } = string.Empty;
	public string Descricao { get; set; } = string.Empty;
	public DateTimeOffset DataInicio { get; set; } = DateTimeOffset.UtcNow;
	public DateTimeOffset? DataFim { get; set; }

	public IList<PalavraEntity> Palavras { get; set; } = new List<PalavraEntity>();
}