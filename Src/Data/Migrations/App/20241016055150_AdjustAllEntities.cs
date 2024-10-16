using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kiwi_Travel_Blog.Src.Data.Migrations.App
{
    /// <inheritdoc />
    public partial class AdjustAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Articles_T_Categories_CategoryId",
                table: "T_Articles");

            migrationBuilder.DropIndex(
                name: "IX_T_Articles_CategoryId",
                table: "T_Articles");

            migrationBuilder.AlterColumn<long>(
                name: "LikeNum",
                table: "T_Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_Name",
                table: "T_Articles",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Article_Name",
                table: "T_Articles");

            migrationBuilder.AlterColumn<string>(
                name: "LikeNum",
                table: "T_Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_T_Articles_CategoryId",
                table: "T_Articles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Articles_T_Categories_CategoryId",
                table: "T_Articles",
                column: "CategoryId",
                principalTable: "T_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
