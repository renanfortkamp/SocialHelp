
using AutoMapper;
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

        private readonly IMapper _mapper;

        public UserController(ContextApi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/user?username={username}&password={password}
        [HttpGet("{username}&{password}")]
        public async Task<ActionResult<User>> GetUser(string username, string password)
        {
            try
            {
                var user = await _context.DbSetUsers
                    .Where(u => u.UserName == username && u.Password == password)
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

                // var user = new User
                // {
                //     UserName = userDto.UserName,
                //     Email = userDto.Email,
                //     Password = userDto.Password
                // };

                var user = _mapper.Map<User>(userDto);

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
