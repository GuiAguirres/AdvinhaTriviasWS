using System;
using AdvinhaTriviasWS.Controllers.Trivia.DTOs;
using AdvinhaTriviasWS.Infrastructure.Repositories.Trivia;

namespace AdvinhaTriviasWS.Domain.Application.Services;

public class TriviaService
{

	private readonly TriviaRepository _triviaRepository;

	public TriviaService(TriviaRepository triviaRepository) =>
		(_triviaRepository) = (triviaRepository);

	public async Task<IEnumerable<TriviaDTO>> GetAllTrivias()
	{
		var trivias = await _triviaRepository.GetAllTrivias();

		//if (trivias.Count() == 0)
		//	throw new HttpRequestException("Nenhuma trivia encontrada", null, System.Net.HttpStatusCode.NotFound);

		return trivias.Select(t => new TriviaDTO
		{
			Id = t.Id,
			Titulo = t.Titulo,
			Descricao = t.Descricao,
			DataInicio = t.DataInicio,
			DataFim = t.DataFim
		});
	}

	public async Task<TriviaDetalheDTO> Get(long id)
	{
		var trivia = await _triviaRepository.GetTriviaComPalavras(id);

		if (trivia == null)
			throw new HttpRequestException("Trivia não encontrada", null, System.Net.HttpStatusCode.NotFound);

		return new TriviaDetalheDTO
		{
			Id = trivia.Id,
			Titulo = trivia.Titulo,
			Descricao = trivia.Descricao,
			DataInicio = trivia.DataInicio,
			DataFim = trivia.DataFim,
			Palavras = trivia.Palavras.OrderBy(x => x.Texto).Select(p => new PalavraDTO
			{
				Id = p.Id,
				Texto = p.Texto
			})
		};
	}

	public async Task<TriviaDTO> Post(TriviaDTO trivia) {
		var t = await _triviaRepository.AddOrUpdateTrivia(new Entities.Trivias.TriviaEntity {
			Id = trivia.Id,
			Titulo = trivia.Titulo,
			Descricao = trivia.Descricao,
			DataInicio = trivia.DataInicio,
			DataFim = trivia.DataFim
		});
		return new TriviaDTO
		{
			Id = t.Id,
			Titulo = t.Titulo,
			Descricao = t.Descricao,
			DataInicio = t.DataInicio,
			DataFim = t.DataFim
		};
	}

	public async Task<PalavraDTO> PostWord(long triviaId, PalavraDTO p) {
		var w = await _triviaRepository.AddPalavra(new Entities.Trivias.PalavraEntity {
			Id = p.Id,
			TriviaId = triviaId,
			Texto = p.Texto,
			Ordem = 0
		});
		return new PalavraDTO {
			Id = w.Id,
			Texto = w.Texto
		};
	}

	public async Task DeleteWord(long palavraId) =>
		await _triviaRepository.DeletePalavra(palavraId);

}