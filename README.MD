# NovaStartKit

**NovaStartKit — A clean foundation for scalable .NET 9 APIs.**

NovaStartKit is a clean architecture, production-ready Web API starter kit built with .NET 9. It provides a solid foundation for building modular, maintainable, and testable APIs based on SOLID principles and modern design practices.

---

## Technology Stack

- ASP.NET Core 9 (Web API)
- Entity Framework Core 9
- Clean Architecture (Onion-style layering)
- MediatR (CQRS pattern)
- FluentValidation
- AutoMapper
- JWT Authentication
- Serilog (structured logging)
- Swagger / OpenAPI
- xUnit for Unit and Integration Testing

---

## Solution Structure

```

NovaStartKit/
├── src/
│   ├── API/             # API layer (Controllers, Middleware, DI)
│   ├── Application/     # CQRS, DTOs, Interfaces
│   ├── Domain/          # Entities, Value Objects, Interfaces
│   ├── Infrastructure/  # Services, External APIs
│   └── Persistence/     # EF Core DbContext and Migrations
├── tests/
│   ├── UnitTests/       # Unit tests (fast, isolated)
│   └── IntegrationTests/# Integration tests (real DB/API interaction)
├── .editorconfig
├── .gitignore
├── global.json
└── README.md

````

---

## Getting Started

### Prerequisites

- .NET 9 SDK
- EF Core CLI (`dotnet tool install --global dotnet-ef`)
- SQL Server or SQLite (for development)

### Setup Instructions

1. Clone the repository

```bash
git clone https://github.com/anjotadena/NovaStartKit.git
cd NovaStartKit
````

2. Restore dependencies

```bash
dotnet restore
```

3. Apply database migrations

```bash
dotnet ef database update --project src/NovaStartKit.Persistence --startup-project src/NovaStartKit.API
```

4. Run the API

```bash
dotnet run --project src/NovaStartKit.API
```

5. Open Swagger UI

```
https://localhost:{port}/swagger
```

---

## Running Tests

### Unit Tests

```bash
dotnet test ./tests/NovaStartKit.UnitTests --filter "Category!=Integration"
```

### Integration Tests

```bash
dotnet test ./tests/NovaStartKit.IntegrationTests --filter "Category=Integration"
```

---

## Project Goals

* Maintainable and scalable project structure
* High test coverage with separation of concerns
* Modular and composable components
* Fully compliant with SOLID principles
* Clean separation between domain, application, and infrastructure

---

## Roadmap

* Docker support with optional Compose
* GitHub Actions CI/CD pipeline
* Role-based authorization with Identity
* Health checks and observability
* Native AOT support for runtime optimization

---

## License

This project is licensed under the MIT License.

````

---

### ✅ To generate the file via terminal:

You can run this from your project root:

**Linux / Mac:**

```bash
cat > README.md <<EOF
(paste everything above here)
EOF
````

**Windows (PowerShell):**

```powershell
@"
(paste everything above here)
"@ | Set-Content -Path .\README.md
```
