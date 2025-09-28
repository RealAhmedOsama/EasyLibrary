using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

public interface IMemberRepository
{
    public Task<List<Book>> BorrowedBooks(Member member);
    public Task<List<Book>> ReservedBooks(Member member);
}