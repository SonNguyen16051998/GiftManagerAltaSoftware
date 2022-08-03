using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftCodeManager.Migrations
{
    public partial class giftmanager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Campaign_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campaign_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Auto_Update = table.Column<bool>(type: "bit", nullable: false),
                    CheckCusJoin_OnlyOnce = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Code_UsageLimit = table.Column<int>(type: "int", nullable: false),
                    Unlimited = table.Column<bool>(type: "bit", nullable: false),
                    Code_Count = table.Column<int>(type: "int", nullable: false),
                    Charset = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Code_Length = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Postfix = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Campaign_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNo = table.Column<string>(type: "varchar(15)", nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Type_Of_Business = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Is_Block = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    User_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNo = table.Column<string>(type: "Char(15)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Barcodes",
                columns: table => new
                {
                    Campaign_Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code_redemption_limit = table.Column<int>(type: "int", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unlimited = table.Column<bool>(type: "bit", nullable: false),
                    Code_count = table.Column<int>(type: "int", nullable: false),
                    Charset = table.Column<string>(type: "varchar(20)", nullable: false),
                    Code_Length = table.Column<int>(type: "int", nullable: false),
                    Prefix = table.Column<string>(type: "varchar(20)", nullable: false),
                    Postfix = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcodes", x => x.Campaign_Id);
                    table.ForeignKey(
                        name: "FK_Barcodes_Campaigns_Campaign_Id",
                        column: x => x.Campaign_Id,
                        principalTable: "Campaigns",
                        principalColumn: "Campaign_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Gift_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gift_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Code_Count = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Campaign_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Gift_Id);
                    table.ForeignKey(
                        name: "FK_Gifts_Campaigns_Campaign_Id",
                        column: x => x.Campaign_Id,
                        principalTable: "Campaigns",
                        principalColumn: "Campaign_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usedbarcode_Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Barcode_Id = table.Column<int>(type: "int", nullable: false),
                    Spin_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Scanned_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Scanned_Status = table.Column<bool>(type: "bit", nullable: false),
                    Used_for_pin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usedbarcode_Customers", x => new { x.Customer_Id, x.Barcode_Id });
                    table.ForeignKey(
                        name: "FK_Usedbarcode_Customers_Barcodes_Barcode_Id",
                        column: x => x.Barcode_Id,
                        principalTable: "Barcodes",
                        principalColumn: "Campaign_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usedbarcode_Customers_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Gift_Id = table.Column<int>(type: "int", nullable: false),
                    Rule_Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Gift_Amount = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllDay = table.Column<bool>(type: "bit", nullable: false),
                    Probability = table.Column<int>(type: "int", nullable: false),
                    Monthly_On_Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime_Repeat = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime_Repeat = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Gift_Id);
                    table.ForeignKey(
                        name: "FK_Rules_Gifts_Gift_Id",
                        column: x => x.Gift_Id,
                        principalTable: "Gifts",
                        principalColumn: "Gift_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Gift_Id = table.Column<int>(type: "int", nullable: false),
                    Win_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sent_Gift_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => new { x.Customer_Id, x.Gift_Id });
                    table.ForeignKey(
                        name: "FK_Winners_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Winners_Gifts_Gift_Id",
                        column: x => x.Gift_Id,
                        principalTable: "Gifts",
                        principalColumn: "Gift_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Campaign_Id",
                table: "Gifts",
                column: "Campaign_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usedbarcode_Customers_Barcode_Id",
                table: "Usedbarcode_Customers",
                column: "Barcode_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_Gift_Id",
                table: "Winners",
                column: "Gift_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Usedbarcode_Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.DropTable(
                name: "Barcodes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
