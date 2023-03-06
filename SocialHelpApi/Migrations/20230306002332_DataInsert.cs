using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class DataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO DBSetGroups (Name, Description, Image, UserId) VALUES ('Global', 'Global', 'Global', 0)"
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
