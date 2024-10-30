using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveTech.Migrations
{
    /// <inheritdoc />
    public partial class Foi_Excluido_AColuna_Atualizacao_Pois_nao_era_necessaria_no_projeto_ate_o_momento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atualizacao",
                table: "tb_servico");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Cadastro",
                table: "tb_servico",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Cadastro",
                table: "tb_servico",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizacao",
                table: "tb_servico",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
