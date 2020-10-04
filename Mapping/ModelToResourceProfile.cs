using AutoMapper;
using supermarket.api.Resources;
using Supermarket.API.Domain.Models;

namespace supermarket.api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}
