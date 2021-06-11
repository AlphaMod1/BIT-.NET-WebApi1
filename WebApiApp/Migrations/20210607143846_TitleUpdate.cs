using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiApp.Migrations
{
    public partial class TitleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Todos",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todos",
                newName: "Name");
        }
    }
}
