using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Configuration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(p => p.idVenda);

            builder.Property(p => p.qtdVenda)
                .HasColumnType("numeric(3)")
                .IsRequired();

            builder.Property(p => p.vlrUnitarioVenda)
                .HasColumnType("numeric(12,2)")
                .IsRequired();

            builder.Property(p => p.vlrTotalVenda)
                .HasColumnType("numeric(12,2)")
                .IsRequired();

            builder.Property(p => p.dthVenda)
                .HasColumnType("datetime");

            builder.HasOne(p => p.Produtos).WithMany(p => p.Vendas).HasForeignKey(p => p.idProduto);

            builder.HasOne(p => p.Clientes).WithMany(p => p.Vendas).HasForeignKey(p => p.idCliente);
        }
    }
}
