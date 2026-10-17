using Humanizer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ef_core_migration_app
{


    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var password = Environment.GetEnvironmentVariable("PG_TR_PASSWORD");
            var connectionString = $"Host=localhost;Port=5432;Username=tr;Password={password};Database=trdb";
            options.UseNpgsql(connectionString);
        }

        // Ensure the User table is created correctly
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // 1. TABLE NAMES - lowercase and plural
                var tableName = entity.ClrType.Name.Pluralize().ToLower();
                entity.SetTableName(tableName);

                // 2. COLUMN NAMES - lowercase
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToLower());
                }

                // 3. PRIMARY KEYS - lowercase
                var primaryKey = entity.FindPrimaryKey();
                if (primaryKey is { } key)
                {
                    primaryKey.SetName(primaryKey.GetName()!.ToLower());
                }

                // 4. FOREIGN KEYS - lowercase
                foreach (var fk in entity.GetForeignKeys())
                {
                    fk.SetConstraintName(fk.GetConstraintName()!.ToLower());
                }

                // 5. INDEXES - lowercase
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(index.GetDatabaseName()!.ToLower());
                }
            }


        }


    }
}

