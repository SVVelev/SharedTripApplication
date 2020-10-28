using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareTripApplication.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trip_IsDeleted",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Trip",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Trip",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_IsDeleted",
                table: "Trip",
                column: "IsDeleted");
        }
    }
}
