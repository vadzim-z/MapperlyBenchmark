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
        //CreateMap<Book, BookCase>()
        //    .ForMember(dest => dest.BookDto.BookId, act => act.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.BookDto.BookTitle, act => act.MapFrom(src => src.Title))
        //    .ForMember(dest => dest.BookDto.BookAuthor, act => act.MapFrom(src => src.Author)); ;
    }
}