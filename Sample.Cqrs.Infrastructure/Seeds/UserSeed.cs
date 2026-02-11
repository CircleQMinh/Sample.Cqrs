using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
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
        }
    }
}
