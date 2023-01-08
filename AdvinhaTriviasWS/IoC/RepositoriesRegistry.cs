using System;
using AdvinhaTriviasWS.Domain.Application.Services;
using AdvinhaTriviasWS.Infrastructure.Repositories.Trivia;

namespace AdvinhaTriviasWS.IoC;

public class RepositoriesRegistry
{

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<TriviaRepository>();
    }

}