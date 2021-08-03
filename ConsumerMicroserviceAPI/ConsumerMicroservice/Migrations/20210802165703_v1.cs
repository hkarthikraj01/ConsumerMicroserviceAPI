using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsumerMicroservice.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "businesses",
                columns: table => new
                {
                    BusinessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualTurnOver = table.Column<int>(type: "int", nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    CapitalInvested = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businesses", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "consumers",
                columns: table => new
                {
                    ConsumerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessOverview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityofConsumer = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumers", x => x.ConsumerId);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    PropertyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuildingSqft = table.Column<int>(type: "int", nullable: false),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingStoreys = table.Column<int>(type: "int", nullable: false),
                    BuildingAge = table.Column<int>(type: "int", nullable: false),
                    CostOfTheAsset = table.Column<int>(type: "int", nullable: false),
                    SalvageValue = table.Column<int>(type: "int", nullable: false),
                    UsefulLifeOfTheAsset = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.PropertyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "businesses");

            migrationBuilder.DropTable(
                name: "consumers");

            migrationBuilder.DropTable(
                name: "properties");
        }
    }
}
