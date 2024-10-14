using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiwi_Travel_Blog.Src.Data.Migrations.App
{
    /// <inheritdoc />
    public partial class ConfigureUniqueNameForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                table: "T_Categories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_Name",
                table: "T_Categories");
        }
    }
}
