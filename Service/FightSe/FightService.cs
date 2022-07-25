using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Service.FightSe 
{ 
    public class FightService : IFightService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FightService(DataContext Context,IMapper mapper)
        {
            _context = Context;
          _mapper = mapper;
        }
        public async Task<ServiceResponse<WeaponAttackResultDto>> WeaponAttack(WeaponAttackDto w)
        {
            ServiceResponse<WeaponAttackResultDto> response = new ServiceResponse<WeaponAttackResultDto>();
      
            try
            {

                Character attacker = await _context.Characters.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == w.AttackerId);

                Character oppponent = await _context.Characters.FirstOrDefaultAsync(c => c.Id == w.OpponentId);

                if (attacker == null || oppponent == null)
                {
                    response.Data = new WeaponAttackResultDto();
                    response.Success = false;
                    response.Message = "Id does nOT Exist";
                    return response;
                }
                int damage = DoWeaponAttack(attacker, oppponent);
                if (oppponent.HitPoints <= 0)
                    response.Message = $"{oppponent.Name} has been defeated!";

                _context.Characters.Update(oppponent);
                await _context.SaveChangesAsync();


                response.Data = new WeaponAttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = oppponent.Name,
                    AttackerHP = attacker.HitPoints,
                    OpponentHP = oppponent.HitPoints,
                    Damage = damage

                };



            }
            catch (Exception ex)
            {
                response.Success=false;
                response.Message = ex.Message;
            }
            return response;
        }

        private static int DoWeaponAttack(Character attacker, Character oppponent)
        {
            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(oppponent.Defense);
            if (damage > 0) oppponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<WeaponAttackResultDto>> SkillAttack(SkillAttackDto w)
        {
            ServiceResponse<WeaponAttackResultDto> response = new ServiceResponse<WeaponAttackResultDto>();

            try
            {

                Character attacker = await _context.Characters.Include(c => c.CharacterSkills).ThenInclude(c => c.Skill).FirstOrDefaultAsync(c => c.Id == w.AttackerId);

                Character oppponent = await _context.Characters.FirstOrDefaultAsync(c => c.Id == w.OpponentId);

                CharacterSkill characterskill = await _context.CharacterSkills.FirstOrDefaultAsync(c => c.SkillId == w.SkilId);


                if (attacker == null || oppponent == null)
                {

                    response.Success = false;
                    response.Message = "Id does nOT Exist";
                    return response;
                }

                if (characterskill == null)
                {
                    response.Success = false;
                    response.Message = $"{attacker.Name} do not contain this type of skill";
                    return response;
                }
                int damage = DoSkillAttack(attacker, oppponent, characterskill);
                if (oppponent.HitPoints <= 0)
                    response.Message = $"{oppponent.Name} has been defeated!";

                _context.Characters.Update(oppponent);
                await _context.SaveChangesAsync();


                response.Data = new WeaponAttackResultDto
                {
                    Attacker = attacker.Name,
                    Opponent = oppponent.Name,
                    AttackerHP = attacker.HitPoints,
                    OpponentHP = oppponent.HitPoints,
                    Damage = damage

                };



            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private static int DoSkillAttack(Character attacker, Character oppponent, CharacterSkill characterskill)
        {
            int damage = characterskill.Skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(oppponent.Defense);
            if (damage > 0) oppponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<FightResultDto>> FightAttack(FightRequestDto w)
        {
            ServiceResponse<FightResultDto> response = new ServiceResponse<FightResultDto>
            {
                Data = new FightResultDto()
            };
            try
            {

                List<Character> Characters = await _context.Characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(c => c.Skill).Where(c => w.CharacterIds.Contains(c.Id)).ToListAsync();


                bool defeated = false;
                while (!defeated)
                {
                    foreach (Character attacker in Characters)
                    {
                        List<Character> Opponenets = Characters.Where(c => c.Id != attacker.Id).ToList();
                        Character opponent = Opponenets[new Random().Next(Opponenets.Count)];
                        int damage = 0;
                        string attackUsed = string.Empty;
                        bool useWeapon = new Random().Next(2) == 0;
                        if (useWeapon)
                        {
                            attackUsed = attacker.Weapon.Name;
                            damage = DoWeaponAttack(attacker, opponent);

                        }
                        else
                        {
                            int randomSkill = new Random().Next(attacker.CharacterSkills.Count);
                            attackUsed = attacker.CharacterSkills[randomSkill].Skill.Name;
                            damage = DoSkillAttack(attacker, opponent, attacker.CharacterSkills[randomSkill]);
                        }
                        response.Data.log.Add($"{attacker.Name} attacks on {opponent.Name} using {attackUsed} with {(damage >= 0 ? damage : 0)} damage.");
                        if (opponent.HitPoints <= 0)
                        {
                            defeated = true;
                            attacker.Victories++;
                            opponent.Defeats++;
                            response.Data.log.Add($"{opponent.Name} defeates the game");
                            response.Data.log.Add($"{attacker.Name} wins with {attacker.HitPoints} HP left");
                        }
                    }
                }
                Characters.ForEach(c =>
                {
                    c.Fights++;
                    c.HitPoints = 100;

                });
                _context.Characters.UpdateRange(Characters);
                await _context.SaveChangesAsync();  




            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;

            }
            return response;
        }

        public async Task<ServiceResponse<List<HighScoreDto>>> GetHighScore()
        {
            List<Character> characters = await _context.Characters.Where(c => c.Fights > 0).OrderByDescending(c => c.Victories).ThenBy(c => c.Defeats).ToListAsync();
            var response = new ServiceResponse<List<HighScoreDto>>
            {
                Data=characters.Select(c=>_mapper.Map<HighScoreDto>(c)).ToList(),
                
            };
            return response;
        }
    }
}
