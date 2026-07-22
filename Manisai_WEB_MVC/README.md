# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. Students can register, log in, take tests by answering questions with radio buttons, have their results permanently saved, and now view their complete test history and detailed answer review through a personal dashboard.

## Features
- **Course management** — two implementations for learning comparison:
  - `CoursemastersController` — scaffolded CRUD
  - `CourseController` — manual CRUD (no scaffolding)
- **Student registration & login** — `StudentmastersController` with custom `Login`/`Logout` actions using session state
- **Route protection** — custom `LoginCheckFilter` action filter redirects unauthenticated users to the login page
- **Test management** — `TestmastersController` with full CRUD, linked to courses
- **Test question management** — `TestquestionsController` with full CRUD, filterable by test (`?testId=`)
- **Test-taking flow** — `StudentTestController` lets a logged-in student open a test, answer all questions via radio buttons, and submit
- **Attempt persistence** — pass/fail results saved to `studentattemptsummary`, individual answers saved to `studentattemptdetails`
- **Student dashboard** — `StudentDashboardController` shows each student their full test history (with pass/fail status) and a detailed per-question answer review for any past attempt
- Database-backed data using Entity Framework Core

> Next up: password hashing for security, model validation, and general polish.

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
│ ├── CourseController.cs # Manual course CRUD
│ ├── CoursemastersController.cs # Scaffolded course CRUD
│ ├── TestmastersController.cs # Test CRUD
│ ├── StudentmastersController.cs # Student CRUD + Login/Logout
│ ├── TestquestionsController.cs # Test question CRUD (filterable by test)
│ ├── StudentTestController.cs # Test-taking flow + saving attempt results
│ └── StudentDashboardController.cs # Student's test history + answer review
├── Filters/
│ └── LoginCheckFilter.cs # Session-based route protection
├── Models/
│ ├── Coursemaster.cs, Studentmaster.cs, Testmaster.cs, Testquestion.cs
│ ├── Studentattemptsummary.cs, Studentattemptdetail.cs
│ └── LmsContext.cs # EF Core database context
├── Views/
│ ├── Course/, Coursemasters/, Testmasters/, Studentmasters/, Testquestions/
│ ├── StudentTest/ # TakeTest.cshtml, TestResult.cshtml
│ ├── StudentDashboard/ # Index.cshtml, Details.cshtml
│ └── Shared/
└── wwwroot/ # Static files (CSS, JS, images)

## Usage
Log in at `/Studentmasters/Login`. From `/Testmasters`, click **Take Test** to answer questions and get an instant score with a saved result. Click **My Tests** in the navigation bar at any time to see your full test history and review your answers on any past attempt.

## Status
🚧 Actively in development — course, student login, test/question management, test-taking, result saving, and the student dashboard are all functional. Password hashing, validation, and polish are planned next.

## License
This project currently has no license specified.

