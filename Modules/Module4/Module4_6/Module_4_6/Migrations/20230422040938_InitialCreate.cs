using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Module_4_6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateTable(
                name: "Artist_Song",
                columns: table => new
                {
                    ArtistSongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false),
                    DateOfSinging = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Song", x => x.ArtistSongId);
                    table.ForeignKey(
                        name: "FK_Artist_Song_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Song_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artist",
                columns: new[] { "ArtistId", "DateOfBirth", "DateOfDeath", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1935, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1977, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Elvis Presley", null },
                    { 2, new DateTime(1944, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Brenda Lee", null },
                    { 3, new DateTime(1958, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/madonna/", "Madonna", null },
                    { 4, new DateTime(1901, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1971, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Louis Armstrong", null },
                    { 5, new DateTime(1901, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Mariah Carey", null },
                    { 6, new DateTime(1991, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "https://www.instagram.com/teddysphotos/", "Ed Sheeran", null }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, "Country" },
                    { 2, "Rock" },
                    { 3, "Pop" },
                    { 4, "R&B" },
                    { 5, "Blues" }
                });

            migrationBuilder.InsertData(
                table: "Song",
                columns: new[] { "SongId", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 7, 150, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Song without genre" },
                    { 1, 210, 1, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Always on My Mind" },
                    { 2, 81, 3, new DateTime(1967, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "What a Wonderful World" },
                    { 3, 81, 3, new DateTime(1967, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ray of Light" },
                    { 4, 202, 4, new DateTime(2005, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "We Belong Together" },
                    { 5, 163, 2, new DateTime(2022, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "2step" },
                    { 6, 186, 5, new DateTime(1935, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basin Street Blues" }
                });

            migrationBuilder.InsertData(
                table: "Artist_Song",
                columns: new[] { "ArtistSongId", "ArtistId", "DateOfSinging", "SongId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Song_ArtistId",
                table: "Artist_Song",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Song_SongId",
                table: "Artist_Song",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist_Song");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
