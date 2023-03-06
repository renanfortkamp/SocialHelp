using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialHelpApi.Context;
using SocialHelpApi.Models.Dto;
using SocialHelpApi.Models.Entities;

namespace Sweeter.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ContextApi _context;
        private readonly IMapper _mapper;
        

        public MessageController(ContextApi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageAllDto>>> GetMessages(int? numPosts,int? groupId)
        {
            var messages = await _context.DbSetMessages.OrderByDescending(s => s.DateMessage).ToListAsync();
            if (numPosts.HasValue)
            {
                messages = messages.Take(numPosts.Value).ToList();
            }
            if (groupId.HasValue)
            {
                messages = messages.Where(s => s.GroupId == groupId.Value).ToList();
            }
            var messageResponse = _mapper.Map<List<MessageAllDto>>(messages);
            return Ok(messageResponse);
        }

        // GET: api/messages/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<MessageAllDto>>> GetMessagesUser(int userId)
        {
            var messagesUser = await _context.DbSetMessages
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.DateMessage)
                .ToListAsync();
            if (messagesUser == null)
            {
                return NotFound("Mensagens não encontradas");
            }

            var messageResponse = messagesUser
                .Select(s => _mapper.Map<MessageAllDto>(s))
                .ToList();




            return Ok(messageResponse);
        }

        // PUT: api/message/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(
            int id,
            int userId,
            [FromBody] MessageDto message
        )
        {
            try
            {
                var messageUpdate = await _context.DbSetMessages.FirstOrDefaultAsync(
                    s => s.Id == id && s.UserId == userId
                );
                if (messageUpdate == null)
                {
                    return BadRequest("Message não encontrado");
                }

                messageUpdate.Text = message.Text;
                messageUpdate.DateMessage = DateTime.Now;
                messageUpdate.Edit = true;

                

                _context.Entry(messageUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(messageUpdate);
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // POST: api/message
        [HttpPost]
        public async Task<ActionResult<MessageDto>> PostSweet(int userId, MessageDto messageDto)
        {
            try
            {
                var existUser = await _context.DbSetUsers.FirstOrDefaultAsync(s => s.Id == userId);
                if (existUser == null)
                {
                    return BadRequest("Usuario não encontrado");
                }
    
                var message = _mapper.Map<Message>(messageDto);
                message.UserId = existUser.Id;
                message.UserName = existUser.UserName;
                message.GroupId = existUser.GroupId;
                _context.DbSetMessages.Add(message);
                await _context.SaveChangesAsync();

                var messageResponse = _mapper.Map<MessageAllDto>(message);
    
                return Ok(messageResponse);
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // DELETE: api/message/5
        [HttpDelete("{userId}&{id}")]
        public async Task<IActionResult> DeleteMessage(int userId, int id)
        {
           try
           {
             var message = await _context.DbSetMessages
                 .Where(s => s.UserId == userId && s.Id == id)
                 .FirstOrDefaultAsync();
             if (message == null)
             {
                 return BadRequest("Mensagem não encontrada");
             }
 
             _context.DbSetMessages.Remove(message);
             await _context.SaveChangesAsync();
 
             return Ok("Mensagem excluida com sucesso");
           }
           catch
           {
                return StatusCode(500, "Erro interno do servidor");
           }
        }

        
    }
}
