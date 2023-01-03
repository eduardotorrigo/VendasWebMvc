using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasWebMvc.Data.Migrations
{
    public partial class _1_primeira_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BaseSalary = table.Column<double>(type: "double", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRecord_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computers" },
                    { 2, "Electronics" },
                    { 3, "Fashion" },
                    { 4, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "BaseSalary", "BirthDate", "DepartmentId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1000.0, new DateTime(1998, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "bob@gmail.com", "Bob Brown" },
                    { 2, 3500.0, new DateTime(1979, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "maria@gmail.com", "Maria Green" },
                    { 3, 2200.0, new DateTime(1988, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "alex@gmail.com", "Alex Grey" },
                    { 4, 3000.0, new DateTime(1993, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "martha@gmail.com", "Martha Red" },
                    { 5, 4000.0, new DateTime(2000, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "donald@gmail.com", "Donald Blue" },
                    { 6, 3000.0, new DateTime(1997, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "bob@gmail.com", "Alex Pink" }
                });

            migrationBuilder.InsertData(
                table: "SalesRecord",
                columns: new[] { "Id", "Amount", "Date", "SellerId", "Status" },
                values: new object[,]
                {
                    { 1, 11000.0, new DateTime(2018, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 7000.0, new DateTime(2018, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 3, 4000.0, new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 4, 8000.0, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 5, 3000.0, new DateTime(2018, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 6, 2000.0, new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 7, 13000.0, new DateTime(2018, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 8, 4000.0, new DateTime(2018, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 9, 11000.0, new DateTime(2018, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0 },
                    { 10, 9000.0, new DateTime(2018, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 11, 6000.0, new DateTime(2018, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 12, 7000.0, new DateTime(2018, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0 },
                    { 13, 10000.0, new DateTime(2018, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 14, 3000.0, new DateTime(2018, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 15, 4000.0, new DateTime(2018, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 16, 2000.0, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 17, 12000.0, new DateTime(2018, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 18, 6000.0, new DateTime(2018, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 19, 8000.0, new DateTime(2018, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 20, 8000.0, new DateTime(2018, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 21, 9000.0, new DateTime(2018, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 22, 4000.0, new DateTime(2018, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 23, 11000.0, new DateTime(2018, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 24, 8000.0, new DateTime(2018, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 25, 7000.0, new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 26, 5000.0, new DateTime(2018, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 27, 9000.0, new DateTime(2018, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 28, 4000.0, new DateTime(2018, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 29, 12000.0, new DateTime(2018, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 30, 5000.0, new DateTime(2018, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecord_SellerId",
                table: "SalesRecord",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_DepartmentId",
                table: "Sellers",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRecord");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
