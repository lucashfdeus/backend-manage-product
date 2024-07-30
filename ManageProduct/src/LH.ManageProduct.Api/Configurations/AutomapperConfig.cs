using AutoMapper;
using LH.ManageProduct.Api.ViewModels;
using LH.ManageProduct.Business.Models;

namespace LH.ManageProduct.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ProductViewModel, Product>()
            .ForMember(dest => dest.DepartmentCode, opt => opt
            .MapFrom(src => src.DepartmentCode))
            .ReverseMap()
            .ForMember(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.DepartmentCode));

            CreateMap<DepartmentViewModel, Department>().ReverseMap();

            CreateMap<Product, Department>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.DepartmentCode))
                .ReverseMap()
                .ForMember(dest => dest.DepartmentCode, opt => opt.MapFrom(src => src.Code));
        }
    }
}
