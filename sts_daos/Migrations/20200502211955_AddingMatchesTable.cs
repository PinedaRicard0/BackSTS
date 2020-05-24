using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class AddingMatchesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamOneId = table.Column<int>(nullable: false),
                    TeamTwoId = table.Column<int>(nullable: false),
                    TeamOneGoals = table.Column<int>(nullable: false),
                    TeamTwoGoals = table.Column<int>(nullable: false),
                    GameDate = table.Column<DateTime>(nullable: false),
                    FieldId = table.Column<int>(nullable: false),
                    PoolId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamOneId",
                        column: x => x.TeamOneId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamTwoId",
                        column: x => x.TeamTwoId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FieldId",
                table: "Matches",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PoolId",
                table: "Matches",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamOneId",
                table: "Matches",
                column: "TeamOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamTwoId",
                table: "Matches",
                column: "TeamTwoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
