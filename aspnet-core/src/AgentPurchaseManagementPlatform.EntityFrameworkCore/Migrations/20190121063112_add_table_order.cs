using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class add_table_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ChinaDateTime = table.Column<DateTime>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 4000, nullable: false),
                    ProductUrl = table.Column<string>(maxLength: 4000, nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    UsaLogisticsNumber = table.Column<string>(nullable: true),
                    CustomerDesc = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    TruePrice = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    Specifications = table.Column<string>(nullable: true),
                    TransportNumber = table.Column<string>(nullable: true),
                    TaobaoShop = table.Column<string>(nullable: true),
                    ChinaLogisticsNumber = table.Column<string>(nullable: true),
                    NotBuyDesc = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_State",
                table: "Orders",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UsaLogisticsNumber",
                table: "Orders",
                column: "UsaLogisticsNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
