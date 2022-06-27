using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_FourTask.Migrations
{
    public partial class CriacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "AspNetUsers",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tbl_Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaContratacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dt_Criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dt_Limite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Tarefa_AspNetUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_Tarefa_Tbl_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Tbl_Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Tarefa_EquipeId",
                table: "Tbl_Tarefa",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Tarefa_UsuarioId1",
                table: "Tbl_Tarefa",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId",
                principalTable: "Tbl_Equipe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Tbl_Tarefa");

            migrationBuilder.DropTable(
                name: "Tbl_Equipe");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "AspNetUsers",
                newName: "Senha");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
