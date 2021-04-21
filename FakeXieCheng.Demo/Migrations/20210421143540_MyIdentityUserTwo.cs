using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class MyIdentityUserTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("b72cabbc-5bba-4e50-bef5-86dccb58362d"));

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
                keyValue: new Guid("084a85e4-25e5-4b4d-b544-d216cdd156c2"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("e15fd3cd-a22d-4dae-9f72-632029481be4"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("e4f09d8d-70e8-4341-bc3c-afe2afd436ca"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63af257f-ed3e-4e6d-ab40-82fd5e200836", "9e7cf76f-263c-42d9-a115-656866ef8d0c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac405777-3568-4ec8-8586-d4204c87b118", 0, null, "f3fa10ad-b5f7-4961-b9c6-b6be55377511", "172@qq.com", true, false, null, "172@QQ.COM", "172@QQ.COM", "AQAAAAEAACcQAAAAEEzJ7u4U8zPL78jP9tA+I3IB74Bha8TlhI0C9+dh9r56oBaB8N3EsQvmbXKwUDnUZQ==", "123456", false, "b674de35-1e2c-4e35-b112-6e98690602ab", false, "172@qq.com" });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("68294560-051d-473d-956c-be77201659be"), new DateTime(2021, 4, 21, 22, 35, 39, 527, DateTimeKind.Local).AddTicks(8362), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 6.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("cf34c11b-d97b-4b88-adb5-34ef211482f3"), new DateTime(2021, 4, 20, 22, 35, 39, 529, DateTimeKind.Local).AddTicks(2623), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 82.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("bf02d630-2df3-4d11-875b-ff322bafcd9e"), new DateTime(2021, 4, 19, 22, 35, 39, 529, DateTimeKind.Local).AddTicks(2833), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 39.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("305af930-f7cb-4f18-b777-c29cb0395d41"), new DateTime(2021, 4, 18, 22, 35, 39, 529, DateTimeKind.Local).AddTicks(2839), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 36.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "MyApplicationIdentityId" },
                values: new object[] { "ac405777-3568-4ec8-8586-d4204c87b118", "63af257f-ed3e-4e6d-ab40-82fd5e200836", null });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[,]
                {
                    { -1, "太美丽了", new Guid("68294560-051d-473d-956c-be77201659be"), "../images/1.jpg" },
                    { -2, "太美丽了11111", new Guid("cf34c11b-d97b-4b88-adb5-34ef211482f3"), "../images/2.jpg" },
                    { -3, "<<<<<<太美丽了11", new Guid("bf02d630-2df3-4d11-875b-ff322bafcd9e"), "../images/3.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ac405777-3568-4ec8-8586-d4204c87b118", "63af257f-ed3e-4e6d-ab40-82fd5e200836" });

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("305af930-f7cb-4f18-b777-c29cb0395d41"));

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63af257f-ed3e-4e6d-ab40-82fd5e200836");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac405777-3568-4ec8-8586-d4204c87b118");

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("68294560-051d-473d-956c-be77201659be"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("bf02d630-2df3-4d11-875b-ff322bafcd9e"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("cf34c11b-d97b-4b88-adb5-34ef211482f3"));

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("e15fd3cd-a22d-4dae-9f72-632029481be4"), new DateTime(2021, 4, 21, 22, 11, 16, 113, DateTimeKind.Local).AddTicks(4483), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 99.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("084a85e4-25e5-4b4d-b544-d216cdd156c2"), new DateTime(2021, 4, 20, 22, 11, 16, 114, DateTimeKind.Local).AddTicks(7163), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 1.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("e4f09d8d-70e8-4341-bc3c-afe2afd436ca"), new DateTime(2021, 4, 19, 22, 11, 16, 114, DateTimeKind.Local).AddTicks(7270), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 51.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("b72cabbc-5bba-4e50-bef5-86dccb58362d"), new DateTime(2021, 4, 18, 22, 11, 16, 114, DateTimeKind.Local).AddTicks(7275), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 51.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("e15fd3cd-a22d-4dae-9f72-632029481be4"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("084a85e4-25e5-4b4d-b544-d216cdd156c2"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("e4f09d8d-70e8-4341-bc3c-afe2afd436ca"), "../images/3.jpg" });
        }
    }
}
