using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Dto;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;
using WebApplication4.Models;
namespace WebApplication4.Service.CharacterSkillSe
{
    public class CharacterSkillService : ICharacterSkill
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public CharacterSkillService(DataContext Context, IHttpContextAccessor ContextAccessor, IMapper mapper)
        {
          _context = Context;
            _contextAccessor = ContextAccessor;
         _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkill newSkill)
        {

            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {

            Character ch = await _context.Characters.Include(c=>c.Weapon).Include(c=>c.CharacterSkills).ThenInclude(c=>c.Skill).FirstOrDefaultAsync(c => c.Id == newSkill.CharacterId && c.User.Id == int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (ch == null)
            {
                response.Success = false;
                response.Message = "Character not found";
                return response;
            }
            Skill skill = await _context.Skills.FirstOrDefaultAsync(c => c.Id == newSkill.SkillId);
            if(skill == null)
            {
                response.Success = false;
                response.Message = "Skill not found";
                return response;
            }
            CharacterSkill characterSkill = new CharacterSkill
            {
                Character = ch,
                Skill = skill
            };
            await _context.CharacterSkills.AddAsync(characterSkill);    
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterDto>(ch);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;
            }
            return response;
        }
    }
}
