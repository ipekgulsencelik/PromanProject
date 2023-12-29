using AutoMapper;
using Proman.EntityLayer.Concrete;
using Proman.WebUI.DTOs.ProfileDTOs;

namespace Proman.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateProfileDTO, MyProfile>().ReverseMap();
            CreateMap<UpdateProfileDTO, MyProfile>().ReverseMap();
            CreateMap<ResultProfileDTO, MyProfile>().ReverseMap();
        }
    }
}