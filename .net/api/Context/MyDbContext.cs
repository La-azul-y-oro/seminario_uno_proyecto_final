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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DocumentType)
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            modelBuilder.Entity<FunctionalUnit>()
                .HasIndex(fu => new { fu.Name, fu.ConsortiumId })
                .IsUnique();

            modelBuilder.Entity<UserFunctionalUnit>()
                .HasKey(ufu => new { ufu.UserId, ufu.FunctionalUnitId });

            modelBuilder.Entity<UserFunctionalUnit>()
                .HasOne(ufu => ufu.User)
                .WithMany(u => u.UserFunctionalUnits)
                .HasForeignKey(ufu => ufu.UserId);

            modelBuilder.Entity<UserFunctionalUnit>()
                .HasOne(ufu => ufu.FunctionalUnit)
                .WithMany(fu => fu.UserFunctionalUnits)
                .HasForeignKey(ufu => ufu.FunctionalUnitId);
                
            modelBuilder.Entity<Movement>()
                .Property(m => m.type)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
