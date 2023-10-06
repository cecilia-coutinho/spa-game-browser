using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGameBrowser.Data.Migrations
{
    public partial class RecreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WordName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "UserScores",
                columns: table => new
                {
                    UserScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FkWordId = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<int>(type: "int", nullable: false),
                    TimeGuesses = table.Column<int>(type: "int", nullable: false),
                    IsGuessesDone = table.Column<bool>(type: "bit", nullable: false),
                    Started_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finished_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserScores", x => x.UserScoreId);
                    table.ForeignKey(
                        name: "FK_UserScores_AspNetUsers_FkUserId",
                        column: x => x.FkUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserScores_Words_FkWordId",
                        column: x => x.FkWordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "WordName" },
                values: new object[,]
                {
                    { 1, "apple" },
                    { 2, "chair" },
                    { 3, "house" },
                    { 4, "table" },
                    { 5, "knife" },
                    { 6, "books" },
                    { 7, "paper" },
                    { 8, "music" },
                    { 9, "globe" },
                    { 10, "stars" },
                    { 11, "radio" },
                    { 12, "queen" },
                    { 13, "clock" },
                    { 14, "watch" },
                    { 15, "glass" },
                    { 16, "water" },
                    { 17, "plant" },
                    { 18, "earth" },
                    { 19, "grape" },
                    { 20, "beach" },
                    { 21, "candy" },
                    { 22, "frost" },
                    { 23, "crown" },
                    { 24, "lions" },
                    { 25, "heart" },
                    { 26, "bells" },
                    { 27, "peace" },
                    { 28, "pride" },
                    { 29, "raven" },
                    { 30, "torch" },
                    { 31, "smile" },
                    { 32, "sushi" },
                    { 33, "swiss" },
                    { 34, "darts" },
                    { 35, "horse" },
                    { 36, "lamps" },
                    { 37, "birds" },
                    { 38, "magic" },
                    { 39, "ocean" },
                    { 40, "route" },
                    { 41, "trout" },
                    { 42, "flame" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "WordName" },
                values: new object[,]
                {
                    { 43, "sugar" },
                    { 44, "couch" },
                    { 45, "spear" },
                    { 46, "chess" },
                    { 47, "piano" },
                    { 48, "cigar" },
                    { 49, "hills" },
                    { 50, "fairy" },
                    { 51, "wings" },
                    { 52, "beard" },
                    { 53, "flute" },
                    { 54, "space" },
                    { 55, "tiger" },
                    { 56, "zebra" },
                    { 57, "dolph" },
                    { 58, "angel" },
                    { 59, "panda" },
                    { 60, "juice" },
                    { 61, "honey" },
                    { 62, "dream" },
                    { 63, "happy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_FkUserId",
                table: "UserScores",
                column: "FkUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserScores_FkWordId",
                table: "UserScores",
                column: "FkWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordName",
                table: "Words",
                column: "WordName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserScores");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
