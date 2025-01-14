using AutoMapper;
using IdentityService.Entitiess;
using IdentityService.Web_API.DTOS;

namespace IdentityService.Web_API.AutoMapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<CustomIdentityUser, UserDTO>().ReverseMap();
        }
    }
}
