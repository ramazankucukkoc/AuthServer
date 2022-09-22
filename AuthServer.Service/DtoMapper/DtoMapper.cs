using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AutoMapper;

namespace AuthServer.Service.DtoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            //ReverseMap(); METODU hem ProductDto Product döner hemde Product ProductDto döner demektir.
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
