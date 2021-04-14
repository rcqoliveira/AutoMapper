using AutoMapper;
using RC.AutoMapper.Domains;

namespace RC.AutoMapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<ProductProfile, Product>().ReverseMap();
        }
    }
}
