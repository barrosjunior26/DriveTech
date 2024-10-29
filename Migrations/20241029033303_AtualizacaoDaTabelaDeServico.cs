using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveTech.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDaTabelaDeServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tb_servico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tb_servico");
        }
    }
}
