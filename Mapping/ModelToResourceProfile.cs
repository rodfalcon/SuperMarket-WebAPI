using AutoMapper;
using Supermercado.Domain.Models;
using Supermercado.Resources;

namespace Supermercado.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}