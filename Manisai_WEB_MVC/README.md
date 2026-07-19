# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. It currently includes course management (built both manually and via scaffolding) and test management, built as a learning exercise.

## Features
- **CourseController** — Fully manual CRUD for courses (no scaffolding):
  - View all courses (`Index`)
  - View a single course's details (`Details`)
  - Add a new course (`AddCourse`)
  - Edit an existing course (`EditCourse`)
  - Delete a course with a confirmation step (`DeleteConfirmation` → `DeleteCourse`)
- **CoursemastersController** — CRUD for courses generated using ASP.NET Core scaffolding (Create, Index, Details, Edit, Delete)
- **TestmastersController** — CRUD for tests generated using ASP.NET Core scaffolding (Create, Index, Details, Edit, Delete)
- Database-backed data using Entity Framework Core

> Note: Course management exists in both manual and scaffolded form as a side-by-side learning comparison. Student management and test attempt tracking are planned next.

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
4. Restore NuGet packages (happens automatically on open, or run `dotnet restore`)
5. Press `F5` or click **Run** to launch the app

## Project Structure

Manisai_WEB_MVC/
├── Controllers/
│   ├── CourseController.cs          # Manual CRUD (no scaffolding) — fully complete
│   ├── CoursemastersController.cs   # Scaffolded course CRUD
│   └── TestmastersController.cs     # Scaffolded test CRUD
├── Models/
│   ├── Coursemaster.cs
│   ├── Studentmaster.cs
│   ├── Testmaster.cs
│   ├── Testquestion.cs
│   ├── Studentattemptsummary.cs
│   ├── Studentattemptdetail.cs
│   ├── Usermaster.cs
│   └── LmsContext.cs                # EF Core database context
├── Views/
│   ├── Course/                      # Views for manual course controller
│   ├── Coursemasters/                # Views for scaffolded course controller
│   ├── Testmasters/                  # Views for scaffolded test controller
│   └── Shared/
└── wwwroot/                          # Static files (CSS, JS, images)

## Usage
Once running, the app opens in your browser at a local address (e.g. `https://localhost:xxxx`). Navigate to `/Course` for the manual CRUD flow, `/Coursemasters` for the scaffolded course version, or `/Testmasters` to manage tests.

## Status
🚧 Actively in development — course management (manual and scaffolded) is complete; test management added. Student management and attempt-tracking features are planned next.

## License
This project currently has no license specified.