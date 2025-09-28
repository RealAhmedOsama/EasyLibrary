using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Interfaces;

internal interface IBookRateRepository
{
    Task<bool> HasMemberRatedBookAsync(Book book, Member member);
    Task<double?> GetAverageRatingAsync(Book book);
    Task<int?> GetLowestRatingAsync(Book book);
    Task<int?> GetHighestRatingAsync(Book book);
    Task<Book?> GetHighestRatingBookAsync();
    Task<Book?> GetLowestRatingBookAsync();
}