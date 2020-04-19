using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class TableTeamStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamsStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(nullable: false),
                    Played = table.Column<int>(nullable: false),
                    Won = table.Column<int>(nullable: false),
                    Lost = table.Column<int>(nullable: false),
                    Scored = table.Column<int>(nullable: false),
                    Against = table.Column<int>(nullable: false),
                    GoalDifference = table.Column<int>(nullable: false),
                    PoolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamsStatistics_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamsStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamsStatistics_PoolId",
                table: "TeamsStatistics",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsStatistics_TeamId",
                table: "TeamsStatistics",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamsStatistics");
        }
    }
}
