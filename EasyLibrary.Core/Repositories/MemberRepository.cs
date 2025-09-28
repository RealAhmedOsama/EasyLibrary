using EasyLibrary.Core.Interfaces;
using EasyLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyLibrary.Core.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public async Task<List<Book>> BorrowedBooks(Member member)
    {
        return await _db.BorrowTransactions
            .Where(bt => bt.MemberId == member.Id)
            .Select(bt => bt.Book)
            .Distinct()
            .ToListAsync();
    }

    public async Task<List<Book>> ReservedBooks(Member member)
    {
        return await _db.ReservationTransactions
            .Where(rt => rt.MemberId == member.Id)
            .Select(rt => rt.Book)
            .Distinct()
            .ToListAsync();
    }
}