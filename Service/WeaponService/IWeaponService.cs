using System.Threading.Tasks;
using WebApplication4.Dto;
using WebApplication4.Dto.CharacterDto;
using WebApplication4.Models;

namespace WebApplication4.Service.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);    }
}
