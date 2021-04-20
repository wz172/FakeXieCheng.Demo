using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class IdentityDbContextAndAddServerOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("e90be105-2eeb-4096-a75c-032f80760e32"));

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
                keyValue: new Guid("040366b7-9e36-420b-89f0-e522fc85ed79"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("95c0fa88-81b3-4a48-bcb1-380961a05dc9"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("b6b00672-5c1c-4a66-9dd3-a792967e54ba"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("b6b00672-5c1c-4a66-9dd3-a792967e54ba"), new DateTime(2021, 4, 20, 23, 6, 3, 103, DateTimeKind.Local).AddTicks(1619), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 2.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("95c0fa88-81b3-4a48-bcb1-380961a05dc9"), new DateTime(2021, 4, 19, 23, 6, 3, 104, DateTimeKind.Local).AddTicks(2967), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 4.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("040366b7-9e36-420b-89f0-e522fc85ed79"), new DateTime(2021, 4, 18, 23, 6, 3, 104, DateTimeKind.Local).AddTicks(3083), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 49.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("e90be105-2eeb-4096-a75c-032f80760e32"), new DateTime(2021, 4, 17, 23, 6, 3, 104, DateTimeKind.Local).AddTicks(3089), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 14.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("b6b00672-5c1c-4a66-9dd3-a792967e54ba"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("95c0fa88-81b3-4a48-bcb1-380961a05dc9"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("040366b7-9e36-420b-89f0-e522fc85ed79"), "../images/3.jpg" });
        }
    }
}
