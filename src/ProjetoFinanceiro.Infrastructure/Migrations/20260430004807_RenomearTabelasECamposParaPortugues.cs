using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinanceiro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenomearTabelasECamposParaPortugues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Months_MonthId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rules",
                table: "Rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Months",
                table: "Months");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoletoCategories",
                table: "BoletoCategories");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transacoes");

            migrationBuilder.RenameTable(
                name: "Rules",
                newName: "Regras");

            migrationBuilder.RenameTable(
                name: "Months",
                newName: "Meses");

            migrationBuilder.RenameTable(
                name: "BoletoCategories",
                newName: "CategoriasBoleto");

            migrationBuilder.RenameColumn(
                name: "Who",
                table: "Transacoes",
                newName: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "MonthId",
                table: "Transacoes",
                newName: "MesId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Transacoes",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transacoes",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Transacoes",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transacoes",
                newName: "Valor");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MonthId",
                table: "Transacoes",
                newName: "IX_Transacoes_MesId");

            migrationBuilder.RenameColumn(
                name: "Who",
                table: "Regras",
                newName: "Responsavel");

            migrationBuilder.RenameColumn(
                name: "Keyword",
                table: "Regras",
                newName: "PalavraChave");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Regras",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Meses",
                newName: "Rotulo");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Meses",
                newName: "CriadoEm");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CategoriasBoleto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "CategoriasBoleto",
                newName: "CriadoEm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regras",
                table: "Regras",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meses",
                table: "Meses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriasBoleto",
                table: "CategoriasBoleto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Meses_MesId",
                table: "Transacoes",
                column: "MesId",
                principalTable: "Meses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Meses_MesId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regras",
                table: "Regras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meses",
                table: "Meses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriasBoleto",
                table: "CategoriasBoleto");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Regras",
                newName: "Rules");

            migrationBuilder.RenameTable(
                name: "Meses",
                newName: "Months");

            migrationBuilder.RenameTable(
                name: "CategoriasBoleto",
                newName: "BoletoCategories");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Responsavel",
                table: "Transactions",
                newName: "Who");

            migrationBuilder.RenameColumn(
                name: "MesId",
                table: "Transactions",
                newName: "MonthId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Transactions",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Transactions",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_MesId",
                table: "Transactions",
                newName: "IX_Transactions_MonthId");

            migrationBuilder.RenameColumn(
                name: "Responsavel",
                table: "Rules",
                newName: "Who");

            migrationBuilder.RenameColumn(
                name: "PalavraChave",
                table: "Rules",
                newName: "Keyword");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Rules",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Rotulo",
                table: "Months",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "Months",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "BoletoCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CriadoEm",
                table: "BoletoCategories",
                newName: "CreatedAt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rules",
                table: "Rules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Months",
                table: "Months",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoletoCategories",
                table: "BoletoCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Months_MonthId",
                table: "Transactions",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
