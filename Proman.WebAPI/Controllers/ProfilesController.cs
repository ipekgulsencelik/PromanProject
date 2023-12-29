using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.ProfileDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMyProfileDAL _profileDAL;
        private readonly IMapper _mapper;

        public ProfilesController(IMyProfileDAL profileDAL, IMapper mapper)
        {
            _profileDAL = profileDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProfileList()
        {
            var values = _profileDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProfile(CreateProfileDTO createProfileDTO)
        {
            var profile = _mapper.Map<MyProfile>(createProfileDTO);
            _profileDAL.Insert(profile);
            return Ok("Profil Bilgisi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(string id)
        {
            _profileDAL.Delete(id);
            return Ok("Profil Bilgisi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(string id)
        {
            var values = _profileDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateProfile(UpdateProfileDTO updateProfileDTO)
        {
            var updateProfile = _mapper.Map<MyProfile>(updateProfileDTO);
            _profileDAL.Update(updateProfile);
            return Ok("Profil Bilgisi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveProfile")]
        public IActionResult GetActiveProfile()
        {
            var values = _profileDAL.GetActiveProfile();
            return Ok(values);
        }

        [HttpGet("ChangeProfileStatus/{id}")]
        public IActionResult ChangeProfileStatus(string id)
        {
            _profileDAL.ChangeProfileStatus(id);
            return Ok("Profil Bilgisinin Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _profileDAL.ChangeHomeStatus(id);
            return Ok("Profil Bilgisi Ana Sayfa Görünürlüğü Değiştirildi.");
        }
    }
}