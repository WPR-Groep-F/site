using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StichtingAccessibility.Server.Migrations
{
    /// <inheritdoc />
    public partial class InviteEditedEmailName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InviteEmail",
                table: "Invites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InviteEmail",
                table: "Invites");
        }
    }
}
