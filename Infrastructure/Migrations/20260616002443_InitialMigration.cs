using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dn_id = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    version = table.Column<long>(type: "bigint", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student", x => x.id);
                    table.ForeignKey(
                        name: "fk_student_rol_rol_id",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_student_dn_id",
                table: "Student",
                column: "dn_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_email",
                table: "Student",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_student_rol_id",
                table: "Student",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
