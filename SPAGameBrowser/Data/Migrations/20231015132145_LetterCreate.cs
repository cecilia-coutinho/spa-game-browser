using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPAGameBrowser.Data.Migrations
{
    public partial class LetterCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.LetterId);
                });

            migrationBuilder.InsertData(
                table: "Letters",
                columns: new[] { "LetterId", "Key" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "b" },
                    { 3, "c" },
                    { 4, "d" },
                    { 5, "e" },
                    { 6, "f" },
                    { 7, "g" },
                    { 8, "h" },
                    { 9, "i" },
                    { 10, "j" },
                    { 11, "k" },
                    { 12, "l" },
                    { 13, "m" },
                    { 14, "n" },
                    { 15, "o" },
                    { 16, "p" },
                    { 17, "q" },
                    { 18, "r" },
                    { 19, "s" },
                    { 20, "t" },
                    { 21, "u" },
                    { 22, "v" },
                    { 23, "w" },
                    { 24, "x" },
                    { 25, "y" },
                    { 26, "z" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letters_Key",
                table: "Letters",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters");
        }
    }
}
