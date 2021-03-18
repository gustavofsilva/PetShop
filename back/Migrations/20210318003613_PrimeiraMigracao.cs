using Microsoft.EntityFrameworkCore.Migrations;

namespace back.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonosAnimais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonosAnimais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    MotivoInternacao = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    EstadoSaude = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Foto = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    DonoAnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animais_DonosAnimais_DonoAnimalId",
                        column: x => x.DonoAnimalId,
                        principalTable: "DonosAnimais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alojamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ocupado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alojamentos_Animais_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alojamentos_AnimalId",
                table: "Alojamentos",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_DonoAnimalId",
                table: "Animais",
                column: "DonoAnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamentos");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "DonosAnimais");
        }
    }
}
