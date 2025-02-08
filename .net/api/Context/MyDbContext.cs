using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Concept> Concept { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                   .ToTable("supplier", t => t.HasCheckConstraint("CK_CUIT", "[Cuit] BETWEEN 1000000000 AND 99999999999"));
        }
    }
}
