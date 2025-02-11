using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.idCliente);

            builder.Property(c => c.nmCliente)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(c => c.Cidade)
                .HasColumnType("varchar(20)")
                .IsRequired();
        }
    }
}
