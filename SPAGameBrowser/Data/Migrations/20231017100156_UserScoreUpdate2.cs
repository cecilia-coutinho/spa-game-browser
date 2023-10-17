using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGameBrowser.Data.Migrations
{
    public partial class UserScoreUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "UserScores");

            migrationBuilder.RenameColumn(
                name: "TimeGuesses",
                table: "UserScores",
                newName: "Attempts");

            migrationBuilder.RenameColumn(
                name: "IsGuessesDone",
                table: "UserScores",
                newName: "IsGuessed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsGuessed",
                table: "UserScores",
                newName: "IsGuessesDone");

            migrationBuilder.RenameColumn(
                name: "Attempts",
                table: "UserScores",
                newName: "TimeGuesses");

            migrationBuilder.AddColumn<int>(
                name: "IpAddress",
                table: "UserScores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
