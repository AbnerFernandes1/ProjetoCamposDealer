using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDealer.Domain;

namespace ProjetoDealer.Application.Data.Configuration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(c => c.idProduto);

            builder.Property(c => c.dscProduto)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(c => c.vlrUnitario)
                .HasColumnType("float(12,2)")
                .IsRequired();
        }
    }
}
