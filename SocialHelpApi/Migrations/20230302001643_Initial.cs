using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbSetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbSetMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnumStatus = table.Column<int>(type: "int", nullable: false),
                    Edit = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbSetMessages_DbSetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DbSetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbSetMessages_UserId",
                table: "DbSetMessages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSetMessages");

            migrationBuilder.DropTable(
                name: "DbSetUsers");
        }
    }
}
