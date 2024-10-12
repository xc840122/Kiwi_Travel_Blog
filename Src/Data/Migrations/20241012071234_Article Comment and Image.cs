using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OXL_Assessment2.Data.Migrations
{
    /// <inheritdoc />
    public partial class ArticleCommentandImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "T_Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NZTUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NZTUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Articles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: true),
                    LikeNums = table.Column<long>(type: "bigint", nullable: false),
                    FavoriteNums = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Articles_NZTUser_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "NZTUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_Articles_T_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "T_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewerId = table.Column<long>(type: "bigint", nullable: true),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    LikeNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_NZTUser_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "NZTUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_T_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "T_Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_T_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "T_Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ReviewerId",
                table: "Comment",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ArticleId",
                table: "Image",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Articles_AuthorId",
                table: "T_Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Articles_CategoryId",
                table: "T_Articles",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "T_Articles");

            migrationBuilder.DropTable(
                name: "NZTUser");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "T_Categories");
        }
    }
}
