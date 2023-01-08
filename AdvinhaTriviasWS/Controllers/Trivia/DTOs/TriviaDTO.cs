using System;

namespace AdvinhaTriviasWS.Controllers.Trivia.DTOs;

public class TriviaDTO
{
	public long Id { get; set; }
	public string Titulo { get; set; } = string.Empty;
	public string Descricao { get; set; } = string.Empty;
	public DateTimeOffset DataInicio { get; set; } = DateTimeOffset.Now;
	public DateTimeOffset? DataFim { get; set; }
}