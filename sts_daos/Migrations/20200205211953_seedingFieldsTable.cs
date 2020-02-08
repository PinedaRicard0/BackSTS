using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class seedingFieldsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Fields VALUES ('Revenidero', 'Cancha en buen estado', 'Frente al coliseo ppal')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Fields WHERE Name = 'Revenidero'");
        }
    }
}
