
using Npgsql;

var password = Environment.GetEnvironmentVariable("PG_TR_PASSWORD");

var connString = $"Host=localhost;Port=5432;Username=tr;Password={password};Database=trdb";

await using var conn = new NpgsqlConnection(connString);
await conn.OpenAsync();

Console.WriteLine("Connected to trdb as tr!");



