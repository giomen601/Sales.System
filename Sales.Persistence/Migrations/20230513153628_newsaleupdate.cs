using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newsaleupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductSales",
                columns: new[] { "ProductId", "SaleId" },
                values: new object[] { 2, 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductSales",
                keyColumns: new[] { "ProductId", "SaleId" },
                keyValues: new object[] { 2, 4 });
        }
    }
}
