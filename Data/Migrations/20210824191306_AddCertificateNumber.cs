using Microsoft.EntityFrameworkCore.Migrations;

namespace Learn_Programming_Malayalam.Data.Migrations
{
    public partial class AddCertificateNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificateNumber",
                table: "Certificates",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CertificateNumber",
                table: "Certificates",
                column: "CertificateNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Certificates_CertificateNumber",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CertificateNumber",
                table: "Certificates");
        }
    }
}
