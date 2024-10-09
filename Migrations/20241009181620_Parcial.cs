using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JoseRivera_Ap1_p1.Migrations
{
    /// <inheritdoc />
    public partial class Parcial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cobroDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorCobrado = table.Column<decimal>(type: "TEXT", nullable: false),
                    CobrosCobroId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cobroDetalle", x => x.DetalleId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    CobrosCobroId = table.Column<int>(type: "INTEGER", nullable: true),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.DeudorId);
                    table.ForeignKey(
                        name: "FK_Deudores_Cobros_CobrosCobroId",
                        column: x => x.CobrosCobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId");
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "DeudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "DeudorId", "CobrosCobroId", "Nombres", "PrestamoId" },
                values: new object[,]
                {
                    { 1, null, "Jose", null },
                    { 2, null, "Josue", null },
                    { 3, null, "Juan", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cobroDetalle_CobrosCobroId",
                table: "cobroDetalle",
                column: "CobrosCobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_DeudorId",
                table: "Cobros",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudores_CobrosCobroId",
                table: "Deudores",
                column: "CobrosCobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Deudores_PrestamoId",
                table: "Deudores",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_DeudorId",
                table: "Prestamos",
                column: "DeudorId");

            migrationBuilder.AddForeignKey(
                name: "FK_cobroDetalle_Cobros_CobrosCobroId",
                table: "cobroDetalle",
                column: "CobrosCobroId",
                principalTable: "Cobros",
                principalColumn: "CobroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Deudores_DeudorId",
                table: "Cobros",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "DeudorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deudores_Prestamos_PrestamoId",
                table: "Deudores",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deudores_Cobros_CobrosCobroId",
                table: "Deudores");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Deudores_DeudorId",
                table: "Prestamos");

            migrationBuilder.DropTable(
                name: "cobroDetalle");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Deudores");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
