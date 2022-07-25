using WebApplication4.Models;

namespace WebApplication4.Dto.CharacterDto
{
    public class AddCharacterDto
    {
       
        public string Name { get; set; }
        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class
        { get; set; } = RpgClass.knight;
    }
}
