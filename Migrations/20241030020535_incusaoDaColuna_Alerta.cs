using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveTech.Migrations
{
    /// <inheritdoc />
    public partial class incusaoDaColuna_Alerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Alerta",
                table: "tb_servico",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alerta",
                table: "tb_servico");
        }
    }
}
