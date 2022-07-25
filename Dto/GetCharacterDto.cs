using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.Dto.CharacterDto
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class
        { get; set; } = RpgClass.knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skill { get; set; }
        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
