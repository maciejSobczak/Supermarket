using AutoMapper;
using supermarket.api.Resources;
using Supermarket.API.Domain.Models;

namespace supermarket.api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}
