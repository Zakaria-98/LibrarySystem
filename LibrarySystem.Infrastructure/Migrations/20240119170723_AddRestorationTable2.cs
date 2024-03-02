using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class AddRestorationTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restoration_RestorationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restoration",
                table: "Restoration");

            migrationBuilder.RenameTable(
                name: "Restoration",
                newName: "Restorations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restorations",
                table: "Restorations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restorations_RestorationId",
                table: "Orders",
                column: "RestorationId",
                principalTable: "Restorations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restorations_RestorationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restorations",
                table: "Restorations");

            migrationBuilder.RenameTable(
                name: "Restorations",
                newName: "Restoration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restoration",
                table: "Restoration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restoration_RestorationId",
                table: "Orders",
                column: "RestorationId",
                principalTable: "Restoration",
                principalColumn: "Id");
        }
    }
}
