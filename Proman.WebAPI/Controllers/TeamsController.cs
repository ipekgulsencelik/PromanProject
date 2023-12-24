using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.TeamDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamDAL _teamDAL;
        private readonly IMapper _mapper;

        public TeamsController(ITeamDAL teamDAL, IMapper mapper)
        {
            _teamDAL = teamDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDTO createTeamDTO)
        {
            var team = _mapper.Map<Team>(createTeamDTO);
            _teamDAL.Insert(team);
            return Ok("Takım Üyesi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(string id)
        {
            _teamDAL.Delete(id);
            return Ok("Takım Üyesi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(string id)
        {
            var values = _teamDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTeam(UpdateTeamDTO updateTeamDTO)
        {
            var updateTeam = _mapper.Map<Team>(updateTeamDTO);
            _teamDAL.Update(updateTeam);
            return Ok("Takım Üyesi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveTeams")]
        public IActionResult GetActiveTeams()
        {
            var values = _teamDAL.GetActiveTeams();
            return Ok(values);
        }

        [HttpGet("ChangeTeamStatus/{id}")]
        public IActionResult ChangeTeamStatus(string id)
        {
            _teamDAL.ChangeTeamStatus(id);
            return Ok("Takım Üyesinin Durum Değeri Değiştirildi.");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _teamDAL.ChangeHomeStatus(id);
            return Ok("Takım Üyesinin Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast3ActiveTeams")]
        public IActionResult GetLast3ActiveTeams()
        {
            var values = _teamDAL.GetLast3ActiveTeams();
            return Ok(values);
        }
    }
}