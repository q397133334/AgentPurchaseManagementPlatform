using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class update_ordergoods_add_col_WarehouseId_WarehouseName_WarehouseConsignee_WarehouseConsigneeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseConsignee",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseConsigneeName",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseName",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarehouseConsignee",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WarehouseConsigneeName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WarehouseName",
                table: "Orders");
        }
    }
}
