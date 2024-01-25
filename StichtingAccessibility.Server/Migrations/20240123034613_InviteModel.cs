using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StichtingAccessibility.Server.Migrations
{
    /// <inheritdoc />
    public partial class InviteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UitgeverId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OntvangerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VerloopDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumGemaakt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InviteNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGebruikt = table.Column<bool>(type: "bit", nullable: false),
                    IsVervalt = table.Column<bool>(type: "bit", nullable: false),
                    BedrijfsMedewerkerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invites_AspNetUsers_BedrijfsMedewerkerId",
                        column: x => x.BedrijfsMedewerkerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invites_AspNetUsers_OntvangerId",
                        column: x => x.OntvangerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invites_AspNetUsers_UitgeverId",
                        column: x => x.UitgeverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invites_BedrijfsMedewerkerId",
                table: "Invites",
                column: "BedrijfsMedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_OntvangerId",
                table: "Invites",
                column: "OntvangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_UitgeverId",
                table: "Invites",
                column: "UitgeverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invites");
        }
    }
}
