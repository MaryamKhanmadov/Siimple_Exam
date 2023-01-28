using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Siimple_Template_Exam.Migrations
{
    public partial class UpdateCardsTablesAddedIconUrlColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Cards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Cards");
        }
    }
}
