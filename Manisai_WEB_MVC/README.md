# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database.

## Features
- **CourseController** — Fully manual CRUD for courses (no scaffolding): list, view details, add, edit, delete with confirmation
- **CoursemastersController** — Scaffolded CRUD for courses (Create, Index, Details, Edit, Delete)
- **TestmastersController** — Scaffolded CRUD for tests (Create, Index, Details, Edit, Delete), plus an in-progress test-taking view
- Database-backed data using Entity Framework Core

## Not Yet Implemented
- Student management (`Studentmaster`)
- User accounts / login (`Usermaster`)
- Test questions (`Testquestion`)
- A working test-taking flow for students
- Recording student attempt results (`Studentattemptsummary`, `Studentattemptdetail`)

## Tech Stack
- **Framework:** ASP.NET Core MVC (.NET 10.0)
- **Language:** C#
- **ORM:** Entity Framework Core 10
- **Database:** SQL Server
- **Frontend:** Razor Views, Bootstrap, jQuery
- **IDE:** Visual Studio

## Getting Started

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (or later) with the ASP.NET and web development workload
- SQL Server (LocalDB or full instance)

### Installation
1. Clone the repository
```bash
   git clone https://github.com/Manisai17/Manisai_Web_MVC.git
```
2. Open `Manisai_WEB_MVC.slnx` in Visual Studio
3. Update the connection string in `appsettings.json` under `ConnectionStrings` to point to your SQL Server instance
4. Restore NuGet packages
5. Press `F5` to run

## Project Structure

Manisai_WEB_MVC/
├── Controllers/
│   ├── CourseController.cs          # Manual CRUD (no scaffolding)
│   ├── CoursemastersController.cs   # Scaffolded course CRUD
│   └── TestmastersController.cs     # Scaffolded test CRUD + WIP test-taking
├── Models/
│   ├── Coursemaster.cs
│   ├── Studentmaster.cs
│   ├── Testmaster.cs
│   ├── Testquestion.cs
│   ├── Studentattemptsummary.cs
│   ├── Studentattemptdetail.cs
│   ├── Usermaster.cs
│   └── LmsContext.cs
├── Views/
│   ├── Course/
│   ├── Coursemasters/
│   ├── Testmasters/
│   └── Shared/
└── wwwroot/

## Usage
`/Course` for manual course CRUD, `/Coursemasters` for scaffolded course CRUD, `/Testmasters` for test CRUD.

## Status
🚧 Actively in development — roughly 25–30% complete. Course and test management (CRUD) are done. Student records, user login, test questions, and the actual test-taking/results flow are not yet built.

## License
This project currently has no license specified.

