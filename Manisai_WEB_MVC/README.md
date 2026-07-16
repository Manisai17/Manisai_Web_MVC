# Manisai_Web_MVC

A Learning Management System (LMS) web application built with ASP.NET Core MVC, designed to manage courses, students, tests, and test attempts.

## About
This project follows the MVC (Model-View-Controller) architecture and uses Entity Framework Core to interact with a SQL Server database. It currently includes course management functionality, with the data model supporting students, tests, questions, and attempt tracking for future features.

## Features
- View a list of all available courses
- Edit existing course details (name, description, modules, duration)
- Database-backed data using Entity Framework Core

> More features (student management, test creation, attempt tracking) are in progress — the data models already exist and controllers/views are being built out.

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
   git clone https://github.com/your-username/Manisai_Web_MVC.git
```
2. Open `Manisai_WEB_MVC.slnx` in Visual Studio
3. Update the connection string in `appsettings.json` under `ConnectionStrings` to point to your SQL Server instance
4. Restore NuGet packages (happens automatically on open, or run `dotnet restore`)
5. Press `F5` or click **Run** to launch the app

## Project Structure


Manisai_WEB_MVC/
├── Controllers/
│   └── CourseController.cs      # Handles course listing and editing
├── Models/
│   ├── Coursemaster.cs          # Course entity
│   ├── Studentmaster.cs         # Student entity
│   ├── Testmaster.cs            # Test entity
│   ├── Testquestion.cs          # Test question entity
│   ├── Studentattemptsummary.cs # Student test attempt summary
│   ├── Studentattemptdetail.cs  # Student test attempt details
│   ├── Usermaster.cs            # User entity
│   └── LmsContext.cs            # EF Core database context
├── Views/
│   ├── Course/                  # Course list and edit views
│   └── Shared/                  # Shared layout and partials
└── wwwroot/                     # Static files (CSS, JS, images)


## Usage
Once running, the app opens in your browser at a local address (e.g. `https://localhost:xxxx`). Navigate to the course listing page to view and edit course records.

## Status
🚧 Actively in development — core course management is functional; student, test, and attempt-tracking features are planned next.

## License
This project currently has no license specified.