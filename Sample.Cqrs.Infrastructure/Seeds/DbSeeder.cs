using Sample.Cqrs.Domain.Entities;
using Sample.Cqrs.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Seeds
{
    public static class DbSeeder // used when using in memory db
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                new User
                {
                     Id = 1,
                     Email = "admin@demo.com",
                     Username = "admin@demo.com",
                     PasswordHash = "AQAAAAIAAYagAAAAELpprLkSumrqI7gS16nm0jm1rzNbR6mFkWHQUb+G442Fk4UIV66Q85VtGya1r3602g==",
                     Role = "Admin",
                     CreatedBy = "seed",
                     CreatedDate = new DateTime(2024, 1, 1),
                },
                new User
                {
                    Id = 2,
                    Email = "user@demo.com",
                    Username = "user@demo.com",
                    PasswordHash = "AQAAAAIAAYagAAAAELpprLkSumrqI7gS16nm0jm1rzNbR6mFkWHQUb+G442Fk4UIV66Q85VtGya1r3602g==",
                    Role = "User",
                    CreatedBy = "seed",
                    CreatedDate = new DateTime(2024, 1, 1),
                }
                );

                context.SaveChanges();
            }
        }
    }
}
