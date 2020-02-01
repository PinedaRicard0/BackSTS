using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class AddingTeamEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    PoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PoolId",
                table: "Teams",
                column: "PoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
