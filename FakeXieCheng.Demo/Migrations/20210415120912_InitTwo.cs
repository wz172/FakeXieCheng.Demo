using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class InitTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristRout",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    OriginalPrice = table.Column<decimal>(nullable: false),
                    DriinalPrice = table.Column<decimal>(nullable: false),
                    DiscountPresent = table.Column<float>(nullable: true),
                    CreateTime = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Fees = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: true),
                    TravlDays = table.Column<byte>(nullable: false),
                    TripType = table.Column<int>(nullable: true),
                    StratCity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TouristRoutPictures",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(maxLength: 255, nullable: true),
                    Destription = table.Column<string>(nullable: true),
                    TouristRoutID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRoutPictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TouristRoutPictures_TouristRout_TouristRoutID",
                        column: x => x.TouristRoutID,
                        principalTable: "TouristRout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("19ebe51a-8924-44e4-91e3-55e0ce19e29e"), new DateTime(2021, 4, 15, 20, 9, 12, 128, DateTimeKind.Local).AddTicks(2144), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, null, null, "青天河", (byte)0, null, null });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("be2e48b1-e45e-49df-9015-c2e6077edd9e"), new DateTime(2021, 4, 14, 20, 9, 12, 129, DateTimeKind.Local).AddTicks(7934), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, null, null, "云台山", (byte)0, null, null });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("19ebe51a-8924-44e4-91e3-55e0ce19e29e"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("be2e48b1-e45e-49df-9015-c2e6077edd9e"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("be2e48b1-e45e-49df-9015-c2e6077edd9e"), "../images/3.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_TouristRoutPictures_TouristRoutID",
                table: "TouristRoutPictures",
                column: "TouristRoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristRoutPictures");

            migrationBuilder.DropTable(
                name: "TouristRout");
        }
    }
}
