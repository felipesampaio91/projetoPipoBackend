using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 25, nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Operadora",
                columns: table => new
                {
                    IdOperadora = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 25, nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operadora", x => x.IdOperadora);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Endereco = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    HorasMeditadas = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    IdBeneficio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    IdOperadora = table.Column<int>(nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.IdBeneficio);
                    table.ForeignKey(
                        name: "FK_Beneficio_Operadora_IdOperadora",
                        column: x => x.IdOperadora,
                        principalTable: "Operadora",
                        principalColumn: "IdOperadora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteBeneficio",
                columns: table => new
                {
                    IdClienteBeneficio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdBeneficio = table.Column<int>(nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteBeneficio", x => x.IdClienteBeneficio);
                    table.ForeignKey(
                        name: "FK_ClienteBeneficio_Beneficio_IdBeneficio",
                        column: x => x.IdBeneficio,
                        principalTable: "Beneficio",
                        principalColumn: "IdBeneficio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteBeneficio_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioBeneficio",
                columns: table => new
                {
                    IdFuncionarioBeneficio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdBeneficio = table.Column<int>(nullable: false),
                    DataInclusao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioBeneficio", x => x.IdFuncionarioBeneficio);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficio_Beneficio_IdBeneficio",
                        column: x => x.IdBeneficio,
                        principalTable: "Beneficio",
                        principalColumn: "IdBeneficio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioBeneficio_Funcionario_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_IdOperadora",
                table: "Beneficio",
                column: "IdOperadora");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteBeneficio_IdBeneficio",
                table: "ClienteBeneficio",
                column: "IdBeneficio");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteBeneficio_IdCliente",
                table: "ClienteBeneficio",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCliente",
                table: "Funcionario",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficio_IdBeneficio",
                table: "FuncionarioBeneficio",
                column: "IdBeneficio");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioBeneficio_IdCliente",
                table: "FuncionarioBeneficio",
                column: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteBeneficio");

            migrationBuilder.DropTable(
                name: "FuncionarioBeneficio");

            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Operadora");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
