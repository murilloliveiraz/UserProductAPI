using AutoMapper;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Profiles
{
    public class APIProfile : Profile
    {
        public APIProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<LoginUserDTO, User>().ReverseMap();
            CreateMap<CreateUserDTO, User>().ReverseMap();
        }
    }
}
