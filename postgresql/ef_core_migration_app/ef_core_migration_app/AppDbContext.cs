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
        private static string ToSnakeCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            var builder = new System.Text.StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                var c = name[i];
                if (char.IsUpper(c))
                {
                    // Add underscore before uppercase letters (except first)
                    if (i > 0)
                        builder.Append('_');
                    builder.Append(char.ToLower(c));
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        // Ensure the User table is created correctly
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // 1. TABLE NAMES - lowercase and plural
                var tableName = ToSnakeCase(entity.ClrType.Name.Pluralize());
                entity.SetTableName(tableName);

                // 2. COLUMN NAMES - lowercase
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(ToSnakeCase(property.Name));
                }

                // 3. PRIMARY KEYS - lowercase
                var primaryKey = entity.FindPrimaryKey();
                if (primaryKey is { } key)
                {   
                    if (key.GetName() is string keyName)
                    {
                        key.SetName(ToSnakeCase(keyName));
                    }
                }

                // 4. FOREIGN KEYS - lowercase
                foreach (var fk in entity.GetForeignKeys())
                {
                    var constraintName = fk.GetConstraintName();
                    if (constraintName != null)
                    {
                        fk.SetConstraintName(ToSnakeCase(constraintName));
                    }
                }

                // 5. INDEXES - lowercase
                foreach (var index in entity.GetIndexes())
                {
                    var dbName = index.GetDatabaseName();
                    if (dbName != null)
                    {
                        index.SetDatabaseName(ToSnakeCase(dbName));
                    }
                }
            }


        }


    }
}

