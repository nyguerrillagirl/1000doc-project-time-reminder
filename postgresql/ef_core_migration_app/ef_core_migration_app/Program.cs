using System;
using ef_core_migration_app; // ✅ Make sure this matches your namespace

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();

        db.Users.Add(new User
        {
            Name = "Lorraine",
            Email = "lorraine@example.com"
        });

        db.SaveChanges();

        Console.WriteLine("User added successfully!");
    }
}
