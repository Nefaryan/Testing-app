using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterHunterBE.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RareDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RareImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDescriptiion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonsterDrops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DropRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonsterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterDrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterDrops_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonsterWeaknesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeaknessPerc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonsterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterWeaknesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterWeaknesses_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterDrops_MonsterId",
                table: "MonsterDrops",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterWeaknesses_MonsterId",
                table: "MonsterWeaknesses",
                column: "MonsterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterDrops");

            migrationBuilder.DropTable(
                name: "MonsterWeaknesses");

            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
