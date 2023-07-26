namespace MapperlyBenchmark.Entities;

public class BookCase
{
    public long Id { get; set; }
    public string Text { get; set; }
    public BookDto BookDto { get; init; }
}