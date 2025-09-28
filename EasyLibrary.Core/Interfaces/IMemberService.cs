using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IMemberService
{
    Task<MemberDto?> GetMemberByIdAsync(int id);
    Task<List<MemberDto>> GetAllMembersAsync();
    Task AddMemberAsync(MemberDto member);
    Task UpdateMemberAsync(MemberDto member);
    Task DeleteMemberAsync(MemberDto member);
    Task<List<BookDto>> GetMemberBorrowedBooksAsync(MemberDto member);
    Task<List<BookDto>> GetMemberReservedBooksAsync(MemberDto member);
}