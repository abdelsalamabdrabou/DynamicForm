using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicForm.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInputValueEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InputValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputComponentId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputValues_InputComponents_InputComponentId",
                        column: x => x.InputComponentId,
                        principalTable: "InputComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputValues_InputComponentId",
                table: "InputValues",
                column: "InputComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputValues");
        }
    }
}
