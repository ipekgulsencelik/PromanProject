using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.ProjectTypeDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypesController : ControllerBase
    {
        private readonly IProjectTypeDAL _projectTypeDAL;
        private readonly IMapper _mapper;

        public ProjectTypesController(IProjectTypeDAL projectTypeDAL, IMapper mapper)
        {
            _projectTypeDAL = projectTypeDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProjectTypeList()
        {
            var values = _projectTypeDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProjectType(CreateProjectTypeDTO createProjectTypeDTO)
        {
            var projectType = _mapper.Map<ProjectType>(createProjectTypeDTO);
            _projectTypeDAL.Insert(projectType);
            return Ok("Proje Türü Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProjectType(string id)
        {
            _projectTypeDAL.Delete(id);
            return Ok("Proje Türü Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectType(string id)
        {
            var values = _projectTypeDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateProjectType(UpdateProjectTypeDTO updateProjectTypeDTO)
        {
            var updateProjectType = _mapper.Map<ProjectType>(updateProjectTypeDTO);
            _projectTypeDAL.Update(updateProjectType);
            return Ok("Proje Türü Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveProjectTypes")]
        public IActionResult GetActiveProjectTypes()
        {
            var values = _projectTypeDAL.GetActiveProjectTypes();
            return Ok(values);
        }

        [HttpGet("ChangeProjectTypeStatus/{id}")]
        public IActionResult ChangeProjectTypeStatus(string id)
        {
            _projectTypeDAL.ChangeProjectTypeStatus(id);
            return Ok("Proje Türünün Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _projectTypeDAL.ChangeHomeStatus(id);
            return Ok("Proje Türü Ana Sayfa Görünürlüğü Değiştirildi.");
        }

        [HttpGet("GetLast2ActiveProjectTypes")]
        public IActionResult GetLast2ActiveProjectTypes()
        {
            var values = _projectTypeDAL.GetLast2ActiveProjectTypes();
            return Ok(values);
        }
    }
}