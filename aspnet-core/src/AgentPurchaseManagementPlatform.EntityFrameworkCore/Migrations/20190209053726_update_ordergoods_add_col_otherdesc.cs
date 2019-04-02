using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class update_ordergoods_add_col_otherdesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherDesc",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherDesc",
                table: "Orders");
        }
    }
}
