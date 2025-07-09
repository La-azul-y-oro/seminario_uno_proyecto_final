using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Concept> Concept { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<Consortium> Consortium { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<FunctionalUnit> FunctionalUnit { get; set; }

        public DbSet<Movement> Movement { get; set; }

        public DbSet<Liquidation> Liquidation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DocumentType)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.FunctionalUnits)
                .WithMany(fu => fu.Users)
                .UsingEntity(
                    "user_functional_unit",
                    l => l.HasOne(typeof(FunctionalUnit)).WithMany().HasForeignKey("functional_unit_id"),
                    r => r.HasOne(typeof(User)).WithMany().HasForeignKey("user_id"),
                    j => j.HasKey("user_id", "functional_unit_id"));

            modelBuilder.Entity<FunctionalUnit>()
                .HasIndex(fu => new { fu.Name, fu.ConsortiumId })
                .IsUnique();

            modelBuilder.Entity<FunctionalUnit>()
                .HasOne(m => m.Consortium)
                .WithMany()
                .HasForeignKey(m => m.ConsortiumId);
            
                
            modelBuilder.Entity<Movement>()
                .Property(m => m.Type)
                .HasConversion<string>();

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Concept)
                .WithMany()
                .HasForeignKey(m => m.ConceptId);

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Consortium)
                .WithMany()
                .HasForeignKey(m => m.ConsortiumId);

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.Supplier)
                .WithMany()
                .HasForeignKey(m => m.SupplierId)
                .IsRequired(false);

            modelBuilder.Entity<Movement>()
                .HasOne(m => m.FunctionalUnit)
                .WithMany()
                .HasForeignKey(m => m.FunctionalUnitId)
                .IsRequired(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Concepts)
                .WithMany()
                .UsingEntity(
                    "concept_supplier",
                    l => l.HasOne(typeof(Concept)).WithMany().HasForeignKey("concept_id"),
                    r => r.HasOne(typeof(Supplier)).WithMany().HasForeignKey("supplier_id"),
                    j => j.HasKey("concept_id", "supplier_id"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
