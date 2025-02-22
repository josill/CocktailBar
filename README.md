# CocktailBar

A demo backend service for managing cocktail recipes and inventory to demonstrate the design of Rich Domain Model design and configuration using .NET and EF Core.

## 🚀 Features

- Aggregates
- Value objects
- Strictly typed ids
- Explicit configurations
- Extensive documentation

## 📋 Prerequisites

- .NET 7.0 or later
- Docker and Docker Compose
- PostgreSQL (if running locally)

## 🏗️ Project Structure

```
CocktailBar/
├── src/
│   ├── CocktailBar.Api           # REST API endpoints and controllers
│   ├── CocktailBar.Application   # Application business logic and use cases
│   ├── CocktailBar.Contracts     # DTOs and API contracts
│   ├── CocktailBar.Domain        # Domain entities and business rules
│   └── CocktailBar.Infrastructure# Data access and external services
├── docker-compose.yml            # Docker composition configuration
└── Dockerfile                    # Docker container definition
```

## 🔧 Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/CocktailBar.git
cd CocktailBar
```

2. Build the solution:
```bash
dotnet build
```

3. Run the application:

Using Docker:
```bash
docker-compose up -d
```

Or locally:
```bash
cd src/CocktailBar.Api
dotnet watch
```
