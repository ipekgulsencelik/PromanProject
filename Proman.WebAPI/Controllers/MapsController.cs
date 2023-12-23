using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.MapDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly IMapDAL _mapDAL;
        private readonly IMapper _mapper;

        public MapsController(IMapDAL mapDAL, IMapper mapper)
        {
            _mapDAL = mapDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MapList()
        {
            var values = _mapDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMap(CreateMapDTO createMapDTO)
        {
            var map = _mapper.Map<Map>(createMapDTO);
            _mapDAL.Insert(map);
            return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMap(string id)
        {
            _mapDAL.Delete(id);
            return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMap(string id)
        {
            var values = _mapDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMap(UpdateMapDTO updateMapDTO)
        {
            var updateMap = _mapper.Map<Map>(updateMapDTO);
            _mapDAL.Update(updateMap);
            return Ok("Lokasyon Bilgisi Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveMap")]
        public IActionResult GetActiveMap()
        {
            var values = _mapDAL.GetActiveMap();
            return Ok(values);
        }

        [HttpGet("ChangeMapStatus/{id}")]
        public IActionResult ChangeMapStatus(string id)
        {
            _mapDAL.ChangeMapStatus(id);
            return Ok("Lokasyon Bilgisinin Durum Değeri Değiştirildi");
        }
    }
}