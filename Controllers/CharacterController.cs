using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;
using WebApplication4.Service.CharacterSe;

namespace WebApplication3.Controllers
{
    [Authorize(Roles="Player,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController:ControllerBase
    {
      private readonly ICharacterService _characterservic;

        public CharacterController(ICharacterService characterservic)
        {
            _characterservic = characterservic;
        }
      
    
        [HttpGet("GetAll")]
      
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterservic.GetAll());
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var response = await _characterservic.GetById(id);
            if(!response.Success)
            {
                return BadRequest(response);    
            }
            return Ok(response);

        }


        [HttpPost]
        public async  Task<IActionResult> AddCharacter(AddCharacterDto ch)
        {
          
            return Ok( await _characterservic.AddCharacter(ch));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCharacteR(UpdateCharacterDto up)
        {
            var response = await _characterservic.UpdateCharacter(up);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpDelete]
        public async Task<IActionResult> deleteCharacter(int id)
        {
           var response = await _characterservic.DeleteCharacter(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
