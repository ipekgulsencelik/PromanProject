using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.ContactDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactDAL _contactDAL;
        private readonly IMapper _mapper;

        public ContactsController(IContactDAL contactDAL, IMapper mapper)
        {
            _contactDAL = contactDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            var contact = _mapper.Map<Contact>(createContactDTO);
            _contactDAL.Insert(contact);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(string id)
        {
            _contactDAL.Delete(id);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(string id)
        {
            var values = _contactDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            var updateContact = _mapper.Map<Contact>(updateContactDTO);
            _contactDAL.Update(updateContact);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetActiveContact")]
        public IActionResult GetActiveContact()
        {
            var values = _contactDAL.GetActiveContact();
            return Ok(values);
        }

        [HttpGet("ChangeContactStatus/{id}")]
        public IActionResult ChangeContactStatus(string id)
        {
            _contactDAL.ChangeContactStatus(id);
            return Ok("İletişim Bilgilerinin Durum Değeri Değiştirildi");
        }
    }
}