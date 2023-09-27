using IdealSoftApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdealSoftApi.DataAccess;

public class PessoaDbMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(x => x.Sobrenome).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(x => x.Telefone).HasColumnType("VARCHAR(15)").IsRequired();
    }
}
