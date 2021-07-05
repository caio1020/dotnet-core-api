using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteApiCaio.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataAlteracao", "DataCadastro", "Nome", "Preco", "Quantidade" },
                values: new object[] { 1, null, new DateTime(2021, 7, 4, 18, 38, 53, 418, DateTimeKind.Local).AddTicks(209), "Caderno", 7.5, 5 });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "DataAlteracao", "DataCadastro", "Nome", "Preco", "Quantidade" },
                values: new object[] { 2, null, new DateTime(2021, 7, 4, 18, 38, 53, 418, DateTimeKind.Local).AddTicks(8613), "Caneta", 2.2999999999999998, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
