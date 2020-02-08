using Microsoft.EntityFrameworkCore.Migrations;

namespace sts_daos.Migrations
{
    public partial class creatingFieldTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pools_Categories_CategoryId",
                table: "pools");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_pools_PoolId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pools",
                table: "pools");

            migrationBuilder.RenameTable(
                name: "pools",
                newName: "Pools");

            migrationBuilder.RenameIndex(
                name: "IX_pools_CategoryId",
                table: "Pools",
                newName: "IX_Pools_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pools",
                table: "Pools",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pools_Categories_CategoryId",
                table: "Pools",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Pools_PoolId",
                table: "Teams",
                column: "PoolId",
                principalTable: "Pools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pools_Categories_CategoryId",
                table: "Pools");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Pools_PoolId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pools",
                table: "Pools");

            migrationBuilder.RenameTable(
                name: "Pools",
                newName: "pools");

            migrationBuilder.RenameIndex(
                name: "IX_Pools_CategoryId",
                table: "pools",
                newName: "IX_pools_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pools",
                table: "pools",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pools_Categories_CategoryId",
                table: "pools",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_pools_PoolId",
                table: "Teams",
                column: "PoolId",
                principalTable: "pools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
