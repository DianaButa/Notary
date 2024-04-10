using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notary.Migrations
{
    public partial class companyclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CIF",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CUI",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ContactAdress",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "CompanyClientId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilesCompanyClients",
                columns: table => new
                {
                  Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                  FilesId = table.Column<int>(type: "int", nullable: false),
                    CompanyClientId = table.Column<int>(type: "int", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesCompanyClients", x => new { x.FilesId, x.CompanyClientId });
                    table.ForeignKey(
                        name: "FK_FilesCompanyClients_CompanyClients_CompanyClientId",
                        column: x => x.CompanyClientId,
                        principalTable: "CompanyClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilesCompanyClients_Files_FilesId",
                        column: x => x.FilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CompanyClientId",
                table: "Documents",
                column: "CompanyClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesCompanyClients_CompanyClientId",
                table: "FilesCompanyClients",
                column: "CompanyClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CompanyClients_CompanyClientId",
                table: "Documents",
                column: "CompanyClientId",
                principalTable: "CompanyClients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CompanyClients_CompanyClientId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "FilesCompanyClients");

            migrationBuilder.DropTable(
                name: "CompanyClients");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CompanyClientId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CompanyClientId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "CIF",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CUI",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactAdress",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
