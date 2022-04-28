using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FuncionarioBeneficio",
                table: "FuncionarioBeneficio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteBeneficio",
                table: "ClienteBeneficio");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FuncionarioBeneficio");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClienteBeneficio");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionarioBeneficio",
                table: "FuncionarioBeneficio",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "IdClienteBeneficio",
                table: "ClienteBeneficio",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuncionarioBeneficio",
                table: "FuncionarioBeneficio",
                column: "IdFuncionarioBeneficio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteBeneficio",
                table: "ClienteBeneficio",
                column: "IdClienteBeneficio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FuncionarioBeneficio",
                table: "FuncionarioBeneficio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteBeneficio",
                table: "ClienteBeneficio");

            migrationBuilder.DropColumn(
                name: "IdFuncionarioBeneficio",
                table: "FuncionarioBeneficio");

            migrationBuilder.DropColumn(
                name: "IdClienteBeneficio",
                table: "ClienteBeneficio");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FuncionarioBeneficio",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClienteBeneficio",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuncionarioBeneficio",
                table: "FuncionarioBeneficio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteBeneficio",
                table: "ClienteBeneficio",
                column: "Id");
        }
    }
}
