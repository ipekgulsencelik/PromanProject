using AutoMapper;
using Proman.DTO.DTOs.ContactDTOs;
using Proman.DTO.DTOs.EducationDTOs;
using Proman.DTO.DTOs.ExperienceDTOs;
using Proman.DTO.DTOs.MapDTOs;
using Proman.DTO.DTOs.MessageDTOs;
using Proman.DTO.DTOs.ProfileDTOs;
using Proman.DTO.DTOs.ProjectTypeDTOs;
using Proman.DTO.DTOs.ServiceDTOs;
using Proman.DTO.DTOs.SkillDTOs;
using Proman.DTO.DTOs.SocialMediaDTOs;
using Proman.DTO.DTOs.TeamDTOs;
using Proman.DTO.DTOs.TestimonialDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();

            CreateMap<CreateEducationDTO, Education>().ReverseMap();
            CreateMap<UpdateEducationDTO, Education>().ReverseMap();

            CreateMap<CreateExperienceDTO, Experience>().ReverseMap();
            CreateMap<UpdateExperienceDTO, Experience>().ReverseMap();

            CreateMap<CreateMapDTO, Map>().ReverseMap();
            CreateMap<UpdateMapDTO, Map>().ReverseMap();

            CreateMap<CreateMessageDTO, Message>().ReverseMap();
            CreateMap<UpdateMessageDTO, Message>().ReverseMap();

            CreateMap<CreateProfileDTO, MyProfile>().ReverseMap();
            CreateMap<UpdateProfileDTO, MyProfile>().ReverseMap();

            CreateMap<CreateProjectTypeDTO, ProjectType>().ReverseMap();
            CreateMap<UpdateProjectTypeDTO, ProjectType>().ReverseMap();

            CreateMap<CreateServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();

            CreateMap<CreateSkillDTO, Skill>().ReverseMap();
            CreateMap<UpdateSkillDTO, Skill>().ReverseMap();

            CreateMap<CreateSocialMediaDTO, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDTO, SocialMedia>().ReverseMap();

            CreateMap<CreateTeamDTO, Team>().ReverseMap();
            CreateMap<UpdateTeamDTO, Team>().ReverseMap();

            CreateMap<CreateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO, Testimonial>().ReverseMap();
        }
    }
}