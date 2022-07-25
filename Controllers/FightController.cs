using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Service.FightSe;

namespace WebApplication4.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FightController:ControllerBase
    {
        private readonly IFightService _fightService;

        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }
        [HttpPost("Weapon")]
        public async Task<IActionResult> Weaponfight(WeaponAttackDto w)
        {
            return Ok(await _fightService.WeaponAttack(w));
        }

        [HttpPost("SKILL")]
        public async Task<IActionResult> Skillfight(SkillAttackDto w)
        {
            return Ok(await _fightService.SkillAttack(w));
        }
        [HttpPost]
        public async Task<IActionResult> FightAttack(FightRequestDto w)
        {
            return Ok(await _fightService.FightAttack(w));
        } 
        [HttpGet]
        public async Task<IActionResult> GetHighScore()
        {
            return Ok(await _fightService.GetHighScore());
        }
    }
}
