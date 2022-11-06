using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatTP.Migrations
{
    public partial class DataBase0511 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "conectado",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conectado",
                table: "Users");
        }
    }
}
