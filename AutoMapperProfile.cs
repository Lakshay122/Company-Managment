using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;
using AutoMapper;
using System;
using WebApplication4.Dto;
using System.Linq;

namespace WebApplication4
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Character, GetCharacterDto>()
                .ForMember(dto=>dto.Skill,c=>c.MapFrom(c=>c.CharacterSkills.Select(cs
                =>cs.Skill)));
           CreateMap<AddCharacterDto, Character>();
          
           CreateMap<Weapon, GetWeaponDto>();
           CreateMap<Skill, GetSkillDto>();
           CreateMap<Character, HighScoreDto>();
            
        }

       
    }
}
