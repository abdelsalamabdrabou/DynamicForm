using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLabelToInputComponent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "InputComponents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "InputComponents");
        }
    }
}
