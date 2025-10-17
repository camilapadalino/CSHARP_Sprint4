# Diagrama de Arquitetura

```mermaid
flowchart TD
    Client[Swagger UI / Cliente] --> API[ASP.NET Core Web API]
    API --> Controllers[Controllers (Products, Linq)]
    Controllers --> Repo[Repository/EF Core]
    Repo --> DB[(SQLite)]
```
