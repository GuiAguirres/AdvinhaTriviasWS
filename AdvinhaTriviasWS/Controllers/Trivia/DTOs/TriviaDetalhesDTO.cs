using System;

namespace AdvinhaTriviasWS.Controllers.Trivia.DTOs;

public class TriviaDetalheDTO
{
	public long Id { get; set; }
	public string Titulo { get; set; } = string.Empty;
	public string Descricao { get; set; } = string.Empty;
	public DateTimeOffset DataInicio { get; set; }
	public DateTimeOffset? DataFim { get; set; }
    public IEnumerable<PalavraDTO> Palavras { get; set; } = Array.Empty<PalavraDTO>();
}