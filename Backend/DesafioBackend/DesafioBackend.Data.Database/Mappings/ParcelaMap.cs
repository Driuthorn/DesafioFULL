using DesafioBackend.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackend.Data.Database.Mappings
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("Parcela");

            builder.HasKey(e => e.Id).HasName("PK_Parcela");

            builder.Property(e => e.NumeroParcela)
                .IsRequired();

            builder.Property(e => e.Vencimento)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(18,3)")
                .IsRequired();
        }
    }
}
