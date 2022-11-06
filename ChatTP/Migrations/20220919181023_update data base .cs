using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatTP.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessaggeDB_RoomDB_roomchatid",
                table: "MessaggeDB");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoomsDB_RoomDB_RoomChatsid",
                table: "UserRoomsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoomsDB",
                table: "UserRoomsDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDB",
                table: "UserDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomDB",
                table: "RoomDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessaggeDB",
                table: "MessaggeDB");

            migrationBuilder.RenameTable(
                name: "UserRoomsDB",
                newName: "UserRooms");

            migrationBuilder.RenameTable(
                name: "UserDB",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "RoomDB",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "MessaggeDB",
                newName: "Messagges");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoomsDB_RoomChatsid",
                table: "UserRooms",
                newName: "IX_UserRooms_RoomChatsid");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_MessaggeDB_roomchatid",
                table: "Messagges",
                newName: "IX_Messagges_roomchatid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messagges",
                table: "Messagges",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messagges_Rooms_roomchatid",
                table: "Messagges",
                column: "roomchatid",
                principalTable: "Rooms",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomChatsid",
                table: "UserRooms",
                column: "RoomChatsid",
                principalTable: "Rooms",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messagges_Rooms_roomchatid",
                table: "Messagges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomChatsid",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messagges",
                table: "Messagges");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserDB");

            migrationBuilder.RenameTable(
                name: "UserRooms",
                newName: "UserRoomsDB");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "RoomDB");

            migrationBuilder.RenameTable(
                name: "Messagges",
                newName: "MessaggeDB");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserDB",
                newName: "idUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_RoomChatsid",
                table: "UserRoomsDB",
                newName: "IX_UserRoomsDB_RoomChatsid");

            migrationBuilder.RenameIndex(
                name: "IX_Messagges_roomchatid",
                table: "MessaggeDB",
                newName: "IX_MessaggeDB_roomchatid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDB",
                table: "UserDB",
                column: "idUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoomsDB",
                table: "UserRoomsDB",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomDB",
                table: "RoomDB",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessaggeDB",
                table: "MessaggeDB",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessaggeDB_RoomDB_roomchatid",
                table: "MessaggeDB",
                column: "roomchatid",
                principalTable: "RoomDB",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoomsDB_RoomDB_RoomChatsid",
                table: "UserRoomsDB",
                column: "RoomChatsid",
                principalTable: "RoomDB",
                principalColumn: "id");
        }
    }
}
