using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Models;

namespace WebApplication4.Service.FightSe
{
    public interface IFightService
    {
        Task<ServiceResponse<WeaponAttackResultDto>> WeaponAttack(WeaponAttackDto w);
        Task<ServiceResponse<WeaponAttackResultDto>> SkillAttack(SkillAttackDto w);
        Task<ServiceResponse<FightResultDto>> FightAttack(FightRequestDto w);
        Task<ServiceResponse<List<HighScoreDto>>> GetHighScore();
    }
}
