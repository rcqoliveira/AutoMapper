using AutoMapper;
using RC.AutoMapper.Domains;
using RC.AutoMapper.Request;
using RC.AutoMapper.Response;

namespace RC.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, Product>()
                .ForMember(origin => origin.Suppliers, destiny => destiny.MapFrom(src => src.Suppliers))
                .ReverseMap();

            CreateMap<ProductResponse, Product>()
                .ForMember(origin => origin.Suppliers, destiny => destiny.MapFrom(src => src.Suppliers))
                .ReverseMap();
        }
    }
}