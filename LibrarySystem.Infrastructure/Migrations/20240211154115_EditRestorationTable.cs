using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class EditRestorationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders",
                column: "RestorationId",
                unique: true,
                filter: "[RestorationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders",
                column: "RestorationId");
        }
    }
}
