using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class SeedingCommonCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Male', 'For men')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Female', 'For women')");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Mixed', 'For anybody')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories WHERE Name = 'Male'");
            migrationBuilder.Sql("DELETE FROM Categories WHERE Name = 'Female'");
            migrationBuilder.Sql("DELETE FROM Categories WHERE Name = 'Mixed'");
        }
    }
}
