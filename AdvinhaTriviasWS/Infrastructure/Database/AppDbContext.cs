using System;
using AdvinhaTriviasWS.Domain.Application.Entities.Trivias;
using Microsoft.EntityFrameworkCore;

namespace AdvinhaTriviasWS.Infrastructure.Database;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions opts) : base(opts)
    {
    }

    public DbSet<TriviaEntity> Trivias => Set<TriviaEntity>();
    public DbSet<PalavraEntity> Palavras => Set<PalavraEntity>();

}