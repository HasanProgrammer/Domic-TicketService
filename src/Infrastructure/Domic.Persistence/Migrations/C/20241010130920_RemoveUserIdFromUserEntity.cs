using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domic.Persistence.Migrations.C
{
    public partial class RemoveUserIdFromUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
