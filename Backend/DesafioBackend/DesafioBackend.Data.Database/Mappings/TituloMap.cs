using DesafioBackend.Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBackend.Data.Database.Mappings
{
    public class TituloMap : IEntityTypeConfiguration<Titulo>
    {
        public void Configure(EntityTypeBuilder<Titulo> builder)
        {
            builder.ToTable("Titulo");

            builder.HasKey(e => e.Id)
                .HasName("PK_Titulo");

            builder.Property(e => e.NumeroTitulo)
                .IsRequired();

            builder.Property(e => e.NomeDevedor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.CPFDevedor)
                .IsRequired()
                .HasMaxLength(12)
                .IsFixedLength();

            builder.Property(e => e.Juros)
                .IsRequired();

            builder.Property(e => e.Multa)
                .IsRequired();

            builder.Property(e => e.QtdParcelas)
                .IsRequired();

            builder.HasMany(e => e.Parcelas)
                .WithOne(e => e.Titulo)
                .HasForeignKey(e => e.IdTitulo)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
