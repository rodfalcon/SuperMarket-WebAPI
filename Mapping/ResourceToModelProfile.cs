using AutoMapper;
using Supermercado.Domain.Models;
using Supermercado.Resources;

namespace Supermercado.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}