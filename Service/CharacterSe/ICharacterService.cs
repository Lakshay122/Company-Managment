using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;
using WebApplication4.Models;

namespace WebApplication4.Service.CharacterSe
{
    public interface ICharacterService
    {


      Task< ServiceResponse< List<GetCharacterDto>>> GetAll();
      Task< ServiceResponse< List<GetCharacterDto>>> DeleteCharacter(int id);
        Task<ServiceResponse<GetCharacterDto>> GetById(int id);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto up);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
    }
}
