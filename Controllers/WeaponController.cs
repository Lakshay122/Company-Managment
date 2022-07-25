using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Service.WeaponService;

namespace WebApplication4.Controllers
{
    [Authorize]
    [Route("[Controller]")]
    [ApiController]
    public class WeaponController:ControllerBase
    {
        private readonly IWeaponService _weapon;

        public WeaponController(IWeaponService weapon)
        {
           _weapon = weapon;
        }
        [HttpPost("Add")]

        public async Task<IActionResult> AddWeapon(AddWeaponDto w)
        {
            var response=await _weapon.AddWeapon(w);
            if (response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
