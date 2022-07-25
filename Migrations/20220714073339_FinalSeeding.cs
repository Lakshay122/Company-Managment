using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class FinalSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharaceterId", "SkillId", "CharacterId" },
                values: new object[] { 1, 2, null });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharaceterId", "SkillId", "CharacterId" },
                values: new object[] { 2, 1, null });

            migrationBuilder.InsertData(
                table: "CharacterSkills",
                columns: new[] { "CharaceterId", "SkillId", "CharacterId" },
                values: new object[] { 2, 3, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 1, new byte[] { 191, 65, 239, 223, 194, 53, 155, 147, 243, 99, 172, 11, 171, 122, 119, 55, 112, 115, 233, 55, 219, 12, 253, 194, 159, 214, 160, 78, 137, 66, 81, 74, 156, 15, 224, 65, 151, 98, 75, 98, 203, 146, 174, 82, 209, 190, 185, 213, 54, 137, 7, 4, 169, 147, 16, 0, 150, 112, 33, 114, 30, 14, 55, 34 }, new byte[] { 1, 61, 10, 29, 40, 251, 222, 67, 255, 199, 226, 19, 185, 134, 100, 187, 196, 167, 6, 97, 36, 210, 63, 127, 179, 243, 67, 150, 93, 14, 20, 127, 193, 168, 169, 167, 147, 245, 91, 249, 203, 109, 26, 187, 206, 135, 45, 236, 58, 163, 183, 189, 62, 246, 99, 216, 232, 163, 72, 226, 139, 248, 71, 21, 139, 66, 81, 207, 82, 163, 238, 124, 186, 215, 194, 18, 72, 150, 195, 57, 92, 108, 179, 69, 230, 254, 178, 201, 227, 54, 34, 150, 34, 127, 221, 184, 22, 38, 151, 81, 129, 237, 194, 133, 233, 171, 140, 180, 121, 80, 63, 117, 67, 111, 155, 153, 167, 210, 96, 120, 62, 83, 70, 59, 41, 120, 29, 163 }, "User1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 2, new byte[] { 191, 65, 239, 223, 194, 53, 155, 147, 243, 99, 172, 11, 171, 122, 119, 55, 112, 115, 233, 55, 219, 12, 253, 194, 159, 214, 160, 78, 137, 66, 81, 74, 156, 15, 224, 65, 151, 98, 75, 98, 203, 146, 174, 82, 209, 190, 185, 213, 54, 137, 7, 4, 169, 147, 16, 0, 150, 112, 33, 114, 30, 14, 55, 34 }, new byte[] { 1, 61, 10, 29, 40, 251, 222, 67, 255, 199, 226, 19, 185, 134, 100, 187, 196, 167, 6, 97, 36, 210, 63, 127, 179, 243, 67, 150, 93, 14, 20, 127, 193, 168, 169, 167, 147, 245, 91, 249, 203, 109, 26, 187, 206, 135, 45, 236, 58, 163, 183, 189, 62, 246, 99, 216, 232, 163, 72, 226, 139, 248, 71, 21, 139, 66, 81, 207, 82, 163, 238, 124, 186, 215, 194, 18, 72, 150, 195, 57, 92, 108, 179, 69, 230, 254, 178, 201, 227, 54, 34, 150, 34, 127, 221, 184, 22, 38, 151, 81, 129, 237, 194, 133, 233, 171, 140, 180, 121, 80, 63, 117, 67, 111, 155, 153, 167, 210, 96, 120, 62, 83, 70, 59, 41, 120, 29, 163 }, "User2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 3, new byte[] { 191, 65, 239, 223, 194, 53, 155, 147, 243, 99, 172, 11, 171, 122, 119, 55, 112, 115, 233, 55, 219, 12, 253, 194, 159, 214, 160, 78, 137, 66, 81, 74, 156, 15, 224, 65, 151, 98, 75, 98, 203, 146, 174, 82, 209, 190, 185, 213, 54, 137, 7, 4, 169, 147, 16, 0, 150, 112, 33, 114, 30, 14, 55, 34 }, new byte[] { 1, 61, 10, 29, 40, 251, 222, 67, 255, 199, 226, 19, 185, 134, 100, 187, 196, 167, 6, 97, 36, 210, 63, 127, 179, 243, 67, 150, 93, 14, 20, 127, 193, 168, 169, 167, 147, 245, 91, 249, 203, 109, 26, 187, 206, 135, 45, 236, 58, 163, 183, 189, 62, 246, 99, 216, 232, 163, 72, 226, 139, 248, 71, 21, 139, 66, 81, 207, 82, 163, 238, 124, 186, 215, 194, 18, 72, 150, 195, 57, 92, 108, 179, 69, 230, 254, 178, 201, 227, 54, 34, 150, 34, 127, 221, 184, 22, 38, 151, 81, 129, 237, 194, 133, 233, 171, 140, 180, 121, 80, 63, 117, 67, 111, 155, 153, 167, 210, 96, 120, 62, 83, 70, 59, 41, 120, 29, 163 }, "User3" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 1, 1, 0, 30, 0, 100, 30, "Frado", 15, 1, 0 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Class", "Defeats", "Defense", "Fights", "HitPoints", "Intelligence", "Name", "Strength", "UserId", "Victories" },
                values: new object[] { 2, 2, 0, 40, 0, 100, 40, "ras", 20, 2, 0 });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 1, 1, 20, "AKM" });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "CharacterId", "Damage", "Name" },
                values: new object[] { 2, 2, 100, "awm" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharaceterId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharaceterId", "SkillId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterSkills",
                keyColumns: new[] { "CharaceterId", "SkillId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
