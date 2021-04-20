using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class IdentityTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("a1b3cc6f-6d5a-4ae8-9bba-f20e502259b3"));

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("17cd8060-1a1f-460c-b335-13d7198bac17"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("2d41ddd2-9de7-4596-997e-b69d560d8f66"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("90ecc4dc-e9c4-41d1-915e-496558ed343f"));

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("b437cb5a-321d-4901-8059-17174d120ef4"), new DateTime(2021, 4, 20, 23, 42, 31, 567, DateTimeKind.Local).AddTicks(8349), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 73.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("e6846cfb-f4ad-4036-9122-917f683d71bd"), new DateTime(2021, 4, 19, 23, 42, 31, 569, DateTimeKind.Local).AddTicks(7355), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 71.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("167addae-d869-43cf-99aa-c6bdad2fe130"), new DateTime(2021, 4, 18, 23, 42, 31, 569, DateTimeKind.Local).AddTicks(7492), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 90.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("7aa32031-dfb5-4d1d-814b-8f61a6974d8d"), new DateTime(2021, 4, 17, 23, 42, 31, 569, DateTimeKind.Local).AddTicks(7498), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 13.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("b437cb5a-321d-4901-8059-17174d120ef4"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("e6846cfb-f4ad-4036-9122-917f683d71bd"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("167addae-d869-43cf-99aa-c6bdad2fe130"), "../images/3.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("7aa32031-dfb5-4d1d-814b-8f61a6974d8d"));

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("167addae-d869-43cf-99aa-c6bdad2fe130"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("b437cb5a-321d-4901-8059-17174d120ef4"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("e6846cfb-f4ad-4036-9122-917f683d71bd"));

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("90ecc4dc-e9c4-41d1-915e-496558ed343f"), new DateTime(2021, 4, 20, 23, 32, 4, 420, DateTimeKind.Local).AddTicks(920), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 73.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("17cd8060-1a1f-460c-b335-13d7198bac17"), new DateTime(2021, 4, 19, 23, 32, 4, 421, DateTimeKind.Local).AddTicks(4995), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 52.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("2d41ddd2-9de7-4596-997e-b69d560d8f66"), new DateTime(2021, 4, 18, 23, 32, 4, 421, DateTimeKind.Local).AddTicks(5183), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 2.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("a1b3cc6f-6d5a-4ae8-9bba-f20e502259b3"), new DateTime(2021, 4, 17, 23, 32, 4, 421, DateTimeKind.Local).AddTicks(5199), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 8.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("90ecc4dc-e9c4-41d1-915e-496558ed343f"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("17cd8060-1a1f-460c-b335-13d7198bac17"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("2d41ddd2-9de7-4596-997e-b69d560d8f66"), "../images/3.jpg" });
        }
    }
}
