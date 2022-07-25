using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;

namespace WebApplication4.Service.CharacterSkillSe
{
    public interface ICharacterSkill
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkill ch);
    }
}
