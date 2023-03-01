using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialHelpApi.Context;
using SocialHelpApi.Models.Dto;
using SocialHelpApi.Models.Entities;

namespace Sweeter.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<MessageAllDto>>> GetMessages(int? numPosts)
        {
            var messages = _context.DbSetMessages.OrderByDescending(s => s.DateMessage);
            if (numPosts.HasValue)
            {
                messages = (IOrderedQueryable<Message>)messages.Take(numPosts.Value);
            }

            var sweetResponse = await messages 
                .Select(s => _mapper.Map<MessageAllDto>(s))
                .ToListAsync();

            return Ok(sweetResponse);
        }

        // GET: api/message/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id, int userId)
        {
            var sweet = await _context.DbSetMessages
                .Where(u => u.Id == id && u.UserId == userId)
                .FirstOrDefaultAsync();

            if (sweet == null)
            {
                return NotFound("Message não localizado");
            }

            return sweet;
        }

        // PUT: api/message/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSweet(int id, int userId, [FromBody] Message sweet)
        {
            if (id != sweet.Id || userId != sweet.UserId)
            {
                return BadRequest("Você tem que passar o id correto"); //retirar com atualização da dto
            }
            var existSweet = await _context.DbSetMessages.FirstOrDefaultAsync(
                s => s.Id == id && s.UserId == userId
            );
            if (existSweet == null)
            {
                return BadRequest("Message não encontrado");
            }

            _context.Entry(sweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/message
        [HttpPost]
        public async Task<ActionResult<MessageDto>> PostSweet(int userId, MessageDto sweetDto)
        {
            var existUser = await _context.DbSetUsers.FirstOrDefaultAsync(s => s.Id == userId);
            if (existUser == null)
            {
                return BadRequest("Usuario não encontrado");
            }

            Message message = new();
            message.Text = sweetDto.Text;
            message.UserId = userId;
            _context.DbSetMessages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSweet", new { id = message.Id }, message);
        }

        // DELETE: api/message/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSweet(int id)
        {
            var sweet = await _context.DbSetMessages.FindAsync(id);
            if (sweet == null)
            {
                return NotFound();
            }

            _context.DbSetMessages.Remove(sweet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExist(int id)
        {
            return _context.DbSetMessages.Any(e => e.Id == id);
        }
    }
}
