using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Faker;
using Microsoft.EntityFrameworkCore;
using VendingDevices.Entities;

namespace VendingDevices.Context;


public static class SeedData
{
    public static void SeedDatabase(MyDbContext context)
    {
        context.Database.Migrate();
        if (!context.Users.Any())
        {
            for (int i = 1; i <= 100; i++)
            {
                using SHA256 hash=SHA256.Create();
                string password = Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes("qwerty")));
                var user = new User
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    MiddleName = Name.Middle(),
                    IdRole = new Random().Next(1,12),
                    Email = Internet.Email(),
                    Number =Phone.Number(),
                    Password =password
                };
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}