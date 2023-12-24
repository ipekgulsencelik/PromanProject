using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.EducationDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationDAL _educationDAL;
        private readonly IMapper _mapper;

        public EducationsController(IEducationDAL educationDAL, IMapper mapper)
        {
            _educationDAL = educationDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult EducationList()
        {
            var values = _educationDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateEducation(CreateEducationDTO createEducationDTO)
        {
            var education = _mapper.Map<Education>(createEducationDTO);
            _educationDAL.Insert(education);
            return Ok("Eğitim Bilgisi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(string id)
        {
            _educationDAL.Delete(id);
            return Ok("Eğitim Bilgisi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetEducation(string id)
        {
            var values = _educationDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateEducation(UpdateEducationDTO updateEducationDTO)
        {
            var updateEducation = _mapper.Map<Education>(updateEducationDTO);
            _educationDAL.Update(updateEducation);
            return Ok("Eğitim Bilgisi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveEducations")]
        public IActionResult GetActiveEducations()
        {
            var values = _educationDAL.GetActiveEducations();
            return Ok(values);
        }

        [HttpGet("ChangeEducationStatus/{id}")]
        public IActionResult ChangeEducationStatus(string id)
        {
            _educationDAL.ChangeEducationStatus(id);
            return Ok("Eğitim Bilgisinin Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _educationDAL.ChangeHomeStatus(id);
            return Ok("Eğitim Bilgisi Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast4ActiveEducations")]
        public IActionResult GetLast4ActiveEducations()
        {
            var values = _educationDAL.GetLast4ActiveEducations();
            return Ok(values);
        }
    }
}