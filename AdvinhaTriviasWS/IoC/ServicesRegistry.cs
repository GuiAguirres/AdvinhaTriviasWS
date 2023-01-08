using System;
using AdvinhaTriviasWS.Domain.Application.Services;

namespace AdvinhaTriviasWS.IoC;

public class ServicesRegistry
{

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<TriviaService>();
    }

}