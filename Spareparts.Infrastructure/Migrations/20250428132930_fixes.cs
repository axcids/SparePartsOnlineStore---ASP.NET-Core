using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spareparts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsProducts_Cars_CarId",
                table: "CarsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsProducts_ProductsDetails_ProductId",
                table: "CarsProducts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProduct_ProductDetails",
                table: "SupplierProduct");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProduct_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProduct_ProductDetails",
                table: "SupplierProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProduct_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarsProducts_Cars_CarId",
                table: "CarsProducts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsProducts_ProductsDetails_ProductId",
                table: "CarsProducts",
                column: "ProductId",
                principalTable: "ProductsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsProducts_Cars_CarId",
                table: "CarsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsProducts_ProductsDetails_ProductId",
                table: "CarsProducts");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProduct_ProductDetails",
                table: "SupplierProduct");

            migrationBuilder.DropIndex(
                name: "IX_SupplierProduct_SupplierId",
                table: "SupplierProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProduct_ProductDetails",
                table: "SupplierProduct",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProduct_SupplierId",
                table: "SupplierProduct",
                column: "SupplierId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsProducts_Cars_CarId",
                table: "CarsProducts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsProducts_ProductsDetails_ProductId",
                table: "CarsProducts",
                column: "ProductId",
                principalTable: "ProductsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
