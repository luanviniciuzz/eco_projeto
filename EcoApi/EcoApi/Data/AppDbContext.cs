using EcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
        
        }

        public DbSet<MensageiroModel> Mensageiro { get; set; }
        public DbSet<ContribuinteModel> Contribuinte { get; set; }
        public DbSet<ContribuicaoModel> Contribuicao {  get; set; }
        public DbSet<MovimentoDiarioModel> MovimentoDiario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<MovimentoDiarioModel>(entity =>
            {
                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)") 
                    .IsRequired();
            });

            modelBuilder.Entity<ContribuicaoModel>(entity =>
            {
                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();
            });

            
        }
    }
}
