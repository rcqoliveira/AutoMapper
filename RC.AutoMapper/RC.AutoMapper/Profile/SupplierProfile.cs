using AutoMapper;
using RC.AutoMapper.Domains;
using RC.AutoMapper.Request;
using RC.AutoMapper.Response;

namespace RC.AutoMapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierRequest, Supplier>().ReverseMap();
            CreateMap<SupplierResponse, Supplier>().ReverseMap();
        }
    }
}
