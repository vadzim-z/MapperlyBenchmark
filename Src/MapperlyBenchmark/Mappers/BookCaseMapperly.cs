using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class BookCaseMapperly
{
    [MapProperty(new[] { nameof(Book.Id) },
        new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookId) })]
    [MapProperty(new[] { nameof(Book.Author) },
        new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookAuthor) })]
    [MapProperty(new[] { nameof(Book.Title) },
        new[] { nameof(BookCase.BookDto), nameof(BookCase.BookDto.BookTitle) })]
    public static partial BookCase MapBookCase(this Book book);
}