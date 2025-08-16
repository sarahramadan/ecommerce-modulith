using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcategoryseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "Catalog",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "Catalog",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Description", "ModificationDate", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("8af41da1-4217-49db-a7d3-2d2f702a7494"), "system", null, "A wide usage of mobile with different shape", null, null, "Mobile" },
                    { new Guid("8af41da1-4217-49db-a7d3-2d2f702a7495"), "system", null, "Different types of laptops for different usage", null, null, "Laptop" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Catalog",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Catalog",
                table: "Products",
                column: "CategoryId",
                principalSchema: "Catalog",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_CategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Catalog",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                schema: "Catalog",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
