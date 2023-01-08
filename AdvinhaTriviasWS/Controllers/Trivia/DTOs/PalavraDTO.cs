using System;

namespace AdvinhaTriviasWS.Controllers.Trivia.DTOs;

public class PalavraDTO
{
	public long Id { get; set; }
	public string Texto { get; set; } = string.Empty;
}