using AutoMapper;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.DTOs;

namespace Katalog_za_knigi.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();
        }
    }
}
