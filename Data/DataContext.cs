using Microsoft.EntityFrameworkCore;
using System;
using WebApplication4.Controllers;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class DataContext: Microsoft.EntityFrameworkCore.DbContext

    {
       
        public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        {
           
        }
        public Microsoft.EntityFrameworkCore.DbSet<Character> Characters { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        public  DbSet<Weapon> Weapons { get; set; }
        public  DbSet<Skill> Skills { get; set; }
        public  DbSet<CharacterSkill> CharacterSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>().
                HasKey(cs => new { cs.CharaceterId, cs.SkillId });

            modelBuilder.Entity<User>().Property(user => user.Role)
                .HasDefaultValue("Player");

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id=1,Name="Fireball",Damage=30},
                new Skill { Id=2,Name="Frenchy",Damage=20},
                new Skill { Id=3,Name="Blizaard",Damage=50}
                );
            Utility.CreatePasswordHash("123456",out byte[] PasswordHash, out byte[] PasswordSalt);
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, UserName = "User1" },
                new User { Id = 2, PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, UserName = "User2" },
                new User { Id = 3, PasswordHash = PasswordHash, PasswordSalt = PasswordSalt, UserName = "User3" }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Frado",
                    Class = RpgClass.knight,
                    HitPoints = 100,
                    Strength = 15,
                    Defense = 30,
                    Intelligence = 30,
                    UserId = 1
                } ,
                new Character
                {
                    Id = 2,
                    Name = "ras",
                    Class = RpgClass.mage,
                    HitPoints = 100,
                    Strength = 20,
                    Defense = 40,
                    Intelligence = 40,
                    UserId = 2
                }
                ) ;
            modelBuilder.Entity<Weapon>().HasData(
                new Weapon { Id = 1, Name = "AKM", Damage = 20, CharacterId = 1 },
                new Weapon { Id = 2, Name = "awm", Damage = 100, CharacterId = 2 }

                );
            modelBuilder.Entity<CharacterSkill>().HasData(
                new CharacterSkill { CharaceterId = 1, SkillId = 2 },
                new CharacterSkill { CharaceterId = 2, SkillId = 1 },
                new CharacterSkill { CharaceterId = 2, SkillId = 3 }

                );
        } 
    }
}
