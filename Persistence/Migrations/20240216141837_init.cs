using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ctaegoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Technology" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "ImageUrl", "Title", "categoryId", "ctaegoryID" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "I a’m Ahmed Mabrouk Ahmed and i have 24 years Old and i  am software Engineer Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat", "https://api.khalidessaadani.com/uploads/articles_bg.jpg", "Introduction to CQRS and Mediator Patterns", null, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde") });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_categoryId",
                table: "Posts",
                column: "categoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
