using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitProductLocationQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_MedicalRepUsers_UserId",
                table: "Visits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Visits",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ProductId",
                table: "Visits",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_MedicalRepUsers_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "MedicalRepUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Products_ProductId",
                table: "Visits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_MedicalRepUsers_UserId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Products_ProductId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_ProductId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Visits");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_MedicalRepUsers_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "MedicalRepUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
