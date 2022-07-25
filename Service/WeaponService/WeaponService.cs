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

namespace WebApplication4.Service.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext Context,IHttpContextAccessor ContextAccessor,IMapper mapper)
        {
            _context = Context;
            _contextAccessor = ContextAccessor;
         _mapper = mapper;
          
        }

        
      

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character ch = await _context.Characters.FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.User.Id == int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if(ch== null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                        return response;
                }
              Weapon weapon=  new Weapon
                {
                    Name = newWeapon.Name,
                    Damage = newWeapon.Damage,
                    Character = ch
                };
                await _context.Weapons.AddAsync(weapon);    
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(ch);
                return response;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
