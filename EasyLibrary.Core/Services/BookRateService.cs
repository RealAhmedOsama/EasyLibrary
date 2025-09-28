using EasyLibrary.Core.Helper;
using EasyLibrary.Core.Interfaces;
using EasyLibrary.Core.Models;
using EasyLibrary.Core.Repositories;
using EasyLibrary.DAL.Entities;

namespace EasyLibrary.Core.Services;

public class BookRateService : IBookRateService
{
    private readonly BookRateRepository _bookRateRepository = new();

    public async Task<List<BookRateDto>> GetAllBooksRatesAsync()
    {
        var bookRates = await _bookRateRepository.GetAllAsync();
        return bookRates.Select(DtoMapper.MapBookRateToDto).ToList();
    }

    public async Task<BookRateDto?> GetBookRateByIdAsync(BookRateDto bookRateDto)
    {
        var bookRateEntity = new BookRate { Id = bookRateDto.Id };
        var bookRate = await _bookRateRepository.GetByIdAsync(bookRateEntity);

        if (bookRate == null)
            return null;

        return DtoMapper.MapBookRateToDto(bookRate);
    }

    public async Task AddBookRateAsync(BookRateDto bookRateDto)
    {
        var bookRate = DtoMapper.MapDtoToBookRate(bookRateDto);
        bookRate.CreatedAt = DateTime.Now;
        await _bookRateRepository.AddAsync(bookRate);
    }

    public async Task UpdateBookRateAsync(BookRateDto bookRateDto)
    {
        var bookRate = DtoMapper.MapDtoToBookRate(bookRateDto);
        await _bookRateRepository.UpdateAsync(bookRate);
    }

    public async Task DeleteBookRateAsync(BookRateDto bookRateDto)
    {
        var bookRate = DtoMapper.MapDtoToBookRate(bookRateDto);
        await _bookRateRepository.DeleteAsync(bookRate);
    }

    public async Task<bool> HasMemberRatedBookAsync(BookRateDto bookRateDto, MemberDto memberDto)
    {
        var book = new Book { Id = bookRateDto.BookId };
        var member = new Member { Id = memberDto.Id };
        return await _bookRateRepository.HasMemberRatedBookAsync(book, member);
    }

    public async Task<double?> GetAverageRatingAsync(BookRateDto bookRateDto)
    {
        var book = new Book { Id = bookRateDto.BookId };
        return await _bookRateRepository.GetAverageRatingAsync(book);
    }

    public async Task<int?> GetLowestRatingAsync(BookRateDto bookRateDto)
    {
        var book = new Book { Id = bookRateDto.BookId };
        return await _bookRateRepository.GetLowestRatingAsync(book);
    }

    public async Task<int?> GetHighestRatingAsync(BookRateDto bookRateDto)
    {
        var book = new Book { Id = bookRateDto.BookId };
        return await _bookRateRepository.GetHighestRatingAsync(book);
    }

    public async Task<BookRateDto?> GetHighestRatingBookAsync()
    {
        var book = await _bookRateRepository.GetHighestRatingBookAsync();
        if (book == null)
            return null;

        // Get the highest rated BookRate for this book
        var bookRates = await _bookRateRepository.GetAllAsync();
        var highestRatedBookRate = bookRates
            .Where(br => br.BookId == book.Id)
            .OrderByDescending(br => br.Rate)
            .FirstOrDefault();

        if (highestRatedBookRate == null)
            return null;

        return DtoMapper.MapBookRateToDto(highestRatedBookRate);
    }

    public async Task<BookRateDto?> GetLowestRatingBookAsync()
    {
        var book = await _bookRateRepository.GetLowestRatingBookAsync();
        if (book == null)
            return null;

        // Get the lowest rated BookRate for this book
        var bookRates = await _bookRateRepository.GetAllAsync();
        var lowestRatedBookRate = bookRates
            .Where(br => br.BookId == book.Id)
            .OrderBy(br => br.Rate)
            .FirstOrDefault();

        if (lowestRatedBookRate == null) return null;

        return DtoMapper.MapBookRateToDto(lowestRatedBookRate);
    }
}