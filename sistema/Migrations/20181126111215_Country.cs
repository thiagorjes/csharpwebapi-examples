using Microsoft.EntityFrameworkCore.Migrations;

namespace sistema.Migrations
{
    public partial class Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    IdCountry = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.IdCountry);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    IdCountry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                    table.ForeignKey(
                        name: "FK_State_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "IdCountry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    IdState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_City_State_IdState",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    IdNeighborhood = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    IdCity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.IdNeighborhood);
                    table.ForeignKey(
                        name: "FK_Neighborhood_City_IdCity",
                        column: x => x.IdCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken",
                column: "NeighborhoodIdNeighborhood");

            migrationBuilder.CreateIndex(
                name: "IX_City_IdState",
                table: "City",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_IdCity",
                table: "Neighborhood",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_State_IdCountry",
                table: "State",
                column: "IdCountry");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessToken_Neighborhood_NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken",
                column: "NeighborhoodIdNeighborhood",
                principalTable: "Neighborhood",
                principalColumn: "IdNeighborhood",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessToken_Neighborhood_NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_AccessToken_NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken");

            migrationBuilder.DropColumn(
                name: "NeighborhoodIdNeighborhood",
                schema: "Sistema",
                table: "AccessToken");
        }
    }
}
