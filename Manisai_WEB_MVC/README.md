# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. Students can register, log in, take tests, view their full test history, and their credentials and data are protected with password hashing and input validation.

## Features
- **Course management** — scaffolded (`CoursemastersController`) and manual (`CourseController`) CRUD implementations for learning comparison
- **Student registration & login** — session-based authentication with hashed passwords
- **Route protection** — `LoginCheckFilter` blocks unauthenticated access to protected pages
- **Test & question management** — full CRUD, questions filterable by test
- **Test-taking flow** — radio-button based test attempts with instant scoring
- **Attempt persistence** — pass/fail summaries and per-question answers saved to the database
- **Student dashboard** — full test history and detailed answer review per attempt
- **Security** — passwords hashed with BCrypt before storage
- **Validation** — required fields, length limits, and format checks on student and question forms
- **Custom error page** — friendly fallback UI for unhandled errors

## Tech Stack
- **Framework:** ASP.NET Core MVC (.NET 10.0)
- **Language:** C#
- **ORM:** Entity Framework Core 10
- **Database:** SQL Server
- **Security:** BCrypt.Net-Next for password hashing
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
3. Update the connection string in `appsettings.json` under `ConnectionStrings`
4. Restore NuGet packages (automatic on open, or `dotnet restore`)
5. Press `F5` to run

## Project Structure

Manisai_WEB_MVC/
├── Controllers/
│ ├── CourseController.cs, CoursemastersController.cs
│ ├── TestmastersController.cs, TestquestionsController.cs
│ ├── StudentmastersController.cs
│ ├── StudentTestController.cs
│ └── StudentDashboardController.cs
├── Filters/
│ └── LoginCheckFilter.cs
├── Models/
│ ├── Coursemaster.cs, Studentmaster.cs, Testmaster.cs, Testquestion.cs
│ ├── Studentattemptsummary.cs, Studentattemptdetail.cs
│ └── LmsContext.cs
├── Views/
│ ├── Course/, Coursemasters/, Testmasters/, Studentmasters/, Testquestions/
│ ├── StudentTest/, StudentDashboard/
│ └── Shared/
└── wwwroot/

## Usage
Register and log in at `/Studentmasters/Login`. Take tests from `/Testmasters`, and review your history anytime via **My Tests** in the navigation bar.

## Status
✅ **Phases 1–7 complete**: course management, student auth, test-taking, result persistence, student dashboard, password hashing, and validation are all functional.

🔜 **Planned (paused for now)**:
- Phase 8: Restrict visible tests to a student's enrolled course
- Phase 9: Separate admin login to protect course/test management pages
- Phase 10: Landing page, profile editing, final UI polish

## License
This project currently has no license specified.