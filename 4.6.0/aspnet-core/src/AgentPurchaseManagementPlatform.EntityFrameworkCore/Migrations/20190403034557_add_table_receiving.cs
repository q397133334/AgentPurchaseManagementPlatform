using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgentPurchaseManagementPlatform.Migrations
{
    public partial class add_table_receiving : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingPersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReceivingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingPersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingPersions_Receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "Receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPersions_Name",
                table: "ReceivingPersions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPersions_ReceivingId",
                table: "ReceivingPersions",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_Address",
                table: "Receivings",
                column: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivingPersions");

            migrationBuilder.DropTable(
                name: "Receivings");
        }
    }
}
