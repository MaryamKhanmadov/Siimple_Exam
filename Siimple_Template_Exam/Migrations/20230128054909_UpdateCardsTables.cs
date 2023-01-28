using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Siimple_Template_Exam.Migrations
{
    public partial class UpdateCardsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Cards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
