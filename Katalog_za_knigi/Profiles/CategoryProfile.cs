using AutoMapper;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.DTOs;

namespace Katalog_za_knigi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
        }
    }
}
