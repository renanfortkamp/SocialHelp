using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialHelpApi.Context;
using SocialHelpApi.Models.Dto;
using SocialHelpApi.Models.Entities;

namespace SocialHelpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly ContextApi _context;

        private readonly IMapper _mapper;

        public GroupController(ContextApi context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroup(string? name)
        {
            try
            {
                if (name == null)
                {
                    return await _context.DbSetGroups.ToListAsync();
                }
                else
                {
                    return await _context.DbSetGroups.Where(g => g.Name.Contains(name)).ToListAsync();
                }
            }
            catch
            {
                
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        
        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupDto>> PostGroup(GroupDto @group)
        {
            try
            {
                var groupExist = await _context.DbSetGroups
                    .Where(g => g.Name == @group.Name)
                    .FirstOrDefaultAsync();
                if (groupExist != null)
                {
                    return BadRequest("Grupo já cadastrado");
                }
    
                var groupEntity = _mapper.Map<Group>(@group);
                _context.DbSetGroups.Add(groupEntity);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction("GetGroup", new { id = groupEntity.Id }, groupEntity);
            }
            catch
            {
                
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}
