using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.ServiceDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceDAL _serviceDAL;
        private readonly IMapper _mapper;

        public ServicesController(IServiceDAL serviceDAL, IMapper mapper)
        {
            _serviceDAL = serviceDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateService(CreateServiceDTO createServiceDTO)
        {
            var service = _mapper.Map<Service>(createServiceDTO);
            _serviceDAL.Insert(service);
            return Ok("Hizmet Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(string id)
        {
            _serviceDAL.Delete(id);
            return Ok("Hizmet Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetService(string id)
        {
            var values = _serviceDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDTO updateServiceDTO)
        {
            var updateService = _mapper.Map<Service>(updateServiceDTO);
            _serviceDAL.Update(updateService);
            return Ok("Hizmet Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveServices")]
        public IActionResult GetActiveServices()
        {
            var values = _serviceDAL.GetActiveServices();
            return Ok(values);
        }

        [HttpGet("ChangeServiceStatus/{id}")]
        public IActionResult ChangeServiceStatus(string id)
        {
            _serviceDAL.ChangeServiceStatus(id);
            return Ok("Hizmet Bilgisinin Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(string id)
        {
            _serviceDAL.ChangeHomeStatus(id);
            return Ok("Hizmet Ana Sayfa Görünürlüğü Değiştirildi");
        }

        [HttpGet("GetLast4Services")]
        public IActionResult GetLast4Services()
        {
            var values = _serviceDAL.GetLast4Services();
            return Ok(values);
        }
    }
}