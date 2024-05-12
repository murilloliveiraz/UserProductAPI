using AutoMapper;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
