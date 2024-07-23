using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vize.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaSeedTipoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TipoProduto",
                columns: new[] { "Id", "Chave", "Nome" },
                values: new object[,]
                {
                    { 1L, 1, "Material" },
                    { 2L, 2, "Serviço" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoProduto",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "TipoProduto",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
