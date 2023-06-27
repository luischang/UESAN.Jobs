using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UESAN.Jobs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    IdCompetencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competen__DA802ADD4A154480", x => x.IdCompetencia);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A6C7EDC659", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    idEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RUC = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    direccion = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    telefono = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empresa__75D2CED4BE8FBEF3", x => x.idEmpresa);
                    table.ForeignKey(
                        name: "FK__Empresa__idUsuar__398D8EEE",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Postulante",
                columns: table => new
                {
                    IdPostulante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DNI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    direccion = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    telefono = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CV = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    certificados = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Postulan__D8831F4D6EB73B5E", x => x.IdPostulante);
                    table.ForeignKey(
                        name: "FK__Postulant__idUsu__3D5E1FD2",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    idOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEmpresa = table.Column<int>(type: "int", nullable: true),
                    puesto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    requisitos = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    certificados = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    funciones = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ubicacion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    modalidad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    numeroPostulantes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Oferta__05A1245EB4255D90", x => x.idOferta);
                    table.ForeignKey(
                        name: "FK__Oferta__idEmpres__3A81B327",
                        column: x => x.idEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa");
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    idCalificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdPostulante = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Califica__E056358FC75CD105", x => x.idCalificacion);
                    table.ForeignKey(
                        name: "FK__Calificac__IdPos__34C8D9D1",
                        column: x => x.IdPostulante,
                        principalTable: "Postulante",
                        principalColumn: "IdPostulante");
                    table.ForeignKey(
                        name: "FK__Calificac__idEmp__33D4B598",
                        column: x => x.idEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa");
                });

            migrationBuilder.CreateTable(
                name: "CompetenciasPostulante",
                columns: table => new
                {
                    IdCompetenciaPostulante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetencia = table.Column<int>(type: "int", nullable: false),
                    IdPostulante = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competen__5BBD3E385DD888F7", x => x.IdCompetenciaPostulante);
                    table.ForeignKey(
                        name: "FK__Competenc__IdCom__37A5467C",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "IdCompetencia");
                    table.ForeignKey(
                        name: "FK__Competenc__IdPos__38996AB5",
                        column: x => x.IdPostulante,
                        principalTable: "Postulante",
                        principalColumn: "IdPostulante");
                });

            migrationBuilder.CreateTable(
                name: "CompetenciasOferta",
                columns: table => new
                {
                    IdCompetenciaOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetencia = table.Column<int>(type: "int", nullable: false),
                    IdOferta = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Competen__65E5E338284A97F8", x => x.IdCompetenciaOferta);
                    table.ForeignKey(
                        name: "FK__Competenc__IdCom__35BCFE0A",
                        column: x => x.IdCompetencia,
                        principalTable: "Competencias",
                        principalColumn: "IdCompetencia");
                    table.ForeignKey(
                        name: "FK__Competenc__IdOfe__36B12243",
                        column: x => x.IdOferta,
                        principalTable: "Oferta",
                        principalColumn: "idOferta");
                });

            migrationBuilder.CreateTable(
                name: "OfertaPostular",
                columns: table => new
                {
                    idOfertaPostular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idOferta = table.Column<int>(type: "int", nullable: true),
                    idPostulante = table.Column<int>(type: "int", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OfertaPo__2DB5694C2C5ABC94", x => x.idOfertaPostular);
                    table.ForeignKey(
                        name: "idOferta",
                        column: x => x.idOferta,
                        principalTable: "Oferta",
                        principalColumn: "idOferta");
                    table.ForeignKey(
                        name: "idPostulante",
                        column: x => x.idPostulante,
                        principalTable: "Postulante",
                        principalColumn: "IdPostulante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_idEmpresa",
                table: "Calificaciones",
                column: "idEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdPostulante",
                table: "Calificaciones",
                column: "IdPostulante");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasOferta_IdCompetencia",
                table: "CompetenciasOferta",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasOferta_IdOferta",
                table: "CompetenciasOferta",
                column: "IdOferta");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasPostulante_IdCompetencia",
                table: "CompetenciasPostulante",
                column: "IdCompetencia");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasPostulante_IdPostulante",
                table: "CompetenciasPostulante",
                column: "IdPostulante");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_idUsuario",
                table: "Empresa",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_idEmpresa",
                table: "Oferta",
                column: "idEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPostular_idOferta",
                table: "OfertaPostular",
                column: "idOferta");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaPostular_idPostulante",
                table: "OfertaPostular",
                column: "idPostulante");

            migrationBuilder.CreateIndex(
                name: "IX_Postulante_idUsuario",
                table: "Postulante",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "CompetenciasOferta");

            migrationBuilder.DropTable(
                name: "CompetenciasPostulante");

            migrationBuilder.DropTable(
                name: "OfertaPostular");

            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Postulante");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
