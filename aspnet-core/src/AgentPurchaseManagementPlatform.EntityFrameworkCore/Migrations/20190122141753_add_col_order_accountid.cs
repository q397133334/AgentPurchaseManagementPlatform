using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class add_col_order_accountid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Orders",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Orders");
        }
    }
}
