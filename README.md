# EasyLibrary

EasyLibrary is a comprehensive library management system built using .NET 9. It is designed to streamline the management of books, members, borrowing transactions, and more. The solution is divided into three main projects:

## Projects

### 1. EasyLibrary.DAL
This project handles the data access layer of the application. It includes:
- **Entities**: Representing the database models such as `Book`, `User`, `Category`, `BorrowTransaction`, etc.
- **Database Context**: `AppDbContext` for managing database operations.
- **Migrations**: For database schema management.

### 2. EasyLibrary.Core
This project contains the core business logic and services. It includes:
- **Services**: Business logic for managing books, users, categories, transactions, etc.
- **Repositories**: Interfaces and implementations for data access.
- **Models (DTOs)**: Data transfer objects for communication between layers.
- **Interfaces**: Abstractions for services and repositories.

### 3. EasyLibrary.WinForms
This project provides the user interface for the application using Windows Forms. It includes:
- **Forms**: UI components for managing members, books, transactions, and more.
- **Program Entry Point**: The main entry point of the application.

## Features
- **Book Management**: Add, update, delete, and search for books.
- **Member Management**: Manage library members and their profiles.
- **Borrowing Transactions**: Handle book borrowing and returning processes.
- **Reservation Transactions**: Manage book reservations.
- **Role-Based Access Control**: Manage users and their roles.
- **Dashboard**: Overview of library statistics.

## Getting Started

### Prerequisites
- .NET 9 SDK
- Visual Studio 2022 or later
- SQL Server (or any compatible database)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/RealAhmedOsama/EasyLibrary.git
   ```
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Update the database connection string in `AppDbContext`.
5. Apply migrations to the database:
   ```bash
   dotnet ef database update
   ```
6. Run the application.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Contact
For any inquiries or support, please contact [Ahmed Osama](https://github.com/RealAhmedOsama).