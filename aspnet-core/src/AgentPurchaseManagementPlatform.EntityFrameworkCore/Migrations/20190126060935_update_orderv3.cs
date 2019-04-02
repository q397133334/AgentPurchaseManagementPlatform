using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class update_orderv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TruePrice",
                table: "Orders",
                newName: "TrueSalePrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ChinalogisticsPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TransportPrice",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TrueBuyPrice",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChinalogisticsPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TransportPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TrueBuyPrice",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TrueSalePrice",
                table: "Orders",
                newName: "TruePrice");
        }
    }
}
