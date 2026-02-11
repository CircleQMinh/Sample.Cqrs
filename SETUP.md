# 1. Clone Repository

git clone <repo-url>

# 2. Configure Database

Update the connection string in:

Sample.Cqrs.Api/appsettings.json

# 3. Apply Migrations
dotnet ef database update --project Sample.Cqrs.Infrastructure --startup-project Sample.Cqrs.Api

# 4. Run the API

dotnet run --project Sample.Cqrs.Api

# 5. Open Swagger
https://localhost:7299/swagger


Swagger provides:

Endpoint documentation

Request/response schemas

JWT authentication support

## Use below account to get started
{
  "email": "admin@demo.com",
  "password": "Admin123!"
}

# 6. Running Tests

dotnet test
