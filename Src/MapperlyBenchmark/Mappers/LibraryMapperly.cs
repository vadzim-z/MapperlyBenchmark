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
    //private static BookDto CreateBookCase(Book book)
    //    => book.MapBook();
}

[Mapper]
public static partial class BookCaseMapperly
{
    //[MapProperty(new[] { nameof(Book.Id) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookId) })]
    //[MapProperty(new[] { nameof(Book.Author) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookAuthor) })]
    //[MapProperty(new[] { nameof(Book.Title) },
    //    new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookTitle) })]
    [MapProperty(nameof(Book), nameof(BookCase.BookDto))]
    public static partial BookCase MapBookCase(this Book book);

    private static BookDto CreateBookDto(Book book)
        => book.Map();
}

[Mapper]
public static partial class BookMapperly
{
    [MapProperty(nameof(Book.Id), nameof(BookDto.BookId))]
    [MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    [MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    public static partial BookDto Map(this Book book);
}