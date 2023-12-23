using AutoMapper;
using Proman.DTO.DTOs.ContactDTOs;
using Proman.DTO.DTOs.MapDTOs;
using Proman.DTO.DTOs.MessageDTOs;
using Proman.DTO.DTOs.ServiceDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();

            CreateMap<CreateMapDTO, Map>().ReverseMap();
            CreateMap<UpdateMapDTO, Map>().ReverseMap();

            CreateMap<CreateMessageDTO, Message>().ReverseMap();
            CreateMap<UpdateMessageDTO, Message>().ReverseMap();

            CreateMap<CreateServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
        }
    }
}