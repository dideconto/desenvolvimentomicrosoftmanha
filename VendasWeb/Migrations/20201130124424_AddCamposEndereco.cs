using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasWeb.Migrations
{
    public partial class AddCamposEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "UsuarioLogado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "UsuarioLogado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "UsuarioLogado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "UsuarioLogado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "UsuarioLogado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Localidade",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "UsuarioLogado");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Localidade",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "AspNetUsers");
        }
    }
}
