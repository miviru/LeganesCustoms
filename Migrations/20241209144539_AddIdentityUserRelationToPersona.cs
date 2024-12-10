using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeganesCustomsBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUserRelationToPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Personas",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdentityUserId",
                table: "Personas",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_AspNetUsers_IdentityUserId",
                table: "Personas",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_AspNetUsers_IdentityUserId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdentityUserId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Personas");
        }
    }
}
