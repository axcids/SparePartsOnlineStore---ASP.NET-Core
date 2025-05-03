using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spareparts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_ProductsDetails_ProductId",
                table: "SupplierProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_ProductsDetails_ProductId",
                table: "SupplierProduct",
                column: "ProductId",
                principalTable: "ProductsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_ProductsDetails_ProductId",
                table: "SupplierProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_ProductsDetails_ProductId",
                table: "SupplierProduct",
                column: "ProductId",
                principalTable: "ProductsDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierProduct_Suppliers_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
