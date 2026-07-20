# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. Course management was built twice — once manually and once via scaffolding — as a learning exercise to understand what ASP.NET Core's scaffolding tool generates under the hood.

## Features
- **CourseController** — Fully manual CRUD for courses (no scaffolding):
  - View all courses (`Index`)
  - View a single course's details (`Details`)
  - Add a new course (`AddCourse`)
  - Edit an existing course (`EditCourse`)
  - Delete a course with a confirmation step (`DeleteConfirmation` → `DeleteCourse`)
- **CoursemastersController** — Scaffolded CRUD for courses (Create, Index, Details, Edit, Delete)
- **TestmastersController** — Scaffolded CRUD for tests (Create, Index, Details, Edit, Delete), plus an in-progress test-taking view
- **StudentmastersController** — Scaffolded CRUD for students (Create, Index, Details, Edit, Delete), plus custom **Login** and **Logout** actions using session-based authentication
- Database-backed data using Entity Framework Core, with foreign key relationships between courses, students, tests, questions, and attempt records

## Login
Students log in directly using their own record in `studentmaster` (matching `emailid` and `password`). On successful login, their student ID and name are stored in session, so the app can identify who's logged in across pages.

> Note: passwords are currently stored as plain text for simplicity during development. This should be replaced with proper password hashing (e.g. BCrypt or ASP.NET Identity) before any real deployment.

## Not Yet Implemented
- Session-based route protection (currently, pages can still be visited without logging in — session is stored but not yet enforced)
- Test questions (`Testquestion`) — CRUD to add questions to a test
- A working test-taking flow for students (viewing questions, submitting answers)
- Recording student attempt results (`Studentattemptsummary`, `Studentattemptdetail`)
- Password hashing / stronger security

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
4. Run the included `lms.sql` script against your SQL Server instance to create the database and tables
5. Restore NuGet packages (happens automatically on open, or run `dotnet restore`)
6. Press `F5` or click **Run** to launch the app

## Project Structure

Manisai_WEB_MVC/
├── Controllers/
│   ├── CourseController.cs          # Manual CRUD (no scaffolding)
│   ├── CoursemastersController.cs   # Scaffolded course CRUD
│   ├── TestmastersController.cs     # Scaffolded test CRUD + WIP test-taking
│   └── StudentmastersController.cs  # Scaffolded student CRUD + Login/Logout
├── Models/
│   ├── Coursemaster.cs
│   ├── Studentmaster.cs
│   ├── Testmaster.cs
│   ├── Testquestion.cs
│   ├── Studentattemptsummary.cs
│   ├── Studentattemptdetail.cs
│   ├── Usermaster.cs                # Currently unused (no matching DB table)
│   └── LmsContext.cs                # EF Core database context
├── Views/
│   ├── Course/
│   ├── Coursemasters/
│   ├── Testmasters/
│   ├── Studentmasters/              # Includes Login.cshtml
│   └── Shared/
├── wwwroot/                          # Static files (CSS, JS, images)
└── lms.sql                           # Original database schema script

## Usage
- `/Course` — manual course CRUD flow
- `/Coursemasters` — scaffolded course CRUD
- `/Testmasters` — test CRUD
- `/Studentmasters` — student CRUD
- `/Studentmasters/Login` — student login
- `/Studentmasters/Logout` — student logout

## Status
🚧 Actively in development — course, test, and student management (CRUD) are complete. Student login is functional using session storage. Route protection, test questions, the test-taking flow, and result tracking are next.

## License
This project currently has no license specified.

