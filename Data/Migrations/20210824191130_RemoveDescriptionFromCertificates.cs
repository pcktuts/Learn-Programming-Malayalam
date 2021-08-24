using Microsoft.EntityFrameworkCore.Migrations;

namespace Learn_Programming_Malayalam.Data.Migrations
{
    public partial class RemoveDescriptionFromCertificates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Certificates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Certificates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
