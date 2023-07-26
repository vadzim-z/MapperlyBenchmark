namespace MapperlyBenchmark.Entities;

public class Library
{
    public long Id { get; set; }
    public IEnumerable<Book> Books { get; set; }
}