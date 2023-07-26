using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class LibraryMapperly
{
    public static partial LibraryDto Map(this Library lib);

    private static BookCase CreateBookCase(Book book)
        => book.MapBookCase();
}