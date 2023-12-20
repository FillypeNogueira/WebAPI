using AutoMapper;
using WebAPI.Models;
using WebAPI.Resources;

namespace WebAPI.Mapping
{
    public class ModelToResourceProfile : Profile 
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<Category, CategoryResource>();
        }
    }
}
