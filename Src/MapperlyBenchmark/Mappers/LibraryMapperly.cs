using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class LibraryMapperly
{
    public static partial LibraryDto Map(this Library lib);

    private static BookCase MapBook(Book book)
        => book.Map();
}

[Mapper]
public static partial class BookCaseMapperly
{
    //[MapProperty(new[] { nameof(Book.Id) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookId) })]
    //[MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    //[MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    //[MapProperty(MapperIgnoreTargetAttribute)]
    public static BookCase Map(this Book book)
    {
        var bookCase = book.MapInternal();
        bookCase.BookDto = book.MapToBookDto();
        return bookCase;
    }

    private static partial BookCase MapInternal(this Book book);

    //private static BookDto MapBook(Book book)
    //    => book.MapToBookDto();
}

[Mapper]
public static partial class BookMapperly
{
    [MapProperty(nameof(Book.Id), nameof(BookDto.BookId))]
    [MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    [MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    public static partial BookDto MapToBookDto(this Book lib);
}