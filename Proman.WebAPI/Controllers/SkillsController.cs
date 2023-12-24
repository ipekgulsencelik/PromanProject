using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.SkillDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillDAL _skillDAL;
        private readonly IMapper _mapper;

        public SkillsController(ISkillDAL skillDAL, IMapper mapper)
        {
            _skillDAL = skillDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SkillList()
        {
            var values = _skillDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSkill(CreateSkillDTO createSkillDTO)
        {
            var skill = _mapper.Map<Skill>(createSkillDTO);
            _skillDAL.Insert(skill);
            return Ok("Yetenek Bilgisi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(string id)
        {
            _skillDAL.Delete(id);
            return Ok("Yetenek Bilgisi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetSkill(string id)
        {
            var values = _skillDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSkill(UpdateSkillDTO updateSkillDTO)
        {
            var updateSkill = _mapper.Map<Skill>(updateSkillDTO);
            _skillDAL.Update(updateSkill);
            return Ok("Yetenek Bilgisi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveSkills")]
        public IActionResult GetActiveSkills()
        {
            var values = _skillDAL.GetActiveSkills();
            return Ok(values);
        }

        [HttpGet("ChangeSkillStatus/{id}")]
        public IActionResult ChangeSkillStatus(string id)
        {
            _skillDAL.ChangeSkillStatus(id);
            return Ok("Yetenek Bilgisinin Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _skillDAL.ChangeHomeStatus(id);
            return Ok("Yetenek Bilgisi Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast6ActiveSkills")]
        public IActionResult GetLast6ActiveSkills()
        {
            var values = _skillDAL.GetLast6ActiveSkills();
            return Ok(values);
        }
    }
}