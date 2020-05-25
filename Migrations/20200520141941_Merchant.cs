using Microsoft.EntityFrameworkCore.Migrations;

namespace RajProj.Migrations
{
    public partial class Merchant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Merchant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerhchantName = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    MaxDailyTransactionAmount = table.Column<int>(nullable: false),
                    MinDailyTranAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchant", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Merchant");
        }
    }
}
