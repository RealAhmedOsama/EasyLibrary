using EasyLibrary.Core.Models;
using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Helper;

public static class DtoMapper
{
    // User <-> UserDto
    public static UserDto MapUserToDto(User user)
    {
        if (user == null) return null!;
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email,
            CreatedOn = user.CreatedOn,
            IsActive = user.IsActive,
            UserInRoles = user.UserInRoles?.Select(MapUserInRoleToDto).ToList() ?? new List<UserInRoleDto>()
        };
    }

    public static User MapDtoToUser(UserDto userDto)
    {
        if (userDto == null) return null!;
        return new User
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Password = userDto.Password,
            Email = userDto.Email,
            CreatedOn = userDto.CreatedOn,
            IsActive = userDto.IsActive
        };
    }

    // UserInRole <-> UserInRoleDto
    public static UserInRoleDto MapUserInRoleToDto(UserInRole uir)
    {
        if (uir == null) return null!;
        return new UserInRoleDto
        {
            Id = uir.Id,
            UserId = uir.UserId,
            RoleId = uir.RoleId,
            CreatedOn = uir.CreatedOn,
            IsActive = uir.IsActive,
            User = null, // Avoid deep mapping
            Role = null // Avoid deep mapping to prevent cycles
        };
    }

    public static UserInRole MapDtoToUserInRole(UserInRoleDto dto)
    {
        if (dto == null) return null!;
        return new UserInRole
        {
            Id = dto.Id,
            UserId = dto.UserId,
            RoleId = dto.RoleId,
            CreatedOn = dto.CreatedOn,
            IsActive = dto.IsActive
        };
    }

    // Role <-> RoleDto
    public static RoleDto MapRoleToDto(Role role)
    {
        if (role == null) return null!;
        return new RoleDto
        {
            Id = role.Id,
            RoleName = role.RoleName,
            Description = role.Description,
            CreatedOn = role.CreatedOn,
            IsActive = role.IsActive,
            UserInRoles = role.UserInRoles?.Select(MapUserInRoleToDto).ToList() ?? new List<UserInRoleDto>()
        };
    }

    public static Role MapDtoToRole(RoleDto roleDto)
    {
        if (roleDto == null) return null!;
        return new Role
        {
            Id = roleDto.Id,
            RoleName = roleDto.RoleName,
            Description = roleDto.Description,
            CreatedOn = roleDto.CreatedOn,
            IsActive = roleDto.IsActive
        };
    }

    // Book <-> BookDto
    public static BookDto MapBookToDto(Book book)
    {
        if (book == null) return null!;
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PublishedYear = book.PublishedYear,
            CategoryId = book.CategoryId,
            IsAvailable = book.IsAvailable,
            CreatedOn = book.CreatedOn,
            IsActive = book.IsActive,
            Category = MapCategoryToDto(book.Category),
            BorrowTransactions = new List<BorrowTransactionDto>(),
            ReservationTransactions = new List<ReservationTransactionDto>(),
            BookRates = new List<BookRateDto>()
        };
    }

    public static Book MapDtoToBook(BookDto bookDto)
    {
        if (bookDto == null) return null!;
        return new Book
        {
            Id = bookDto.Id,
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            PublishedYear = bookDto.PublishedYear,
            CategoryId = bookDto.CategoryId,
            IsAvailable = bookDto.IsAvailable,
            CreatedOn = bookDto.CreatedOn,
            IsActive = bookDto.IsActive
        };
    }

    // Category <-> CategoryDto
    public static CategoryDto MapCategoryToDto(Category category)
    {
        if (category == null) return null!;
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedOn = category.CreatedOn,
            IsActive = category.IsActive,
            Books = new List<BookDto>() // Avoid deep mapping by default
        };
    }

    public static Category MapDtoToCategory(CategoryDto categoryDto)
    {
        if (categoryDto == null) return null!;
        return new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedOn = categoryDto.CreatedOn,
            IsActive = categoryDto.IsActive
        };
    }

    // Member <-> MemberDto
    public static MemberDto MapMemberToDto(Member member)
    {
        if (member == null) return null!;
        return new MemberDto
        {
            Id = member.Id,
            Name = member.Name,
            Email = member.Email,
            Phone = member.Phone,
            MembershipDate = member.MembershipDate,
            CreatedOn = member.CreatedOn,
            IsActive = member.IsActive,
            BorrowTransactions = new List<BorrowTransactionDto>(),
            ReservationTransactions = new List<ReservationTransactionDto>(),
            BookRates = new List<BookRateDto>()
        };
    }

    public static Member MapDtoToMember(MemberDto memberDto)
    {
        if (memberDto == null) return null!;
        return new Member
        {
            Id = memberDto.Id,
            Name = memberDto.Name,
            Email = memberDto.Email,
            Phone = memberDto.Phone,
            MembershipDate = memberDto.MembershipDate,
            CreatedOn = memberDto.CreatedOn,
            IsActive = memberDto.IsActive
        };
    }

    // BorrowTransaction <-> BorrowTransactionDto
    public static BorrowTransactionDto MapBorrowTransactionToDto(BorrowTransaction bt)
    {
        if (bt == null) return null!;
        return new BorrowTransactionDto
        {
            Id = bt.Id,
            BookId = bt.BookId,
            MemberId = bt.MemberId,
            BorrowDate = bt.BorrowDate,
            DueDate = bt.DueDate,
            ReturnDate = bt.ReturnDate,
            CreatedOn = bt.CreatedOn,
            IsActive = bt.IsActive,
            Book = MapBookToDto(bt.Book),
            Member = MapMemberToDto(bt.Member)
        };
    }

    public static BorrowTransaction MapDtoToBorrowTransaction(BorrowTransactionDto dto)
    {
        if (dto == null) return null!;
        return new BorrowTransaction
        {
            Id = dto.Id,
            BookId = dto.BookId,
            MemberId = dto.MemberId,
            BorrowDate = dto.BorrowDate,
            DueDate = dto.DueDate,
            ReturnDate = dto.ReturnDate,
            CreatedOn = dto.CreatedOn,
            IsActive = dto.IsActive
        };
    }

    // ReservationTransaction <-> ReservationTransactionDto
    public static ReservationTransactionDto MapReservationTransactionToDto(ReservationTransaction rt)
    {
        if (rt == null) return null!;
        return new ReservationTransactionDto
        {
            Id = rt.Id,
            BookId = rt.BookId,
            MemberId = rt.MemberId,
            ReservationDate = rt.ReservationDate,
            ExpirationDate = rt.ExpirationDate,
            CreatedOn = rt.CreatedOn,
            IsActive = rt.IsActive,
            Book = MapBookToDto(rt.Book),
            Member = MapMemberToDto(rt.Member)
        };
    }

    public static ReservationTransaction MapDtoToReservationTransaction(ReservationTransactionDto dto)
    {
        if (dto == null) return null!;
        return new ReservationTransaction
        {
            Id = dto.Id,
            BookId = dto.BookId,
            MemberId = dto.MemberId,
            ReservationDate = dto.ReservationDate,
            ExpirationDate = dto.ExpirationDate,
            CreatedOn = dto.CreatedOn,
            IsActive = dto.IsActive
        };
    }

    // BookRate <-> BookRateDto
    public static BookRateDto MapBookRateToDto(BookRate br)
    {
        if (br == null) return null!;
        return new BookRateDto
        {
            Id = br.Id,
            BookId = br.BookId,
            MemberId = br.MemberId,
            Rate = br.Rate,
            CreatedAt = br.CreatedAt,
            Book = MapBookToDto(br.Book),
            Member = MapMemberToDto(br.Member)
        };
    }

    public static BookRate MapDtoToBookRate(BookRateDto dto)
    {
        if (dto == null) return null!;
        return new BookRate
        {
            Id = dto.Id,
            BookId = dto.BookId,
            MemberId = dto.MemberId,
            Rate = dto.Rate,
            CreatedAt = dto.CreatedAt
        };
    }
}