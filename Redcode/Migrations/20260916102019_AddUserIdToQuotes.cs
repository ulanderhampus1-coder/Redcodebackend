using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redcode.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToQuotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Quotes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quotes");
        }
    }
}
