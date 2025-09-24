# RecruitingApp

A .NET 8 Razor Pages application for managing recruitment processes.

## Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022 or VS Code

## Getting Started

### 1. Clone the Repository

## Key Technologies

- **ASP.NET Core 8**: Web framework
- **Entity Framework Core**: Object-relational mapping
- **SQLite**: Default database provider
- **Bootstrap 5**: CSS framework for responsive design
- **jQuery Validation**: Client-side form validation
- **Razor Pages**: Page-based programming model

## Development Notes

### Entity Framework Configuration

The application uses Entity Framework Core with SQLite provider configured in `Program.cs`. Database migrations are automatically applied on startup, and the database is seeded with initial data through the `DbInitializer` class.

### Form Validation

The application implements both client-side and server-side validation:
- Client-side: jQuery Validation plugin (v1.19.5)
- Server-side: Data Annotations and ModelState validation

### Navigation

The main navigation includes links to manage:
- Candidates (`/Candidates`)
- Companies (`/Companies`) 
- Job Titles (`/JobTitles`)
- Industries (`/Industries`)

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request