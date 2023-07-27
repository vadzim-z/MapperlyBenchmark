using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class LibraryMapperly
{
    [MapProperty(nameof(Library.Books), nameof(LibraryDto.BookCases))]
    public static partial LibraryDto Map(this Library lib);

    private static BookCase MapToCase(Book book) => new() { BookDto = book.MapToBookDto() };
}

[Mapper]
public static partial class BookMapperly
{
    [MapProperty(nameof(Book.Id), nameof(BookDto.BookId))]
    [MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    [MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    public static partial BookDto MapToBookDto(this Book book);
}