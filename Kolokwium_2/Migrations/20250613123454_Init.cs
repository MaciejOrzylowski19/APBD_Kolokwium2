using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolokwium_2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EstablishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "Artwork",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YearCreated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artwork", x => x.ArtworkId);
                    table.ForeignKey(
                        name: "FK_Artwork_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumberOfArtworks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition", x => x.ExhibitionId);
                    table.ForeignKey(
                        name: "FK_Exhibition_Gallery_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Gallery",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionArtwork",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(type: "int", nullable: false),
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionArtwork", x => new { x.ArtworkId, x.ExhibitionId });
                    table.ForeignKey(
                        name: "FK_ExhibitionArtwork_Artwork_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artwork",
                        principalColumn: "ArtworkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExhibitionArtwork_Exhibition_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibition",
                        principalColumn: "ExhibitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Franek", "Zak" },
                    { 2, new DateTime(1899, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lui", "Wolo" },
                    { 3, new DateTime(1939, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sashka", "Bicepsik" }
                });

            migrationBuilder.InsertData(
                table: "Gallery",
                columns: new[] { "GalleryId", "EstablishedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1324, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bydgoszcz" },
                    { 2, new DateTime(1132, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siedlckie muzeum prawie diecezjalne" }
                });

            migrationBuilder.InsertData(
                table: "Artwork",
                columns: new[] { "ArtworkId", "ArtistId", "Title", "YearCreated" },
                values: new object[,]
                {
                    { 1, 1, "Jozin Zbazin", 2012 },
                    { 2, 1, "Jo Zbazin", 2020 },
                    { 3, 2, "in", 1912 },
                    { 4, 3, "Zuch", 1979 }
                });

            migrationBuilder.InsertData(
                table: "Exhibition",
                columns: new[] { "ExhibitionId", "EndDate", "GalleryId", "NumberOfArtworks", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, null, 1, 3, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "Choroszcza" },
                    { 2, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sock" }
                });

            migrationBuilder.InsertData(
                table: "ExhibitionArtwork",
                columns: new[] { "ArtworkId", "ExhibitionId", "InsuranceValue" },
                values: new object[,]
                {
                    { 1, 1, 12m },
                    { 1, 2, 123m },
                    { 2, 1, 24m },
                    { 3, 2, 55m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artwork_ArtistId",
                table: "Artwork",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_GalleryId",
                table: "Exhibition",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionArtwork_ExhibitionId",
                table: "ExhibitionArtwork",
                column: "ExhibitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExhibitionArtwork");

            migrationBuilder.DropTable(
                name: "Artwork");

            migrationBuilder.DropTable(
                name: "Exhibition");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Gallery");
        }
    }
}
