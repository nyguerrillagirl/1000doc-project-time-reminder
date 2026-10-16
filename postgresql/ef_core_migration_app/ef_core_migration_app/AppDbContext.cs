using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ef_core_migration_app
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var password = Environment.GetEnvironmentVariable("PG_TR_PASSWORD");
            var connectionString = $"Host=localhost;Port=5432;Username=tr;Password={password};Database=trdb"
            options.UseNpgsql(connectionString);
        }
    }
}

