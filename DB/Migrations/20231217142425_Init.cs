using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorksStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trustString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    rodzajUzytkownika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_UserTypes_rodzajUzytkownika",
                        column: x => x.rodzajUzytkownika,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonAdderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Persons_PersonAdderId",
                        column: x => x.PersonAdderId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonAdderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModelType_Persons_PersonAdderId",
                        column: x => x.PersonAdderId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personId = table.Column<int>(type: "int", nullable: false),
                    isVisible = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesTypes_Persons_personId",
                        column: x => x.personId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WersjaId = table.Column<int>(type: "int", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    PersonAdderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Brand_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModels_CarModelType_WersjaId",
                        column: x => x.WersjaId,
                        principalTable: "CarModelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CarModels_Persons_PersonAdderId",
                        column: x => x.PersonAdderId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    ModelSamochoduId = table.Column<int>(type: "int", nullable: false),
                    rokProdukcji = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    pojemnoscSkokowa = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    rodzajPaliwaId = table.Column<int>(type: "int", nullable: false),
                    przebieg = table.Column<long>(type: "bigint", maxLength: 5000, nullable: false),
                    nr_rejestracyjny = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    WlascicielId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarModels_ModelSamochoduId",
                        column: x => x.ModelSamochoduId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Fuel_rodzajPaliwaId",
                        column: x => x.rodzajPaliwaId,
                        principalTable: "Fuel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Persons_WlascicielId",
                        column: x => x.WlascicielId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SamochodId = table.Column<int>(type: "int", nullable: false),
                    PersonWorkerId = table.Column<int>(type: "int", nullable: false),
                    rodzajUslugiId = table.Column<int>(type: "int", nullable: false),
                    statusZleceniaId = table.Column<int>(type: "int", nullable: false),
                    dataPrzekazaniaPojazdu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpisZdarzenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataWplyniecia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Car_SamochodId",
                        column: x => x.SamochodId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_Persons_PersonWorkerId",
                        column: x => x.PersonWorkerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_ServicesTypes_rodzajUslugiId",
                        column: x => x.rodzajUslugiId,
                        principalTable: "ServicesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_WorksStatus_statusZleceniaId",
                        column: x => x.statusZleceniaId,
                        principalTable: "WorksStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "WordAdnotation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZlecenieId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UslugaId = table.Column<int>(type: "int", nullable: false),
                    dataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilosc = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordAdnotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordAdnotation_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordAdnotation_Services_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordAdnotation_Works_ZlecenieId",
                        column: x => x.ZlecenieId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_PersonAdderId",
                table: "Brand",
                column: "PersonAdderId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelSamochoduId",
                table: "Car",
                column: "ModelSamochoduId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_rodzajPaliwaId",
                table: "Car",
                column: "rodzajPaliwaId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_WlascicielId",
                table: "Car",
                column: "WlascicielId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MarkaId",
                table: "CarModels",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_PersonAdderId",
                table: "CarModels",
                column: "PersonAdderId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_WersjaId",
                table: "CarModels",
                column: "WersjaId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelType_PersonAdderId",
                table: "CarModelType",
                column: "PersonAdderId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_rodzajUzytkownika",
                table: "Persons",
                column: "rodzajUzytkownika");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesTypes_personId",
                table: "ServicesTypes",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_WordAdnotation_PersonId",
                table: "WordAdnotation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_WordAdnotation_UslugaId",
                table: "WordAdnotation",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_WordAdnotation_ZlecenieId",
                table: "WordAdnotation",
                column: "ZlecenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_PersonWorkerId",
                table: "Works",
                column: "PersonWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_rodzajUslugiId",
                table: "Works",
                column: "rodzajUslugiId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_SamochodId",
                table: "Works",
                column: "SamochodId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_statusZleceniaId",
                table: "Works",
                column: "statusZleceniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordAdnotation");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "ServicesTypes");

            migrationBuilder.DropTable(
                name: "WorksStatus");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CarModelType");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
