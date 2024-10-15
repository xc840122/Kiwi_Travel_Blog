using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiwi_Travel_Blog.Src.Data.Migrations.App
{
    /// <inheritdoc />
    public partial class RemoveCoverFromArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "T_Articles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "T_Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
