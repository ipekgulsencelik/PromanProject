using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.ExperienceDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceDAL _experienceDAL;
        private readonly IMapper _mapper;

        public ExperiencesController(IExperienceDAL experienceDAL, IMapper mapper)
        {
            _experienceDAL = experienceDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ExperienceList()
        {
            var values = _experienceDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateExperience(CreateExperienceDTO createExperienceDTO)
        {
            var experience = _mapper.Map<Experience>(createExperienceDTO);
            _experienceDAL.Insert(experience);
            return Ok("Deneyim Bilgisi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(string id)
        {
            _experienceDAL.Delete(id);
            return Ok("Deneyim Bilgisi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetExperience(string id)
        {
            var values = _experienceDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateExperience(UpdateExperienceDTO updateExperienceDTO)
        {
            var updateExperience = _mapper.Map<Experience>(updateExperienceDTO);
            _experienceDAL.Update(updateExperience);
            return Ok("Deneyim Bilgisi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveExperiences")]
        public IActionResult GetActiveExperiences()
        {
            var values = _experienceDAL.GetActiveExperiences();
            return Ok(values);
        }

        [HttpGet("ChangeExperienceStatus/{id}")]
        public IActionResult ChangeExperienceStatus(string id)
        {
            _experienceDAL.ChangeExperienceStatus(id);
            return Ok("Deneyim Bilgisinin Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _experienceDAL.ChangeHomeStatus(id);
            return Ok("Deneyim Bilgisi Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast4ActiveExperiences")]
        public IActionResult GetLast4ActiveExperiences()
        {
            var values = _experienceDAL.GetLast4ActiveExperiences();
            return Ok(values);
        }
    }
}