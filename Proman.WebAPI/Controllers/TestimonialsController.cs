using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.TestimonialDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialDAL _testimonialDAL;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialDAL testimonialDAL, IMapper mapper)
        {
            _testimonialDAL = testimonialDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDTO);
            _testimonialDAL.Insert(testimonial);
            return Ok("Referans Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(string id)
        {
            _testimonialDAL.Delete(id);
            return Ok("Referans Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(string id)
        {
            var values = _testimonialDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var updateTestimonial = _mapper.Map<Testimonial>(updateTestimonialDTO);
            _testimonialDAL.Update(updateTestimonial);
            return Ok("Referans Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialDAL.GetActiveTestimonials();
            return Ok(values);
        }

        [HttpGet("ChangeTestimonialStatus/{id}")]
        public IActionResult ChangeTestimonialStatus(string id)
        {
            _testimonialDAL.ChangeTestimonialStatus(id);
            return Ok("Referansın Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _testimonialDAL.ChangeHomeStatus(id);
            return Ok("Referansın Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast3ActiveTestimonials")]
        public IActionResult GetLast3ActiveTestimonials()
        {
            var values = _testimonialDAL.GetLast3ActiveTestimonials();
            return Ok(values);
        }
    }
}