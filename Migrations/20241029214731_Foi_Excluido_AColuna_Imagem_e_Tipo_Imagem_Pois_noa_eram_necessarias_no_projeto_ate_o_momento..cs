using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveTech.Migrations
{
    /// <inheritdoc />
    public partial class Foi_Excluido_AColuna_Imagem_e_Tipo_Imagem_Pois_noa_eram_necessarias_no_projeto_ate_o_momento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "tb_servico");

            migrationBuilder.DropColumn(
                name: "TipoImagem",
                table: "tb_servico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "tb_servico",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImagem",
                table: "tb_servico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
