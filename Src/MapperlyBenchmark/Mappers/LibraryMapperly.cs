using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class LibraryMapperly
{
    [ObjectFactory]
    private static BookDto CreateBookDto(Book book)
        => book.Map();

    public static partial LibraryDto Map(this Library lib);
}

[Mapper]
public static partial class BookMapperly
{
    [MapProperty(nameof(Book.Id), nameof(BookDto.BookId))]
    [MapProperty(nameof(Book.Author), nameof(BookDto.BookAuthor))]
    [MapProperty(nameof(Book.Title), nameof(BookDto.BookTitle))]
    public static partial BookDto Map(this Book lib);
}