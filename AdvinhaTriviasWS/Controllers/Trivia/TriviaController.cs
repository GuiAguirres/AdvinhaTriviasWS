using AdvinhaTriviasWS.Controllers.Trivia.DTOs;
using AdvinhaTriviasWS.Domain.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvinhaTriviasWS.Controllers.Trivia;

[ApiController]
[Route("[controller]/v{version:apiVersion}")]
[ApiVersion("1.0")]
public class TriviaController : ControllerBase
{

    private readonly ILogger<TriviaController> _logger;
    private readonly TriviaService _triviaService;

    public TriviaController(ILogger<TriviaController> logger, TriviaService triviaService) =>
        (_logger, _triviaService) = (logger, triviaService);

    [HttpGet()]
    public async Task<IEnumerable<TriviaDTO>> Get() =>
        await _triviaService.GetAllTrivias();

    [HttpGet("{id}")]
    public async Task<TriviaDetalheDTO> Get(long id) =>
        await _triviaService.Get(id);

    [HttpPost()]
    public async Task<TriviaDTO> Post([FromBody] TriviaDTO trivia) =>
        await _triviaService.Post(trivia);

    [HttpPost("{id}/Palavra")]
    public async Task<PalavraDTO> Post(long id, [FromBody] PalavraDTO palavra) =>
        await _triviaService.PostWord(id, palavra);
}
