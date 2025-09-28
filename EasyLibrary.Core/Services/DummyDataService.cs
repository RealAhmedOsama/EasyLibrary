using System.Security.Cryptography;
using System.Text;
using EasyLibrary.DAL.Database;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Services;

public class DummyDataService
{
    /// <summary>
    ///     Inserts dummy data asynchronously
    /// </summary>
    public static async Task InsertDummyDataAsync()
    {
        using var db = new AppDbContext();

        try
        {
            // Ensure database is created
            await db.Database.EnsureCreatedAsync();

            // Check if data already exists
            if (await db.Categories.AnyAsync() || await db.Users.AnyAsync() || await db.Members.AnyAsync())
            {
                Console.WriteLine("Dummy data already exists. Skipping insertion.");
                return;
            }

            Console.WriteLine("Starting dummy data insertion for EasyLibrary...");

            // Insert Categories first (no dependencies)
            await InsertCategories(db);
            Console.WriteLine("Categories inserted successfully");

            // Insert Roles
            await InsertRoles(db);
            Console.WriteLine("Roles inserted successfully");

            // Insert Users
            await InsertUsers(db);
            Console.WriteLine("Users inserted successfully");

            // Insert Books (depends on Categories)
            await InsertBooks(db);
            Console.WriteLine("Books inserted successfully");

            // Insert Members
            await InsertMembers(db);
            Console.WriteLine("Members inserted successfully");

            // Insert UserInRoles (depends on Users and Roles)
            await InsertUserInRoles(db);
            Console.WriteLine("User roles assigned successfully");

            // Insert BorrowTransactions (depends on Books and Members)
            await InsertBorrowTransactions(db);
            Console.WriteLine("Borrow transactions created successfully");

            // Insert ReservationTransactions (depends on Books and Members)
            await InsertReservationTransactions(db);
            Console.WriteLine("Reservation transactions created successfully");

            // Insert BookRates (depends on Books and Members)
            await InsertBookRates(db);
            Console.WriteLine("Book ratings inserted successfully");

            Console.WriteLine("All dummy data insertion completed successfully!");
            Console.WriteLine("\nSummary:");
            Console.WriteLine($"   Categories: {await db.Categories.CountAsync()}");
            Console.WriteLine($"   Roles: {await db.Roles.CountAsync()}");
            Console.WriteLine($"   Users: {await db.Users.CountAsync()}");
            Console.WriteLine($"   Books: {await db.Books.CountAsync()}");
            Console.WriteLine($"   Members: {await db.Members.CountAsync()}");
            Console.WriteLine($"   Borrow Transactions: {await db.BorrowTransactions.CountAsync()}");
            Console.WriteLine($"   Reservation Transactions: {await db.ReservationTransactions.CountAsync()}");
            Console.WriteLine($"   Book Ratings: {await db.BookRates.CountAsync()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during dummy data insertion: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"   Inner exception: {ex.InnerException.Message}");
            }

            throw;
        }
    }

    private static async Task InsertCategories(AppDbContext db)
    {
        var categories = new List<Category>
        {
            new()
            {
                Name = "Fiction",
                Description = "Novels and fictional stories",
                CreatedOn = DateTime.Now.AddDays(-30),
                IsActive = true
            },
            new()
            {
                Name = "Science",
                Description = "Scientific books and research materials",
                CreatedOn = DateTime.Now.AddDays(-25),
                IsActive = true
            },
            new()
            {
                Name = "History",
                Description = "Historical books and documentaries",
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            },
            new()
            {
                Name = "Technology",
                Description = "Programming, IT, and technology books",
                CreatedOn = DateTime.Now.AddDays(-15),
                IsActive = true
            },
            new()
            {
                Name = "Biography",
                Description = "Life stories and autobiographies",
                CreatedOn = DateTime.Now.AddDays(-10),
                IsActive = true
            },
            new()
            {
                Name = "Philosophy",
                Description = "Philosophical works and thoughts",
                CreatedOn = DateTime.Now.AddDays(-5),
                IsActive = true
            }
        };

        db.Categories.AddRange(categories);
        await db.SaveChangesAsync();
    }

    private static async Task InsertRoles(AppDbContext db)
    {
        var roles = new List<Role>
        {
            new()
            {
                RoleName = "Administrator",
                Description = "Full system access and management capabilities",
                CreatedOn = DateTime.Now.AddDays(-30),
                IsActive = true
            },
            new()
            {
                RoleName = "Librarian",
                Description = "Manage books, members, and transactions",
                CreatedOn = DateTime.Now.AddDays(-25),
                IsActive = true
            },
            new()
            {
                RoleName = "Assistant",
                Description = "Limited access to help with daily operations",
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            }
        };

        db.Roles.AddRange(roles);
        await db.SaveChangesAsync();
    }

    private static async Task InsertUsers(AppDbContext db)
    {
        var users = new List<User>
        {
            new()
            {
                Username = "ahmed_admin",
                Password = HashPassword("Admin@123"),
                Email = "ahmed.admin@easylibrary.com",
                CreatedOn = DateTime.Now.AddDays(-30),
                IsActive = true
            },
            new()
            {
                Username = "fatima_librarian",
                Password = HashPassword("Librarian@123"),
                Email = "fatima.librarian@easylibrary.com",
                CreatedOn = DateTime.Now.AddDays(-25),
                IsActive = true
            },
            new()
            {
                Username = "omar_assistant",
                Password = HashPassword("Assistant@123"),
                Email = "omar.assistant@easylibrary.com",
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            },
            new()
            {
                Username = "aisha_librarian",
                Password = HashPassword("Librarian@456"),
                Email = "aisha.librarian@easylibrary.com",
                CreatedOn = DateTime.Now.AddDays(-15),
                IsActive = true
            }
        };

        db.Users.AddRange(users);
        await db.SaveChangesAsync();
    }

    private static async Task InsertBooks(AppDbContext db)
    {
        var categories = await db.Categories.ToListAsync();

        var books = new List<Book>
        {
            // Fiction Books
            new()
            {
                Title = "The Arabian Nights",
                Author = "Khalil Gibran",
                ISBN = "9781234567891",
                PublishedYear = 1985,
                CategoryId = categories.First(c => c.Name == "Fiction").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-25),
                IsActive = true
            },
            new()
            {
                Title = "Cities of Salt",
                Author = "Abdul Rahman Munif",
                ISBN = "9781234567892",
                PublishedYear = 1984,
                CategoryId = categories.First(c => c.Name == "Fiction").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-24),
                IsActive = true
            },

            // Science Books
            new()
            {
                Title = "The Quantum Universe",
                Author = "Hassan Al-Sharif",
                ISBN = "9781234567893",
                PublishedYear = 2020,
                CategoryId = categories.First(c => c.Name == "Science").Id,
                IsAvailable = false,
                CreatedOn = DateTime.Now.AddDays(-23),
                IsActive = true
            },
            new()
            {
                Title = "Medical Breakthroughs",
                Author = "Dr. Layla Ahmed",
                ISBN = "9781234567894",
                PublishedYear = 2019,
                CategoryId = categories.First(c => c.Name == "Science").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-22),
                IsActive = true
            },

            // History Books
            new()
            {
                Title = "Islamic Golden Age",
                Author = "Mahmoud Hassan",
                ISBN = "9781234567895",
                PublishedYear = 2018,
                CategoryId = categories.First(c => c.Name == "History").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-21),
                IsActive = true
            },
            new()
            {
                Title = "Ancient Arab Civilizations",
                Author = "Nadia Al-Zahra",
                ISBN = "9781234567896",
                PublishedYear = 2017,
                CategoryId = categories.First(c => c.Name == "History").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            },

            // Technology Books
            new()
            {
                Title = "Modern Programming Techniques",
                Author = "Yusuf Al-Rashid",
                ISBN = "9781234567897",
                PublishedYear = 2023,
                CategoryId = categories.First(c => c.Name == "Technology").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-19),
                IsActive = true
            },
            new()
            {
                Title = "AI and Machine Learning",
                Author = "Amira Khalil",
                ISBN = "9781234567898",
                PublishedYear = 2022,
                CategoryId = categories.First(c => c.Name == "Technology").Id,
                IsAvailable = false,
                CreatedOn = DateTime.Now.AddDays(-18),
                IsActive = true
            },

            // Biography Books
            new()
            {
                Title = "Life of Ibn Sina",
                Author = "Rashid Al-Maktoum",
                ISBN = "9781234567899",
                PublishedYear = 2016,
                CategoryId = categories.First(c => c.Name == "Biography").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-17),
                IsActive = true
            },
            new()
            {
                Title = "The Scholar's Journey",
                Author = "Khadija Al-Ansari",
                ISBN = "9781234567800",
                PublishedYear = 2021,
                CategoryId = categories.First(c => c.Name == "Biography").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-16),
                IsActive = true
            },

            // Philosophy Books
            new()
            {
                Title = "Eastern Philosophy Principles",
                Author = "Said Al-Ghazzali",
                ISBN = "9781234567801",
                PublishedYear = 2020,
                CategoryId = categories.First(c => c.Name == "Philosophy").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-15),
                IsActive = true
            },
            new()
            {
                Title = "Modern Ethical Thoughts",
                Author = "Zainab Al-Kindi",
                ISBN = "9781234567802",
                PublishedYear = 2019,
                CategoryId = categories.First(c => c.Name == "Philosophy").Id,
                IsAvailable = true,
                CreatedOn = DateTime.Now.AddDays(-14),
                IsActive = true
            }
        };

        db.Books.AddRange(books);
        await db.SaveChangesAsync();
    }

    private static async Task InsertMembers(AppDbContext db)
    {
        var members = new List<Member>
        {
            new()
            {
                Name = "Ahmad Al-Rashid",
                Email = "ahmad.rashid@email.com",
                Phone = "05551234567",
                MembershipDate = DateTime.Now.AddDays(-60),
                CreatedOn = DateTime.Now.AddDays(-60),
                IsActive = true
            },
            new()
            {
                Name = "Fatima Al-Zahra",
                Email = "fatima.zahra@email.com",
                Phone = "05551234568",
                MembershipDate = DateTime.Now.AddDays(-45),
                CreatedOn = DateTime.Now.AddDays(-45),
                IsActive = true
            },
            new()
            {
                Name = "Omar Al-Khatib",
                Email = "omar.khatib@email.com",
                Phone = "05551234569",
                MembershipDate = DateTime.Now.AddDays(-30),
                CreatedOn = DateTime.Now.AddDays(-30),
                IsActive = true
            },
            new()
            {
                Name = "Aisha Al-Siddiq",
                Email = "aisha.siddiq@email.com",
                Phone = "05551234570",
                MembershipDate = DateTime.Now.AddDays(-20),
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            },
            new()
            {
                Name = "Hassan Al-Banna",
                Email = "hassan.banna@email.com",
                Phone = "05551234571",
                MembershipDate = DateTime.Now.AddDays(-15),
                CreatedOn = DateTime.Now.AddDays(-15),
                IsActive = true
            },
            new()
            {
                Name = "Zeinab Al-Ghazzali",
                Email = "zeinab.ghazzali@email.com",
                Phone = "05551234572",
                MembershipDate = DateTime.Now.AddDays(-10),
                CreatedOn = DateTime.Now.AddDays(-10),
                IsActive = true
            },
            new()
            {
                Name = "Khalil Al-Nouri",
                Email = "khalil.nouri@email.com",
                Phone = "05551234573",
                MembershipDate = DateTime.Now.AddDays(-5),
                CreatedOn = DateTime.Now.AddDays(-5),
                IsActive = true
            }
        };

        db.Members.AddRange(members);
        await db.SaveChangesAsync();
    }

    private static async Task InsertUserInRoles(AppDbContext db)
    {
        var users = await db.Users.ToListAsync();
        var roles = await db.Roles.ToListAsync();

        var userInRoles = new List<UserInRole>
        {
            new()
            {
                UserId = users.First(u => u.Username == "ahmed_admin").Id,
                RoleId = roles.First(r => r.RoleName == "Administrator").Id,
                CreatedOn = DateTime.Now.AddDays(-30),
                IsActive = true
            },
            new()
            {
                UserId = users.First(u => u.Username == "fatima_librarian").Id,
                RoleId = roles.First(r => r.RoleName == "Librarian").Id,
                CreatedOn = DateTime.Now.AddDays(-25),
                IsActive = true
            },
            new()
            {
                UserId = users.First(u => u.Username == "omar_assistant").Id,
                RoleId = roles.First(r => r.RoleName == "Assistant").Id,
                CreatedOn = DateTime.Now.AddDays(-20),
                IsActive = true
            },
            new()
            {
                UserId = users.First(u => u.Username == "aisha_librarian").Id,
                RoleId = roles.First(r => r.RoleName == "Librarian").Id,
                CreatedOn = DateTime.Now.AddDays(-15),
                IsActive = true
            }
        };

        db.UserInRoles.AddRange(userInRoles);
        await db.SaveChangesAsync();
    }

    private static async Task InsertBorrowTransactions(AppDbContext db)
    {
        var books = await db.Books.ToListAsync();
        var members = await db.Members.ToListAsync();

        var borrowTransactions = new List<BorrowTransaction>
        {
            new()
            {
                BookId = books.First(b => b.Title == "The Quantum Universe").Id,
                MemberId = members.First(m => m.Name == "Ahmad Al-Rashid").Id,
                BorrowDate = DateTime.Now.AddDays(-14),
                DueDate = DateTime.Now.AddDays(0), // Due today
                ReturnDate = null, // Not returned yet
                CreatedOn = DateTime.Now.AddDays(-14),
                IsActive = true
            },
            new()
            {
                BookId = books.First(b => b.Title == "AI and Machine Learning").Id,
                MemberId = members.First(m => m.Name == "Fatima Al-Zahra").Id,
                BorrowDate = DateTime.Now.AddDays(-7),
                DueDate = DateTime.Now.AddDays(7),
                ReturnDate = null, // Not returned yet
                CreatedOn = DateTime.Now.AddDays(-7),
                IsActive = true
            },
            new()
            {
                BookId = books.First(b => b.Title == "The Arabian Nights").Id,
                MemberId = members.First(m => m.Name == "Omar Al-Khatib").Id,
                BorrowDate = DateTime.Now.AddDays(-21),
                DueDate = DateTime.Now.AddDays(-7),
                ReturnDate = DateTime.Now.AddDays(-3), // Returned late
                CreatedOn = DateTime.Now.AddDays(-21),
                IsActive = true
            },
            new()
            {
                BookId = books.First(b => b.Title == "Islamic Golden Age").Id,
                MemberId = members.First(m => m.Name == "Aisha Al-Siddiq").Id,
                BorrowDate = DateTime.Now.AddDays(-10),
                DueDate = DateTime.Now.AddDays(4),
                ReturnDate = null,
                CreatedOn = DateTime.Now.AddDays(-10),
                IsActive = true
            }
        };

        db.BorrowTransactions.AddRange(borrowTransactions);
        await db.SaveChangesAsync();
    }

    private static async Task InsertReservationTransactions(AppDbContext db)
    {
        var books = await db.Books.ToListAsync();
        var members = await db.Members.ToListAsync();

        var reservationTransactions = new List<ReservationTransaction>
        {
            new()
            {
                BookId = books.First(b => b.Title == "The Quantum Universe").Id,
                MemberId = members.First(m => m.Name == "Hassan Al-Banna").Id,
                ReservationDate = DateTime.Now.AddDays(-2),
                ExpirationDate = DateTime.Now.AddDays(5),
                CreatedOn = DateTime.Now.AddDays(-2),
                IsActive = true
            },
            new()
            {
                BookId = books.First(b => b.Title == "AI and Machine Learning").Id,
                MemberId = members.First(m => m.Name == "Zeinab Al-Ghazzali").Id,
                ReservationDate = DateTime.Now.AddDays(-1),
                ExpirationDate = DateTime.Now.AddDays(6),
                CreatedOn = DateTime.Now.AddDays(-1),
                IsActive = true
            },
            new()
            {
                BookId = books.First(b => b.Title == "Modern Programming Techniques").Id,
                MemberId = members.First(m => m.Name == "Khalil Al-Nouri").Id,
                ReservationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(7),
                CreatedOn = DateTime.Now,
                IsActive = true
            }
        };

        db.ReservationTransactions.AddRange(reservationTransactions);
        await db.SaveChangesAsync();
    }

    private static async Task InsertBookRates(AppDbContext db)
    {
        var books = await db.Books.ToListAsync();
        var members = await db.Members.ToListAsync();

        var bookRates = new List<BookRate>
        {
            new()
            {
                BookId = books.First(b => b.Title == "The Arabian Nights").Id,
                MemberId = members.First(m => m.Name == "Ahmad Al-Rashid").Id,
                Rate = 5,
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new()
            {
                BookId = books.First(b => b.Title == "The Arabian Nights").Id,
                MemberId = members.First(m => m.Name == "Fatima Al-Zahra").Id,
                Rate = 4,
                CreatedAt = DateTime.Now.AddDays(-4)
            },
            new()
            {
                BookId = books.First(b => b.Title == "Islamic Golden Age").Id,
                MemberId = members.First(m => m.Name == "Omar Al-Khatib").Id,
                Rate = 5,
                CreatedAt = DateTime.Now.AddDays(-3)
            },
            new()
            {
                BookId = books.First(b => b.Title == "Modern Programming Techniques").Id,
                MemberId = members.First(m => m.Name == "Aisha Al-Siddiq").Id,
                Rate = 4,
                CreatedAt = DateTime.Now.AddDays(-2)
            },
            new()
            {
                BookId = books.First(b => b.Title == "Eastern Philosophy Principles").Id,
                MemberId = members.First(m => m.Name == "Hassan Al-Banna").Id,
                Rate = 5,
                CreatedAt = DateTime.Now.AddDays(-1)
            }
        };

        db.BookRates.AddRange(bookRates);
        await db.SaveChangesAsync();
    }

    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}