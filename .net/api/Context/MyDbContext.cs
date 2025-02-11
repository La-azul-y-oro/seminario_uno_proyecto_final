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

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                   .ToTable("supplier", t => t.HasCheckConstraint("CK_CUIT", "[Cuit] BETWEEN 1000000000 AND 99999999999"));

            modelBuilder.Entity<Consortium>()
                .ToTable("consortium")
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Consortium>()
                .Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
