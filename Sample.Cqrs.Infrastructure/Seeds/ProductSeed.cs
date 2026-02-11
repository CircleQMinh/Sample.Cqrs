using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Cqrs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Cqrs.Infrastructure.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                Id = 1,
                Name = "iPhone 15",
                Description = "Latest Apple smartphone with A16 chip.",
                ImageUrl = "https://example.com/iphone15.jpg",
                Price = 999.99m,
                StockQuantity = 50,
                CreatedBy = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
            },
            new Product
            {
                Id = 2,
                Name = "Samsung Galaxy S24",
                Description = "Flagship Samsung device with premium display.",
                ImageUrl = "https://example.com/galaxys24.jpg",
                Price = 899.99m,
                StockQuantity = 40,
                CreatedBy = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
            },
            new Product
            {
                Id = 3,
                Name = "Sony WH-1000XM5",
                Description = "Industry-leading noise cancelling headphones.",
                ImageUrl = "https://example.com/sony.jpg",
                Price = 349.99m,
                StockQuantity = 25,
                CreatedBy = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
            }
        );
        }
    }
}
