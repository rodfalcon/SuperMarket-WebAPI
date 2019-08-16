using AutoMapper;
using Supermercado.Domain.Models;
using Supermercado.Extensions;
using Supermercado.Resources;

namespace Supermercado.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Products, ProductResource>().ForMember(src => src.UnitOfMeasurement,
            opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString())); 
//This syntax tells AutoMapper to use the new extension method to convert the EUnitOfMeasurement value into a string containing its description
        }
    }
}
