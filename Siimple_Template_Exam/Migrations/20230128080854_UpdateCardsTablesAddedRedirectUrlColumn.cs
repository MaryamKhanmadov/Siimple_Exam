using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Siimple_Template_Exam.Migrations
{
    public partial class UpdateCardsTablesAddedRedirectUrlColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleRedirectUrl",
                table: "Cards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleRedirectUrl",
                table: "Cards");
        }
    }
}
