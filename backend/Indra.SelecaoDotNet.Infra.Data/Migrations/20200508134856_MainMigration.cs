using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Indra.SelecaoDotNet.Infra.Data.Migrations
{
    public partial class MainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Codigo = table.Column<int>(nullable: false),
                    Padrao = table.Column<bool>(nullable: false),
                    Usuario_Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartao_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Usuario_Id = table.Column<Guid>(nullable: false),
                    Curso_Id = table.Column<Guid>(nullable: false),
                    Pagamento_Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Curso_Curso_Id",
                        column: x => x.Curso_Id,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Usuario_Id = table.Column<Guid>(nullable: false),
                    Matricula_Id = table.Column<Guid>(nullable: false),
                    Cartao_Id = table.Column<Guid>(nullable: false),
                    CartaoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamento_Matricula_Matricula_Id",
                        column: x => x.Matricula_Id,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { new Guid("a804f206-0af7-4870-ab49-923a26f52cd2"), null, "Curso básico de Python", 10.0 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { new Guid("bab465a5-4985-4170-b83e-ec582e63114a"), null, "Curso avançado de Python", 25.0 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { new Guid("0fed05e1-3bc9-49c8-a8bc-e110816f1d40"), null, "Curso básico de Asp.Net Core", 10.0 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { new Guid("36d63982-f542-4f5c-8d58-ee90fae9efa1"), null, "Curso básico de  UX", 15.0 });

            migrationBuilder.InsertData(
                table: "Curso",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[] { new Guid("6c3701f3-31e6-4064-a4e2-067e9e9557b6"), null, "Curso completo de VueJS", 25.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cartao_Usuario_Id",
                table: "Cartao",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Curso_Id",
                table: "Matricula",
                column: "Curso_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_Usuario_Id",
                table: "Matricula",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_CartaoId",
                table: "Pagamento",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_Matricula_Id",
                table: "Pagamento",
                column: "Matricula_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_Usuario_Id",
                table: "Pagamento",
                column: "Usuario_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
