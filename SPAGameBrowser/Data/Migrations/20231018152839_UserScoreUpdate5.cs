using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGameBrowser.Data.Migrations
{
    public partial class UserScoreUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScores_AspNetUsers_FkUserId",
                table: "UserScores");

            migrationBuilder.AlterColumn<string>(
                name: "FkUserId",
                table: "UserScores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_UserScores_AspNetUsers_FkUserId",
                table: "UserScores",
                column: "FkUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserScores_AspNetUsers_FkUserId",
                table: "UserScores");

            migrationBuilder.AlterColumn<string>(
                name: "FkUserId",
                table: "UserScores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserScores_AspNetUsers_FkUserId",
                table: "UserScores",
                column: "FkUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
