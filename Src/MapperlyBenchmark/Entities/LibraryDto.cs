namespace MapperlyBenchmark.Entities;

public class LibraryDto
{
    public long Id { get; set; }
    public IEnumerable<BookDto> Books { get; init; }
}