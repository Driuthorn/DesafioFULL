using DesafioBackend.Data.Database.Entities;
using DesafioBackend.Data.Database.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackend.Data.Database.Context
{
    public class DesafioBackendContext : DbContext
    {
        public DesafioBackendContext(DbContextOptions<DesafioBackendContext> options) : base(options)
        { }

        public DesafioBackendContext()
        { }

        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<Parcela> Parcela { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TituloMap());
            modelBuilder.ApplyConfiguration(new ParcelaMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localHost;Initial Catalog=DesafioFULL;Integrated Security=True;MultipleActiveResultSets=true");
        }

    }
}
