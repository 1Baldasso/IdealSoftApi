using IdealSoftApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdealSoftApi.DataAccess;

public class PessoasContext : DbContext
{
    public PessoasContext(DbContextOptions<PessoasContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaDbMapping());
    }

    public DbSet<Pessoa> Pessoas { get; set; }
}
