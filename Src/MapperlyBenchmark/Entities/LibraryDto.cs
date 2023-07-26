namespace MapperlyBenchmark.Entities;

public class LibraryDto
{
    public long Id { get; set; }
    public ICollection<BookCase> BookCases { get; set; } = Array.Empty<BookCase>();
}