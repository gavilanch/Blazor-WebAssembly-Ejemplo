using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCRUD.Server.Migrations
{
    public partial class Paises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Personas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Rep Dom" });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "México" });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Santo Domingo", 1 },
                    { 2, "San Cristobal", 1 },
                    { 3, "Ciudad de México", 2 },
                    { 4, "Jalisco", 2 }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Persona 1" },
                    { 2, 1, "Persona 2" },
                    { 3, 1, "Persona 3" },
                    { 4, 1, "Persona 4" },
                    { 5, 1, "Persona 5" },
                    { 6, 1, "Persona 6" },
                    { 7, 1, "Persona 7" },
                    { 8, 1, "Persona 8" },
                    { 9, 1, "Persona 9" },
                    { 10, 1, "Persona 10" },
                    { 11, 1, "Persona 11" },
                    { 12, 1, "Persona 12" },
                    { 13, 1, "Persona 13" },
                    { 14, 1, "Persona 14" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EstadoId",
                table: "Personas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Estado_EstadoId",
                table: "Personas",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Estado_EstadoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EstadoId",
                table: "Personas");

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Personas");
        }
    }
}
