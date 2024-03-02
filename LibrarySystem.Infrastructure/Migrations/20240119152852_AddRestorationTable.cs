using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    public partial class AddRestorationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestorationId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restoration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestorationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restoration", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders",
                column: "RestorationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restoration_RestorationId",
                table: "Orders",
                column: "RestorationId",
                principalTable: "Restoration",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restoration_RestorationId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Restoration");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RestorationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RestorationId",
                table: "Orders");
        }
    }
}
