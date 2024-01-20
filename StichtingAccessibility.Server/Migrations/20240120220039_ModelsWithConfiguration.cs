using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StichtingAccessibility.Server.Migrations
{
    /// <inheritdoc />
    public partial class ModelsWithConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BedrijfsPortaalId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeheerdersPortaalId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenaderingOpties",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenaderingsOptiesList",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GebruikerType",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VoorkeurDeelname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoorkeurOnderzoekList",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BedrijfsPortaalen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedrijfNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedrijfAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedrijfInformatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedrijfsPortaalen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Script = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uitslag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voogden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAdres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voogden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onderzoeken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumGeplaatst = table.Column<DateOnly>(type: "date", nullable: false),
                    IsGekeurd = table.Column<bool>(type: "bit", nullable: false),
                    BedrijfId = table.Column<int>(type: "int", nullable: false),
                    OnderzoekType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AdresLocatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateOnly>(type: "date", nullable: true),
                    Tijd = table.Column<TimeOnly>(type: "time", nullable: true),
                    RouteBeschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderzoeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_BedrijfsPortaalen_BedrijfId",
                        column: x => x.BedrijfId,
                        principalTable: "BedrijfsPortaalen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderzoeken_Tracking_TrackingId",
                        column: x => x.TrackingId,
                        principalTable: "Tracking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ErvaringsdeskundigVoogd",
                columns: table => new
                {
                    ErvaringsdeskundigenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VoogdenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErvaringsdeskundigVoogd", x => new { x.ErvaringsdeskundigenId, x.VoogdenId });
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigVoogd_AspNetUsers_ErvaringsdeskundigenId",
                        column: x => x.ErvaringsdeskundigenId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ErvaringsdeskundigVoogd_Voogden_VoogdenId",
                        column: x => x.VoogdenId,
                        principalTable: "Voogden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnderzoekErvaringsdeskundig",
                columns: table => new
                {
                    ErvaringsdeskundigenId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OnderzoekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderzoekErvaringsdeskundig", x => new { x.ErvaringsdeskundigenId, x.OnderzoekId });
                    table.ForeignKey(
                        name: "FK_OnderzoekErvaringsdeskundig_AspNetUsers_ErvaringsdeskundigenId",
                        column: x => x.ErvaringsdeskundigenId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderzoekErvaringsdeskundig_Onderzoeken_OnderzoekId",
                        column: x => x.OnderzoekId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vraag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antwoord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VragenlijstId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vraag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vraag_Onderzoeken_VragenlijstId",
                        column: x => x.VragenlijstId,
                        principalTable: "Onderzoeken",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BedrijfsPortaalId",
                table: "AspNetUsers",
                column: "BedrijfsPortaalId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BeheerdersPortaalId",
                table: "AspNetUsers",
                column: "BeheerdersPortaalId");

            migrationBuilder.CreateIndex(
                name: "IX_ErvaringsdeskundigVoogd_VoogdenId",
                table: "ErvaringsdeskundigVoogd",
                column: "VoogdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_BedrijfId",
                table: "Onderzoeken",
                column: "BedrijfId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderzoeken_TrackingId",
                table: "Onderzoeken",
                column: "TrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderzoekErvaringsdeskundig_OnderzoekId",
                table: "OnderzoekErvaringsdeskundig",
                column: "OnderzoekId");

            migrationBuilder.CreateIndex(
                name: "IX_Vraag_VragenlijstId",
                table: "Vraag",
                column: "VragenlijstId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BedrijfsPortaalen_BedrijfsPortaalId",
                table: "AspNetUsers",
                column: "BedrijfsPortaalId",
                principalTable: "BedrijfsPortaalen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BedrijfsPortaalen_BeheerdersPortaalId",
                table: "AspNetUsers",
                column: "BeheerdersPortaalId",
                principalTable: "BedrijfsPortaalen",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BedrijfsPortaalen_BedrijfsPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BedrijfsPortaalen_BeheerdersPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ErvaringsdeskundigVoogd");

            migrationBuilder.DropTable(
                name: "OnderzoekErvaringsdeskundig");

            migrationBuilder.DropTable(
                name: "Vraag");

            migrationBuilder.DropTable(
                name: "Voogden");

            migrationBuilder.DropTable(
                name: "Onderzoeken");

            migrationBuilder.DropTable(
                name: "BedrijfsPortaalen");

            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BedrijfsPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BeheerdersPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BedrijfsPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BeheerdersPortaalId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BenaderingOpties",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BenaderingsOptiesList",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GebruikerType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VoorkeurDeelname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VoorkeurOnderzoekList",
                table: "AspNetUsers");
        }
    }
}
