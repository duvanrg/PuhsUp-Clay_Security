using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoriaper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCat = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipocontacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipodireccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipopersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTurno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraTurnoI = table.Column<DateTime>(type: "date", nullable: false),
                    HoraTurnoF = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "departamento_ibfk_2",
                        column: x => x.PaisId,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiu = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "ciudad_ibfk_1",
                        column: x => x.DepId,
                        principalTable: "departamento",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPersona = table.Column<int>(type: "int(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateReg = table.Column<DateTime>(type: "date", nullable: false),
                    TPersonaId = table.Column<int>(type: "int(11)", nullable: false),
                    CatId = table.Column<int>(type: "int(11)", nullable: false),
                    CiudadId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "persona_ibfk_2",
                        column: x => x.CiudadId,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "persona_ibfk_3",
                        column: x => x.TPersonaId,
                        principalTable: "tipopersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "persona_ibfk_4",
                        column: x => x.CatId,
                        principalTable: "categoriaper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contactoper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaId = table.Column<int>(type: "int(11)", nullable: false),
                    TContactoId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "contactoper_ibfk_1",
                        column: x => x.PersonaId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contactoper_ibfk_2",
                        column: x => x.TContactoId,
                        principalTable: "tipocontacto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int(11)", nullable: false),
                    FechaContrato = table.Column<DateTime>(type: "date", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int(11)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    EstatoId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "contrato_ibfk_1",
                        column: x => x.ClienteId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contrato_ibfk_2",
                        column: x => x.EmpleadoId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "contrato_ibfk_3",
                        column: x => x.EstatoId,
                        principalTable: "estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dirpersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaId = table.Column<int>(type: "int(11)", nullable: false),
                    TDireccionId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "dirpersona_ibfk_1",
                        column: x => x.PersonaId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "dirpersona_ibfk_2",
                        column: x => x.TDireccionId,
                        principalTable: "tipodireccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContratoId = table.Column<int>(type: "int(11)", nullable: false),
                    TurnoId = table.Column<int>(type: "int(11)", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "programacion_ibfk_1",
                        column: x => x.EmpleadoId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "programacion_ibfk_2",
                        column: x => x.ContratoId,
                        principalTable: "contrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "programacion_ibfk_3",
                        column: x => x.TurnoId,
                        principalTable: "turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "DepId",
                table: "ciudad",
                column: "DepId");

            migrationBuilder.CreateIndex(
                name: "Descripcion",
                table: "contactoper",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonaId",
                table: "contactoper",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "TContactoId",
                table: "contactoper",
                column: "TContactoId");

            migrationBuilder.CreateIndex(
                name: "ClienteId",
                table: "contrato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "EmpleadoId",
                table: "contrato",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "EstatoId",
                table: "contrato",
                column: "EstatoId");

            migrationBuilder.CreateIndex(
                name: "PaisId",
                table: "departamento",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "PersonaId1",
                table: "dirpersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "TDireccionId",
                table: "dirpersona",
                column: "TDireccionId");

            migrationBuilder.CreateIndex(
                name: "CatId",
                table: "persona",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "CiudadId",
                table: "persona",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IdPersona",
                table: "persona",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TPersonaId",
                table: "persona",
                columns: new[] { "TPersonaId", "CatId", "CiudadId" });

            migrationBuilder.CreateIndex(
                name: "ContratoId",
                table: "programacion",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "EmpleadoId1",
                table: "programacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "TurnoId",
                table: "programacion",
                column: "TurnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactoper");

            migrationBuilder.DropTable(
                name: "dirpersona");

            migrationBuilder.DropTable(
                name: "programacion");

            migrationBuilder.DropTable(
                name: "tipocontacto");

            migrationBuilder.DropTable(
                name: "tipodireccion");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "turnos");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipopersona");

            migrationBuilder.DropTable(
                name: "categoriaper");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
