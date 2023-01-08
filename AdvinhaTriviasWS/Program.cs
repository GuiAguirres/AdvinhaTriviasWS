using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using AdvinhaTriviasWS.Infrastructure.Database;
using AdvinhaTriviasWS.IoC;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

try
{
    StartApplication();
}
catch (Exception ex)
{
    
}
finally
{

}

void StartApplication()
{
    ConfigureBuilder(builder);

    ConfigureServices(builder.Services);

    Configure(builder.Build());
}

void ConfigureBuilder(WebApplicationBuilder builder)
{
}

void ConfigureServices(IServiceCollection services)
{
    services.AddApiVersioning(o =>
    {
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        o.ReportApiVersions = true;
    });
    services.AddVersionedApiExplorer(o =>
    {
        o.GroupNameFormat = "'v'VVV";
        o.SubstituteApiVersionInUrl = true;
    });
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "allOrigins",
                          policy =>
                          {
                              policy.WithOrigins("*");
                              policy.AllowAnyHeader();
                              policy.AllowAnyMethod();
                          });
    });

    services.AddDbContext<AppDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));
    ServicesRegistry.Register(services, config);
    RepositoriesRegistry.Register(services, config);
}

void Configure(WebApplication app)
{
    app.UseCors("allOrigins");

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}