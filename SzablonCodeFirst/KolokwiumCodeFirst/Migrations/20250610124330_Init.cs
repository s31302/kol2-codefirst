﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KolokwiumCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Tournamen",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournamen", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    BestRating = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Match_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "MapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Match_Tournamen_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournamen",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Match",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    MVPs = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Match", x => new { x.MatchId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_Player_Match_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Match_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "MapId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Inferno", "a" },
                    { 2, "Mirage", "b" },
                    { 3, "Map", "a" }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 1, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Nowak" },
                    { 2, new DateTime(2015, 7, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "Piotr", "Smith" },
                    { 3, new DateTime(2004, 2, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "Zofia", "Cocos" }
                });

            migrationBuilder.InsertData(
                table: "Tournamen",
                columns: new[] { "TournamentId", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "CS2 Summer Cup", new DateTime(2025, 7, 2, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2025, 9, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "CS2 Summer Cup", new DateTime(2025, 3, 2, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2025, 10, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "CS2 Summer Cup", new DateTime(2025, 4, 2, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchId", "BestRating", "MapId", "MatchDate", "Team1Score", "Team2Score", "TournamentId" },
                values: new object[,]
                {
                    { 1, 3.0, 1, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 1 },
                    { 2, 2.3999999999999999, 2, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 2 },
                    { 3, 1.0, 3, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Player_Match",
                columns: new[] { "MatchId", "PlayerId", "MVPs", "Rating" },
                values: new object[,]
                {
                    { 1, 1, 1, 10.99 },
                    { 2, 2, 2, 41.5 },
                    { 3, 3, 3, 3.75 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_MapId",
                table: "Match",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Match_PlayerId",
                table: "Player_Match",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player_Match");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Tournamen");
        }
    }
}
