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
                name: "DbSetGroups",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetGroups", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "DbSetMessages",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Text = table.Column<string>(
                            type: "nvarchar(255)",
                            maxLength: 255,
                            nullable: false
                        ),
                        DateMessage = table.Column<DateTime>(type: "datetime2", nullable: false),
                        EnumStatus = table.Column<int>(type: "int", nullable: false),
                        Edit = table.Column<bool>(type: "bit", nullable: false),
                        UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<int>(type: "int", nullable: false),
                        GroupId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetMessages", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "DbSetUsers",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        GroupId = table.Column<int>(type: "int", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetUsers", x => x.Id);
                }
            );

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "DbSetGroups");

            migrationBuilder.DropTable(name: "DbSetMessages");

            migrationBuilder.DropTable(name: "DbSetUsers");
        }
    }
}
