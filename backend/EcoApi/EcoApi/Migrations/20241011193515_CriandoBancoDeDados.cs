using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoApi.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contribuinte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuinte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensageiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensageiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contribuicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recibo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MensageiroId = table.Column<int>(type: "int", nullable: false),
                    IdTipoPagamento = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContribuinteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribuicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Contribuinte_ContribuinteId",
                        column: x => x.ContribuinteId,
                        principalTable: "Contribuinte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contribuicao_Mensageiro_MensageiroId",
                        column: x => x.MensageiroId,
                        principalTable: "Mensageiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoDiario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataMovimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recibo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MensageiroId = table.Column<int>(type: "int", nullable: false),
                    IdTipoPagamento = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataPrevista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoDiario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimentoDiario_Mensageiro_MensageiroId",
                        column: x => x.MensageiroId,
                        principalTable: "Mensageiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_ContribuinteId",
                table: "Contribuicao",
                column: "ContribuinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contribuicao_MensageiroId",
                table: "Contribuicao",
                column: "MensageiroId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoDiario_MensageiroId",
                table: "MovimentoDiario",
                column: "MensageiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contribuicao");

            migrationBuilder.DropTable(
                name: "MovimentoDiario");

            migrationBuilder.DropTable(
                name: "Contribuinte");

            migrationBuilder.DropTable(
                name: "Mensageiro");
        }
    }
}
