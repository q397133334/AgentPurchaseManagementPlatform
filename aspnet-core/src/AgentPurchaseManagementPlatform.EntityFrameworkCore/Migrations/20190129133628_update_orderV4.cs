using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class update_orderV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TrueSalePrice",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TrueBuyPrice",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TransportPrice",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrueSalePrice",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrueBuyPrice",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TransportPrice",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
