using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAppBack.Migrations
{
    /// <inheritdoc />
    public partial class FixedIdInNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Groups_group_idid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Groups_group_idid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Products_product_idid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_supplier_idid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Customers_customer_idid",
                table: "Sellings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Groups_group_idid",
                table: "Sellings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Products_product_idid",
                table: "Sellings");

            migrationBuilder.RenameColumn(
                name: "product_idid",
                table: "Sellings",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "group_idid",
                table: "Sellings",
                newName: "groupid");

            migrationBuilder.RenameColumn(
                name: "customer_idid",
                table: "Sellings",
                newName: "customerid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_product_idid",
                table: "Sellings",
                newName: "IX_Sellings_productid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_group_idid",
                table: "Sellings",
                newName: "IX_Sellings_groupid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_customer_idid",
                table: "Sellings",
                newName: "IX_Sellings_customerid");

            migrationBuilder.RenameColumn(
                name: "supplier_idid",
                table: "Purchases",
                newName: "supplierid");

            migrationBuilder.RenameColumn(
                name: "product_idid",
                table: "Purchases",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "group_idid",
                table: "Purchases",
                newName: "groupid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_supplier_idid",
                table: "Purchases",
                newName: "IX_Purchases_supplierid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_product_idid",
                table: "Purchases",
                newName: "IX_Purchases_productid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_group_idid",
                table: "Purchases",
                newName: "IX_Purchases_groupid");

            migrationBuilder.RenameColumn(
                name: "group_idid",
                table: "Products",
                newName: "groupid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_group_idid",
                table: "Products",
                newName: "IX_Products_groupid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Groups_groupid",
                table: "Products",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Groups_groupid",
                table: "Purchases",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Products_productid",
                table: "Purchases",
                column: "productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_supplierid",
                table: "Purchases",
                column: "supplierid",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Customers_customerid",
                table: "Sellings",
                column: "customerid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Groups_groupid",
                table: "Sellings",
                column: "groupid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Products_productid",
                table: "Sellings",
                column: "productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Groups_groupid",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Groups_groupid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Products_productid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Suppliers_supplierid",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Customers_customerid",
                table: "Sellings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Groups_groupid",
                table: "Sellings");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_Products_productid",
                table: "Sellings");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "Sellings",
                newName: "product_idid");

            migrationBuilder.RenameColumn(
                name: "groupid",
                table: "Sellings",
                newName: "group_idid");

            migrationBuilder.RenameColumn(
                name: "customerid",
                table: "Sellings",
                newName: "customer_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_productid",
                table: "Sellings",
                newName: "IX_Sellings_product_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_groupid",
                table: "Sellings",
                newName: "IX_Sellings_group_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Sellings_customerid",
                table: "Sellings",
                newName: "IX_Sellings_customer_idid");

            migrationBuilder.RenameColumn(
                name: "supplierid",
                table: "Purchases",
                newName: "supplier_idid");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "Purchases",
                newName: "product_idid");

            migrationBuilder.RenameColumn(
                name: "groupid",
                table: "Purchases",
                newName: "group_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_supplierid",
                table: "Purchases",
                newName: "IX_Purchases_supplier_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_productid",
                table: "Purchases",
                newName: "IX_Purchases_product_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_groupid",
                table: "Purchases",
                newName: "IX_Purchases_group_idid");

            migrationBuilder.RenameColumn(
                name: "groupid",
                table: "Products",
                newName: "group_idid");

            migrationBuilder.RenameIndex(
                name: "IX_Products_groupid",
                table: "Products",
                newName: "IX_Products_group_idid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Groups_group_idid",
                table: "Products",
                column: "group_idid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Groups_group_idid",
                table: "Purchases",
                column: "group_idid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Products_product_idid",
                table: "Purchases",
                column: "product_idid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Suppliers_supplier_idid",
                table: "Purchases",
                column: "supplier_idid",
                principalTable: "Suppliers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Customers_customer_idid",
                table: "Sellings",
                column: "customer_idid",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Groups_group_idid",
                table: "Sellings",
                column: "group_idid",
                principalTable: "Groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_Products_product_idid",
                table: "Sellings",
                column: "product_idid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
