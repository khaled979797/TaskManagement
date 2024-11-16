using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Service.Migrations
{
    /// <inheritdoc />
    public partial class EditAttachmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Attachments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Attachments");
        }
    }
}
