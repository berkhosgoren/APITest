# APItest – .NET 8 Web API (Test Project)

This project is a simple test environment built using ASP.NET Core 8 Web API. It was created to practice and validate fundamental API operations such as CRUD (Create, Read, Update, Delete), sorting, filtering, and file uploads.

---

Purpose

The goal of this project was to create a functional testing ground for:
- Building RESTful endpoints
- Practicing controller logic
- Handling file uploads
- Exploring Entity Framework Core
- Connecting to a SQL Server database
- Testing different input/output cases

This is **not a production application** — it's a developer sandbox used to explore and verify different API behaviors.

---

Tech Stack

- .NET 8 Web API
- Entity Framework Core
- SQL Server (local)
- In-memory data (for testing)
- Postman / Swagger for endpoint testing

---

*Connection string in appsettings.json is a placeholder. Replace with your local SQL Server config.

*EF migrations are included — just run dotnet ef database update.

*The in-memory list is used in the controller for basic testing without relying on the DB.


How to Run

1. Clone the repo:
```bash
git clone https://github.com/yourusername/APItest.git
cd APItest/APItest

2. Update the database connection in appsettings.json

3. Apply EF migrations :"dotnet ef database update"

4. Run the app: "dotnet run"
