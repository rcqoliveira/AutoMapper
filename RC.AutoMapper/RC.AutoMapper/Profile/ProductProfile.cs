using AutoMapper;
using RC.AutoMapper.Domains;

namespace RC.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<SupplierProfile, Supplier>().ReverseMap();
        }
    }
}
