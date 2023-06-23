using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterHunterBE.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "RareDescription",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "RareImageUrl",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "RareName",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SubDescriptiion",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SubImageUrl",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SubName",
                table: "Monsters");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RareDescription",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RareImageUrl",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RareName",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubDescriptiion",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubImageUrl",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubName",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
