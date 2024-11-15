using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IQnotion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IQnotionsAddUserNotionForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_UserNotions_AspNetUsers_UserId",
                table: "UserNotions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotions_AspNetUsers_UserId",
                table: "UserNotions");
        }
    }
}
