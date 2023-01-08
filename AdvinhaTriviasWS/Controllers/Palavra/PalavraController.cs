using System;
using AdvinhaTriviasWS.Controllers.Trivia.DTOs;
using AdvinhaTriviasWS.Domain.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvinhaTriviasWS.Controllers.Palavra;

[ApiController]
[Route("[controller]/v{version:apiVersion}")]
[ApiVersion("1.0")]
public class PalavraController : ControllerBase
{

    private readonly ILogger<PalavraController> _logger;
    private readonly TriviaService _triviaService;

    public PalavraController(ILogger<PalavraController> logger, TriviaService triviaService) =>
        (_logger, _triviaService) = (logger, triviaService);

    [HttpDelete("{id}")]
    public async Task Delete(long id) =>
        await _triviaService.DeleteWord(id);

}
