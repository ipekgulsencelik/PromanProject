using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Proman.DataAccessLayer.Abstract;
using Proman.DTO.DTOs.MessageDTOs;
using Proman.EntityLayer.Concrete;

namespace Proman.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageDAL _messageDAL;
        private readonly IMapper _mapper;

        public MessagesController(IMessageDAL messageDAL, IMapper mapper)
        {
            _messageDAL = messageDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageDAL.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            _messageDAL.Insert(message);
            return Ok("Mesaj Başarılı Bir Şekilde Eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(string id)
        {
            _messageDAL.Delete(id);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(string id)
        {
            var values = _messageDAL.GetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var updateMessage = _mapper.Map<Message>(updateMessageDTO);
            _messageDAL.Update(updateMessage);
            return Ok("Mesaj Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("ChangeMessageStatus/{id}")]
        public IActionResult ChangeMessageStatus(string id)
        {
            _messageDAL.ChangeMessageStatus(id);
            return Ok("Mesaj Durum Değeri Değiştirildi");
        }
    }
}