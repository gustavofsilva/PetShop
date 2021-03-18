using Microsoft.EntityFrameworkCore.Migrations;

namespace back.Migrations
{
    public partial class PopulaAlojamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 10; i++)
            {
                migrationBuilder.Sql("INSERT INTO Alojamentos (Ocupado, AnimalId) VALUES ('Livre', null)");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Alojamentos");
        }
    }
}
