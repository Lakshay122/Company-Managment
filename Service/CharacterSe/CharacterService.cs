using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;

namespace WebApplication4.Service.CharacterSe
{
    public class CharacterService : ICharacterService
    {
     private  readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public CharacterService (IMapper mapper,DataContext context,IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }


        private int GetId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string  GetRole() =>_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {

            ServiceResponse<List<GetCharacterDto>> s = new ServiceResponse<List<GetCharacterDto>>();
            Character ch = _mapper.Map<Character>(character);
            ch.User =  await _context.Users.FirstOrDefaultAsync(c=>c.Id==GetId());
           _context. Characters.Add(ch);
            await _context.SaveChangesAsync();
           
            s.Data = _context.Characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(c => c.Skill).Where(c=>c.User.Id==GetId()).Select(c=>_mapper.Map<GetCharacterDto>(c)).ToList();
            return s;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>> >GetAll()
        {

            var s=new ServiceResponse<List<GetCharacterDto>>();
            List<Character> DbCharacter =
                GetRole().Equals("Admin")?await _context.Characters.ToListAsync():
                await _context.Characters.Include(c=>c.Weapon).Include(c=>c.CharacterSkills).ThenInclude(c=>c.Skill).Where(c=>c.User.Id==GetId()).ToListAsync();
            s.Data = DbCharacter.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return s;

          
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
        {

            var s=new ServiceResponse<GetCharacterDto>();
            try
            {

            s.Data = _mapper.Map<GetCharacterDto>(await _context.Characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(c => c.Skill).FirstOrDefaultAsync(c=>c.Id==id&&c.User.Id==GetId()));
            }
            catch (Exception ex)
            {
                s.Success = false;
                s.Message = "ID DOES~NT EXIST";
            }
            return s;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto up)
        {
            ServiceResponse<GetCharacterDto> sd = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character ch = await _context.Characters.FirstOrDefaultAsync(c => c.Id == up.Id  && c.User.Id==GetId());
                if (ch == null)
                {
                    throw new Exception("jdsfksjf");
                //    throw "Id doesnot Exists";
                }
                ch.Name = up.Name;
                ch.Strength = up.Strength;
                ch.Defense = up.Defense;
                ch.HitPoints = up.HitPoints;
                ch.Intelligence = up.Intelligence;
                await _context.SaveChangesAsync();
                sd.Data = _mapper.Map<GetCharacterDto>(ch);
            }
          /*  catch (string ex)
            {
                sd.Success = false;
                sd.Message = "ID DOES~NT EXIST";
            }*/

            catch (Exception e)
            {
                sd.Success = false;
                sd.Message = "ID DOES~NT EXIST";
            }
            return sd;



        }

        public   async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var s = new ServiceResponse<List<GetCharacterDto>>();
            try
            {

               
                Character ch = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id&&c.User.Id==GetId());
                if (ch != null)
                {

                _context.Characters.Remove(ch);
                await _context.SaveChangesAsync();
                List<Character> DbCharacter = await _context.Characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(c => c.Skill).Where(c=>c.User.Id==GetId()).ToListAsync();
                s.Data = DbCharacter.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                }
                else
                {
                    s.Success = false;
                    s.Message = "ID DOES~NT EXIST";
                }
            }
            catch (Exception ex)
            {
                s.Success = false;
                s.Message = "ID DOES~NT EXIST";
            }
            return s;
        }
    }
}
