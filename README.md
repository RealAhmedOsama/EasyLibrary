Nice 🔥 Adding a **custom contributors badge** at the top will make your repo look polished and professional.
Here’s the **final README** with the **Credits badge** added:

---

# EasyLibrary 📚

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![Platform](https://img.shields.io/badge/Platform-WinForms-lightgrey)
![Database](https://img.shields.io/badge/Database-SQL%20Server-CC2927)
![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-green)
![License](https://img.shields.io/badge/License-MIT-yellow)
![Status](https://img.shields.io/badge/Status-Active-success)
![Contributors](https://img.shields.io/badge/Contributors-Ahmed%20%26%20Roudina-purple)

An intuitive and efficient **Library Management System** built with **.NET technologies**.
EasyLibrary simplifies day-to-day library operations, providing features for managing books, members, transactions, reservations, and user roles. It eliminates the challenges of manual library management by automating key processes and offering a modern, user-friendly interface.

---

## 🚀 Key Features

* **Book Management** – Add, edit, and delete book records (title, author, ISBN, category, availability).
* **Member Management** – Register and manage members, track borrowing history, and handle reservations.
* **Borrowing & Returns** – Record book loans with due dates and return tracking.
* **Reservation System** – Enable members to reserve books and manage waitlists.
* **User Authentication & Roles** – Secure access with login and role-based permissions.
* **Reports & Analytics** – Generate insights such as most borrowed books, member activity, and overdue items.
* **Database Integration** – Uses **Entity Framework Core** for clean, efficient database interaction.
* **Dummy Data Support** – Insert sample data for quick testing and demos.
* **DTOs (Data Transfer Objects)** – Decouples database models from UI for maintainability.
* **Asynchronous Operations** – Improves performance and responsiveness.
* **Eager Loading** – Optimized queries to prevent lazy loading pitfalls.

---

## 🛠️ Tech Stack

* **Frontend**: WinForms (Windows Forms UI)
* **Backend**: .NET 8 with C#
* **Database**: SQL Server with EF Core (Entity Framework Core ORM)
* **Core Libraries**:

  * `EasyLibrary.DAL` → Entities & Data Access Layer
  * `EasyLibrary.Core` → Services, repositories, business logic
  * `EasyLibrary.WinForms` → Presentation layer (forms & UI)
* **Tools**: Visual Studio, NuGet, EF Core Tools, Git

---

## 📦 Getting Started

### Prerequisites

* [Visual Studio](https://visualstudio.microsoft.com/) with .NET Desktop Development workload
* [.NET SDK](https://dotnet.microsoft.com/download)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) + SSMS
* EF Core CLI tools installed

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/RealAhmedOsama/EasyLibrary.git
   cd EasyLibrary
   ```

2. **Open in Visual Studio**
   Launch `EasyLibrary.sln` → NuGet packages will restore automatically.
   If not, right-click the solution → **Restore NuGet Packages**.

3. **Update Database Connection**
   Edit `Database/AppDbContext.cs` to match your SQL Server instance:

   ```csharp
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlServer("Data Source=YOUR_SERVER;Initial Catalog=EasyLibrary;Integrated Security=True;Trust Server Certificate=True");
   }
   ```

4. **Apply Migrations**

   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```

---

## ▶ Running Locally

1. **Build Solution** → `Ctrl+Shift+B` or Build → Build Solution
2. **Set Startup Project** → Right-click `EasyLibrary.WinForms` → *Set as Startup Project*
3. **Run** → Press `F5` (starts with `LoginForm`)

👉 Default admin credentials are auto-inserted if dummy data is enabled in `Program.cs`.
Comment out `DummyDataService.InsertDummyDataAsync()` if not needed.

---

## 💻 Usage

* **Login** – Enter valid credentials (default admin available with dummy data).
* **MainForm** – Navigate between modules: Book Management, Members, Borrowing, Reservations.
* **Data Operations** – Manage records with simple CRUD forms.
* **Reports** – View borrowing activity, popular books, and overdue logs.

---

## 📂 Project Structure

```
EasyLibrary/
├── EasyLibrary.sln
├── EasyLibrary/
│   ├── Database/
│   │   └── AppDbContext.cs
│   ├── WinForms/
│   │   ├── MainForm.cs
│   │   ├── Program.cs
│   │   ├── Auth/LoginForm.cs
│   │   ├── BookManagement/BookManagementForm.cs
│   │   ├── BorrowTransactions/BorrowTransactionsForm.cs
│   │   └── ...
├── EasyLibrary.Core/
│   ├── Repositories/
│   │   ├── GenericRepository.cs
│   │   ├── BookRepository.cs
│   │   ├── MemberRepository.cs
│   │   ├── BorrowTransactionsRepository.cs
│   │   └── ...
│   ├── Helper/DtoMapper.cs
│   └── ...
├── EasyLibrary.DAL/
│   ├── Entities/
│   │   ├── Book.cs
│   │   ├── Category.cs
│   │   ├── Member.cs
│   │   ├── User.cs
│   │   ├── Role.cs
│   │   └── ...
```

---

## 📸 Screenshots

*(Coming soon – add images of your UI here for better presentation)*

---

## 👥 Credits

This project was developed collaboratively with shared and individual contributions:

* **Roudina Ahmed** – Worked on the **Data Access Layer (DAL)** and **Core layer** side by side with Ahmed Osama.
* **Ahmed Osama** – Focused on **Indexing and Constraints in DAL**, worked extensively on the **Core layer**, and developed the **WinForms UI** independently.

---

## 📝 License

Licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## 📬 Contact

👨‍💻 Developed by **Ahmed Osama**
📧 [Reach me via GitHub Issues](https://github.com/RealAhmedOsama/EasyLibrary/issues)

---

💖 Thanks for checking out **EasyLibrary**! If you like it, don’t forget to ⭐ the repo!
