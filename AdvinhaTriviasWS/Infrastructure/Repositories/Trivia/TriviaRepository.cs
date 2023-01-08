using System;
using AdvinhaTriviasWS.Domain.Application.Entities.Trivias;
using AdvinhaTriviasWS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdvinhaTriviasWS.Infrastructure.Repositories.Trivia;

public class TriviaRepository
{

	private readonly AppDbContext _dbContext;

	public TriviaRepository(AppDbContext dbContext) =>
		(_dbContext) = (dbContext);

	public async Task<IEnumerable<TriviaEntity>> GetAllTrivias()
	{
		return await _dbContext.Trivias.ToListAsync();
	}

	public async Task<TriviaEntity?> GetTriviaComPalavras(long triviaId) {
		return await _dbContext.Trivias.Include(x => x.Palavras).FirstOrDefaultAsync(x => x.Id == triviaId);
	}

	public async Task<TriviaEntity> AddOrUpdateTrivia(TriviaEntity trivia)
	{
		if (trivia.Id != 0) {
			var t = await this._dbContext.Trivias.FirstOrDefaultAsync(x => x.Id == trivia.Id);
			if (t != null) {
				t.Titulo = trivia.Titulo;
				t.Descricao = trivia.Descricao;
				t.DataInicio = trivia.DataInicio;
				t.DataFim = trivia.DataFim;
				await this._dbContext.SaveChangesAsync();
				return t;
			}
		}
		await this._dbContext.Trivias.AddAsync(trivia);
		await this._dbContext.SaveChangesAsync();
		return trivia;
	}

	public async Task<PalavraEntity> AddPalavra(PalavraEntity palavra)
	{
		if (palavra.Id != 0) {
			var p = await _dbContext.Palavras.FirstOrDefaultAsync(x => x.Id == palavra.Id);
			if (p != null) {
				p.Texto = palavra.Texto;
				p.Ordem = palavra.Ordem;
			}
		}
		await this._dbContext.Palavras.AddAsync(palavra);
		await this._dbContext.SaveChangesAsync();
		return palavra;
	}

    public async Task DeletePalavra(long palavraId)
    {
		await this._dbContext.Palavras.Where(x => x.Id == palavraId).ExecuteDeleteAsync();
        await this._dbContext.SaveChangesAsync();
    }

}