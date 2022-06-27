using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_FourTask.Migrations
{
    public partial class AtualizacaoTabelaEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Tbl_Equipe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Tbl_Equipe");
        }
    }
}
