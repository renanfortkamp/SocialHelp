using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class GrupoGlobal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //inserir grupo global com id 0 com sqlserver

            migrationBuilder.Sql(
                "INSERT INTO DbSetGroups (Name, Description, Image, UserId) VALUES ('Global', 'Grupo Global', null, 0)"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
