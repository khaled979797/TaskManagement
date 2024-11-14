using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Service.Migrations
{
    /// <inheritdoc />
    public partial class EditUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Comments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Attachments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_AppUserId",
                table: "Attachments",
                newName: "IX_Attachments_UserId");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Assignments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_AppUserId",
                table: "Assignments",
                newName: "IX_Assignments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AspNetUsers_UserId",
                table: "Attachments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AspNetUsers_UserId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                newName: "IX_Comments_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Attachments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_UserId",
                table: "Attachments",
                newName: "IX_Attachments_AppUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Assignments",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                newName: "IX_Assignments_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_AppUserId",
                table: "Assignments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AspNetUsers_AppUserId",
                table: "Attachments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
