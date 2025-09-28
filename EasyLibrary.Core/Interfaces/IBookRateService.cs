using EasyLibrary.Core.Models;

namespace EasyLibrary.Core.Interfaces;

public interface IBookRateService
{
    Task<List<BookRateDto>> GetAllBooksRatesAsync();
    Task<BookRateDto?> GetBookRateByIdAsync(BookRateDto bookRateDto);
    Task AddBookRateAsync(BookRateDto bookRateDto);
    Task UpdateBookRateAsync(BookRateDto bookRateDto);
    Task DeleteBookRateAsync(BookRateDto bookRateDto);
    Task<bool> HasMemberRatedBookAsync(BookRateDto bookRateDto, MemberDto memberDto);
    Task<double?> GetAverageRatingAsync(BookRateDto bookRateDto);
    Task<int?> GetLowestRatingAsync(BookRateDto bookRateDto);
    Task<int?> GetHighestRatingAsync(BookRateDto bookRateDto);
    Task<BookRateDto?> GetHighestRatingBookAsync();
    Task<BookRateDto?> GetLowestRatingBookAsync();
}