using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    /// <inheritdoc />
    public partial class vet003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConteoDiagnosticoEnfermedad = table.Column<int>(type: "int", nullable: false),
                    FechaUltimoDiagn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.IdEnfermedad);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "TipoEnfermedad",
                columns: table => new
                {
                    IdTipoEnfermedad = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConteoDiagnosticoTipos = table.Column<int>(type: "int", nullable: false),
                    IdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEnfermedad", x => x.IdTipoEnfermedad);
                    table.ForeignKey(
                        name: "FK_TipoEnfermedad_Enfermedad_IdEnfermedad",
                        column: x => x.IdEnfermedad,
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad");
                });

            migrationBuilder.CreateTable(
                name: "UserRol",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    IdUserRol = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => new { x.IdUser, x.IdRol });
                    table.ForeignKey(
                        name: "FK_UserRol_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRol_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalles",
                columns: table => new
                {
                    IdDetalle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFicha = table.Column<long>(type: "bigint", nullable: true),
                    Fiebre = table.Column<int>(type: "int", nullable: false),
                    DebilidadTrenInf = table.Column<int>(type: "int", nullable: false),
                    Alopecia = table.Column<int>(type: "int", nullable: false),
                    Anemia = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.IdDetalle);
                });

            migrationBuilder.CreateTable(
                name: "FichaSintomas",
                columns: table => new
                {
                    IdFicha = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMascotas = table.Column<long>(type: "bigint", nullable: true),
                    SvrdadSntmas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdResultado = table.Column<long>(type: "bigint", nullable: true),
                    IdUser = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaSintomas", x => x.IdFicha);
                    table.ForeignKey(
                        name: "FK_FichaSintomas_Mascotas_IdMascotas",
                        column: x => x.IdMascotas,
                        principalTable: "Mascotas",
                        principalColumn: "IdMascotas");
                    table.ForeignKey(
                        name: "FK_FichaSintomas_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Resultado",
                columns: table => new
                {
                    IdResultado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFicha = table.Column<long>(type: "bigint", nullable: true),
                    FichaSintomaIdFicha = table.Column<long>(type: "bigint", nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEnfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermedadIdEnfermedad = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultado", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_Resultado_Enfermedad_EnfermedadIdEnfermedad",
                        column: x => x.EnfermedadIdEnfermedad,
                        principalTable: "Enfermedad",
                        principalColumn: "IdEnfermedad");
                    table.ForeignKey(
                        name: "FK_Resultado_FichaSintomas_FichaSintomaIdFicha",
                        column: x => x.FichaSintomaIdFicha,
                        principalTable: "FichaSintomas",
                        principalColumn: "IdFicha");
                });

            migrationBuilder.CreateTable(
                name: "HistoriaClinica",
                columns: table => new
                {
                    IdHistoriaClinica = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMascotas = table.Column<long>(type: "bigint", nullable: true),
                    IdResultado = table.Column<long>(type: "bigint", nullable: true),
                    DiagnosticoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seguimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antecedentes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recetas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<long>(type: "bigint", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SesionRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SesionEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    IpEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaEliminacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaRegistro = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    SistemaModificacion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaClinica", x => x.IdHistoriaClinica);
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Mascotas_IdMascotas",
                        column: x => x.IdMascotas,
                        principalTable: "Mascotas",
                        principalColumn: "IdMascotas");
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_Resultado_IdResultado",
                        column: x => x.IdResultado,
                        principalTable: "Resultado",
                        principalColumn: "IdResultado");
                    table.ForeignKey(
                        name: "FK_HistoriaClinica_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_IdFicha",
                table: "Detalles",
                column: "IdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_FichaSintomas_IdMascotas",
                table: "FichaSintomas",
                column: "IdMascotas");

            migrationBuilder.CreateIndex(
                name: "IX_FichaSintomas_IdResultado",
                table: "FichaSintomas",
                column: "IdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_FichaSintomas_IdUser",
                table: "FichaSintomas",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdMascotas",
                table: "HistoriaClinica",
                column: "IdMascotas");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdResultado",
                table: "HistoriaClinica",
                column: "IdResultado");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaClinica_IdUser",
                table: "HistoriaClinica",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_EnfermedadIdEnfermedad",
                table: "Resultado",
                column: "EnfermedadIdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_Resultado_FichaSintomaIdFicha",
                table: "Resultado",
                column: "FichaSintomaIdFicha");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEnfermedad_IdEnfermedad",
                table: "TipoEnfermedad",
                column: "IdEnfermedad");

            migrationBuilder.CreateIndex(
                name: "IX_UserRol_IdRol",
                table: "UserRol",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_FichaSintomas_IdFicha",
                table: "Detalles",
                column: "IdFicha",
                principalTable: "FichaSintomas",
                principalColumn: "IdFicha");

            migrationBuilder.AddForeignKey(
                name: "FK_FichaSintomas_Resultado_IdResultado",
                table: "FichaSintomas",
                column: "IdResultado",
                principalTable: "Resultado",
                principalColumn: "IdResultado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resultado_FichaSintomas_FichaSintomaIdFicha",
                table: "Resultado");

            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "HistoriaClinica");

            migrationBuilder.DropTable(
                name: "TipoEnfermedad");

            migrationBuilder.DropTable(
                name: "UserRol");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "FichaSintomas");

            migrationBuilder.DropTable(
                name: "Resultado");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Enfermedad");
        }
    }
}
