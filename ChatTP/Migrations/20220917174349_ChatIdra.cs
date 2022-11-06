using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatTP.Migrations
{
    public partial class ChatIdra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idUserRoom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserDB",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDB", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "MessaggeDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messaggebody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idRoom = table.Column<int>(type: "int", nullable: false),
                    roomchatid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessaggeDB", x => x.id);
                    table.ForeignKey(
                        name: "FK_MessaggeDB_RoomDB_roomchatid",
                        column: x => x.roomchatid,
                        principalTable: "RoomDB",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoomsDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRoom = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomChatsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoomsDB", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRoomsDB_RoomDB_RoomChatsid",
                        column: x => x.RoomChatsid,
                        principalTable: "RoomDB",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessaggeDB_roomchatid",
                table: "MessaggeDB",
                column: "roomchatid");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoomsDB_RoomChatsid",
                table: "UserRoomsDB",
                column: "RoomChatsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessaggeDB");

            migrationBuilder.DropTable(
                name: "UserDB");

            migrationBuilder.DropTable(
                name: "UserRoomsDB");

            migrationBuilder.DropTable(
                name: "RoomDB");
        }
    }
}
