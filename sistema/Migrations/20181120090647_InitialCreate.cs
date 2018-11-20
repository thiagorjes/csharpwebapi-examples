using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sistema");

            migrationBuilder.CreateTable(
                name: "EntidadeAutenticadora",
                schema: "Sistema",
                columns: table => new
                {
                    IdEntidadeAutenticadora = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(unicode: false, maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadeAutenticadora", x => x.IdEntidadeAutenticadora);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                schema: "Sistema",
                columns: table => new
                {
                    IdPessoaFisica = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Cpf = table.Column<string>(unicode: false, maxLength: 11, nullable: false),
                    Nome = table.Column<string>(unicode: false, maxLength: 400, nullable: false),
                    NickName = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Maior = table.Column<byte>(type: "tinyint(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.IdPessoaFisica);
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                schema: "Sistema",
                columns: table => new
                {
                    IdAccessToken = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PessoaFisica = table.Column<int>(type: "int(11)", nullable: false),
                    AccessToken = table.Column<byte[]>(type: "blob", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "date", nullable: false),
                    Validade = table.Column<DateTime>(type: "date", nullable: false),
                    Origem = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessToken", x => x.IdAccessToken);
                    table.ForeignKey(
                        name: "FK_ea",
                        column: x => x.Origem,
                        principalSchema: "Sistema",
                        principalTable: "EntidadeAutenticadora",
                        principalColumn: "IdEntidadeAutenticadora",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pf",
                        column: x => x.PessoaFisica,
                        principalSchema: "Sistema",
                        principalTable: "PessoaFisica",
                        principalColumn: "IdPessoaFisica",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_ea_idx",
                schema: "Sistema",
                table: "AccessToken",
                column: "Origem");

            migrationBuilder.CreateIndex(
                name: "FK_pf_idx",
                schema: "Sistema",
                table: "AccessToken",
                column: "PessoaFisica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "EntidadeAutenticadora",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "PessoaFisica",
                schema: "Sistema");
        }
    }
}
