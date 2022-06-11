using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractManager.Infrastructure.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Correspondences",
                newName: "CorrespondenceContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CorrespondenceContent",
                table: "Correspondences",
                newName: "Content");
        }
    }
}
