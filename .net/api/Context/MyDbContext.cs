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
    }
}
