using Microsoft.EntityFrameworkCore.Migrations;

namespace Ece_Berker_Project.Data.Migrations
{
    public partial class UserCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCode",
                table: "AspNetUsers");
        }
    }
}
