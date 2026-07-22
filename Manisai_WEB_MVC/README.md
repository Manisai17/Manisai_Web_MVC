# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. Students can register, log in, take a test by answering questions with radio buttons, and their results are now permanently saved to the database — an overall pass/fail summary plus every individual answer.

## Features
- **Course management** — two implementations for learning comparison:
  - `CoursemastersController` — scaffolded CRUD
  - `CourseController` — manual CRUD (no scaffolding)
- **Student registration & login** — `StudentmastersController` with custom `Login`/`Logout` actions using session state
- **Route protection** — custom `LoginCheckFilter` action filter redirects unauthenticated users to the login page
- **Test management** — `TestmastersController` with full CRUD, linked to courses
- **Test question management** — `TestquestionsController` with full CRUD, filterable by test (`?testId=`)
- **Test-taking flow** — `StudentTestController` lets a logged-in student open a test, answer all questions via radio buttons, and submit
- **Attempt persistence** — on submit, the overall pass/fail result is saved to `studentattemptsummary`, and each individual answer is saved to `studentattemptdetails`
- Database-backed data using Entity Framework Core

> Next up: a student dashboard to view past test attempts and scores.

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
│ └── StudentTestController.cs # Test-taking flow + saving attempt results
├── Filters/
│ └── LoginCheckFilter.cs # Session-based route protection
├── Models/
│ ├── Coursemaster.cs, Studentmaster.cs, Testmaster.cs, Testquestion.cs
│ ├── Studentattemptsummary.cs, Studentattemptdetail.cs
│ └── LmsContext.cs # EF Core database context
├── Views/
│ ├── Course/, Coursemasters/, Testmasters/, Studentmasters/, Testquestions/
│ ├── StudentTest/ # TakeTest.cshtml, TestResult.cshtml
│ └── Shared/
└── wwwroot/ # Static files (CSS, JS, images)

## Usage
Log in at `/Studentmasters/Login` using a student's email and password. From `/Testmasters`, click **Take Test** next to any test to answer its questions. On submit, the result and every answer are saved automatically, and the page shows the score plus a PASSED/FAILED badge.

## Status
🚧 Actively in development — course, student login, test/question management, and the full test-taking-and-saving flow are functional and confirmed saving correctly to the database. A student dashboard to view past attempts is next.

## License
This project currently has no license specified.
