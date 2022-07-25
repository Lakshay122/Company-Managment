using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Service.CharacterSkillSe;

namespace WebApplication4.Controllers
{
    [Authorize]
    [Route("[CONTROLLER]")]
    [ApiController]
    public class CharacterSkillController: ControllerBase
    {
        private readonly ICharacterSkill _characterskillService;

        public CharacterSkillController(ICharacterSkill characterskillService)
        {
           _characterskillService = characterskillService;
        }
        [HttpPost]
        public async Task<IActionResult> PostCharacterSkill(AddCharacterSkill newcharacterSkill)
        {
            return Ok(await _characterskillService.AddCharacterSkill(newcharacterSkill));
        }

    }
}
