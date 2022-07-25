using System.Collections.Generic;

namespace WebApplication4.Models
{
    public class CharacterSkill
    {
        public int CharaceterId { get; set; }
        public Character Character { get; set; }
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
       

    }
}
