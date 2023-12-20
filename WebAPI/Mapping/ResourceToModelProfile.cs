using AutoMapper;
using WebAPI.Models;
using WebAPI.Resources;

namespace WebAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<CategoryResource, Category>();
        }
    }
}
