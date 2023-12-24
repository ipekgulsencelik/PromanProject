using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.SocialMediaDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaDAL _socialMediaDAL;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaDAL socialMediaDAL, IMapper mapper)
        {
            _socialMediaDAL = socialMediaDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            var socialMedia = _mapper.Map<SocialMedia>(createSocialMediaDTO);
            _socialMediaDAL.Insert(socialMedia);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(string id)
        {
            _socialMediaDAL.Delete(id);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(string id)
        {
            var values = _socialMediaDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            var updateSocialMedia = _mapper.Map<SocialMedia>(updateSocialMediaDTO);
            _socialMediaDAL.Update(updateSocialMedia);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("ChangeSocialMediaStatus/{id}")]
        public IActionResult ChangeSocialMediaStatus(string id)
        {
            _socialMediaDAL.ChangeSocialMediaStatus(id);
            return Ok("Sosyal Medya Hesap Bilgisinin Durum Değeri Değiştirildi.");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _socialMediaDAL.ChangeHomeStatus(id);
            return Ok("Sosyal Medya Hesabının Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast4ActiveSocialMedias")]
        public IActionResult GetLast4ActiveSocialMedias()
        {
            var values = _socialMediaDAL.GetLast4ActiveSocialMedias();
            return Ok(values);
        }
    }
}