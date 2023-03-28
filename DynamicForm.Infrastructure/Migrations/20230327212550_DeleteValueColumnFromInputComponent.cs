using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteValueColumnFromInputComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "InputComponents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "InputComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
