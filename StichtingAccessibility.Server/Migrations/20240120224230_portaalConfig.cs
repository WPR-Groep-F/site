using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StichtingAccessibility.Server.Migrations
{
    /// <inheritdoc />
    public partial class portaalConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "BedrijfsPortaalen",
                newName: "PortaalType");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PortaalType",
                table: "BedrijfsPortaalen",
                newName: "Discriminator");
        }
    }
}
