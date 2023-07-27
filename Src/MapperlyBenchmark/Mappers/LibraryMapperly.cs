using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class LibraryMapperly
{
    [MapProperty(nameof(Library.Books), nameof(LibraryDto.BookCases))]
    public static partial LibraryDto Map(this Library lib);

    private static BookCase CreateBookCase(Book book)
        => book.MapBookCase();
}

[Mapper]
public static partial class BookCaseMapperly
{
    public static BookCase MapBookCase(this Book book)
    {
        var bookCase = book.MapBookCaseInternal();
        bookCase.BookDto = book.Map();
        
        return bookCase;
    }

    //[MapProperty(new[] { nameof(Book.Id) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookId) })]
    //[MapProperty(new[] { nameof(Book.Author) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookAuthor) })]
    //[MapProperty(new[] { nameof(Book.Title) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookTitle) })]
    //[MapProperty(nameof(Book), nameof(BookCase.BookDto))]
    private static partial BookCase MapBookCaseInternal(this Book book);
}

[Mapper]
public static partial class BookMapperly
{
    [MapProperty(nameof(Book.Id), nameof(BookDto.BookId))]
    [MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    [MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    public static partial BookDto Map(this Book book);
}