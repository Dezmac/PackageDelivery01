using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackageDelivery01.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomerTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customer_CustomerID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Trucks_TruckID",
                table: "Trackings");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customer_CustomerID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "TruckID1",
                table: "Trackings",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Trackings_TruckID1",
                table: "Trackings",
                column: "TruckID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customers_CustomerID",
                table: "Packages",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Trucks_TruckID",
                table: "Trackings",
                column: "TruckID",
                principalTable: "Trucks",
                principalColumn: "TruckID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Trucks_TruckID1",
                table: "Trackings",
                column: "TruckID1",
                principalTable: "Trucks",
                principalColumn: "TruckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Customers_CustomerID",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Trucks_TruckID",
                table: "Trackings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trackings_Trucks_TruckID1",
                table: "Trackings");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Trackings_TruckID1",
                table: "Trackings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TruckID1",
                table: "Trackings");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Customer_CustomerID",
                table: "Packages",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trackings_Trucks_TruckID",
                table: "Trackings",
                column: "TruckID",
                principalTable: "Trucks",
                principalColumn: "TruckID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customer_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
