using Microsoft.EntityFrameworkCore.Migrations;

namespace Ece_Berker_Project.Data.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YorumluoUserId",
                table: "Yorums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorums_YorumluoUserId",
                table: "Yorums",
                column: "YorumluoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yorums_AspNetUsers_YorumluoUserId",
                table: "Yorums",
                column: "YorumluoUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yorums_AspNetUsers_YorumluoUserId",
                table: "Yorums");

            migrationBuilder.DropIndex(
                name: "IX_Yorums_YorumluoUserId",
                table: "Yorums");

            migrationBuilder.DropColumn(
                name: "YorumluoUserId",
                table: "Yorums");
        }
    }
}
