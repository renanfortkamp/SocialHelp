
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialHelpApi.Context;
using SocialHelpApi.Models.Dto;
using SocialHelpApi.Models.Entities;

namespace SocialHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ContextApi _context;

        public UserController(ContextApi context)
        {
            _context = context;
        }

        // GET: api/user?email={email}&password={password}
        [HttpGet("{email}&{password}")]
        public async Task<ActionResult<User>> GetUser(string email, string password)
        {
            try
            {
                var user = await _context.DbSetUsers
                    .Where(u => u.Email == email && u.Password == password)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound("Usuário não localizado");
                }

                return user;
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser(UserDto userDto)
        {
            try
            {
                var userExist = await _context.DbSetUsers
                    .Where(u => u.Email == userDto.Email)
                    .FirstOrDefaultAsync();
                if (userExist != null)
                {
                    return BadRequest("Email já cadastrado");
                }

                var user = new User
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    Password = userDto.Password
                };
                _context.DbSetUsers.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}