# Sample.Cqrs — Clean Architecture Web API (.NET 8)

This project is a RESTful Web API built with **.NET 8**, following **Clean Architecture principles** with **CQRS + MediatR**.  
It demonstrates secure authentication, layered separation of concerns, validation, and testing.

#Check the Brief Design Explanation for Explanation.  
#Check the SETUP.md to set up the project.  
---

## Key Features

- Clean Architecture  
- CQRS with custom Mediator  
- JWT Authentication  
- Entity Framework Core  
- FluentValidation pipeline  
- Integration & unit testing  
- OpenAPI / Swagger support  
- Token blacklisting for logout  
- Repository abstraction  
- Middleware-based exception handling  

---

## Technology Stack

| Category      | Technology            |
|--------------|----------------------|
| Runtime      | .NET 8               |
| API          | ASP.NET Core         |
| ORM          | Entity Framework Core|
| Auth         | JWT Bearer           |
| Validation   | FluentValidation     |
| Mediator     | MediatR              |
| Testing      | xUnit                |
| Documentation| Swagger / OpenAPI    |

---

## Project Structure

Sample.Cqrs.Api
+ Controllers
+ Middleware
+ Startup

Sample.Cqrs.Application
+ CQRS handlers
+ Validators
+ Interfaces

Sample.Cqrs.Domain
+ Entities
+ Base models

Sample.Cqrs.Infrastructure
+ EF Core
+ Security
+ Repositories
+ Migrations
+ Seeds

Simple.Cqrs.Tests
+ Unit tests

Sample.Cqrs.Api.Tests
+ Integration tests
