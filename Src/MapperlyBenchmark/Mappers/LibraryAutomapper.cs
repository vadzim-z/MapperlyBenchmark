using AutoMapper;
using MapperlyBenchmark.Entities;

namespace MapperlyBenchmark.Mappers;

public class LibraryAutomapper : Profile
{
    public LibraryAutomapper()
    {
        CreateMap<Library, LibraryDto>();
    }
}

public class BookAutomapper : Profile
{
    public BookAutomapper()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.BookId, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.BookTitle, act => act.MapFrom(src => src.Title))
            .ForMember(dest => dest.BookAuthor, act => act.MapFrom(src => src.Author)); ;
    }
}