using System;
using System.Threading.Tasks;
using Npgsql;

class Program
{
    static async Task Main()
    {
        var password = Environment.GetEnvironmentVariable("PG_TR_PASSWORD");
        var connString = $"Host=localhost;Port=5432;Username=tr;Password={password};Database=trdb";

        await using var conn = new NpgsqlConnection(connString);
        await conn.OpenAsync();

        var createNotificationsSql = @"
            CREATE TABLE IF NOT EXISTS notifications (
                id SERIAL PRIMARY KEY,
                title VARCHAR(200) NOT NULL,
                message TEXT NOT NULL,
                scheduled_time TIMESTAMPTZ NOT NULL,
                status VARCHAR(20) NOT NULL CHECK (status IN ('pending', 'sent', 'cancelled')),
                created_at TIMESTAMPTZ DEFAULT NOW(),
                updated_at TIMESTAMPTZ DEFAULT NOW()
            );
        ";

        var createRecurrenceRulesSql = @"
            CREATE TABLE IF NOT EXISTS recurrence_rules (
                id SERIAL PRIMARY KEY,
                notification_id INT REFERENCES notifications(id) ON DELETE CASCADE,
                notification_type VARCHAR(50) NOT NULL CHECK (notification_type IN ('recurrence', 'advance_notice')),
                rule_type VARCHAR(50),
                rule_value TEXT
            );
        ";

        var createNotificationLogsSql = @"
            CREATE TABLE IF NOT EXISTS notification_logs (
                id SERIAL PRIMARY KEY,
                notification_id INT REFERENCES notifications(id) ON DELETE CASCADE,
                event_type VARCHAR(50),
                event_time TIMESTAMPTZ DEFAULT NOW(),
                details TEXT
            );
        ";

        var tables = new[] { createNotificationsSql, createRecurrenceRulesSql, createNotificationLogsSql };

        foreach (var sql in tables)
        {
            await using var cmd = new NpgsqlCommand(sql, conn);
            await cmd.ExecuteNonQueryAsync();
        }

        Console.WriteLine("All tables created successfully!");
    }
}
