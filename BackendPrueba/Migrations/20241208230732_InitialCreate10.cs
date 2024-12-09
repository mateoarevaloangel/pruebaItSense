using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendPrueba.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeManofracture",
                table: "Products",
                newName: "TypeManofacture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeManofacture",
                table: "Products",
                newName: "TypeManofracture");
        }
    }
}
