using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class SeedingCategoriesInitialPools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('A', 1)");
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('B', 1)");
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('A', 2)");
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('B', 2)");
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('A', 3)");
            migrationBuilder.Sql("INSERT INTO Pools VALUES ('B', 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'A' and CategoryId = 1");
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'B' and CategoryId = 1");
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'A' and CategoryId = 2");
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'B' and CategoryId = 2");
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'A' and CategoryId = 3");
            migrationBuilder.Sql("DELETE FROM Pools WHERE Name = 'B' and CategoryId = 3");
        }
    }
}
