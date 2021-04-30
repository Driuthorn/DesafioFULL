using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioBackend.Data.Database.Migrations
{
    public partial class DesafioFULL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTitulo = table.Column<int>(type: "int", nullable: false),
                    NomeDevedor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPFDevedor = table.Column<string>(type: "nchar(12)", fixedLength: true, maxLength: 12, nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Multa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdParcelas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parcela",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTitulo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroParcela = table.Column<int>(type: "int", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "Date", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcela_Titulo_IdTitulo",
                        column: x => x.IdTitulo,
                        principalTable: "Titulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_IdTitulo",
                table: "Parcela",
                column: "IdTitulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcela");

            migrationBuilder.DropTable(
                name: "Titulo");
        }
    }
}
