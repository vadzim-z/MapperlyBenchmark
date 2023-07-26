namespace MapperlyBenchmark.Entities;

public class LibraryDto
{
    public long Id { get; set; }
    public IEnumerable<BookCase> BookCases { get; set; }
}