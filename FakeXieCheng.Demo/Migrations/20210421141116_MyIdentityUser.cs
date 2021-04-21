using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class MyIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("8ff6fae5-04be-4403-a7f0-1e2d92720b90"));

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
                keyValue: new Guid("56198f90-2341-4fb3-a4a8-a09d60da206a"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("7c95d950-911b-4913-a024-c345f9c34bf1"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("a2516e07-cfc4-4c47-b050-c006bd81d10b"));

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationIdentityId",
                table: "AspNetUserTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationIdentityId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationIdentityId",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyApplicationIdentityId",
                table: "AspNetUserClaims",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_MyApplicationIdentityId",
                table: "AspNetUserTokens",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_MyApplicationIdentityId",
                table: "AspNetUserRoles",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_MyApplicationIdentityId",
                table: "AspNetUserLogins",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_MyApplicationIdentityId",
                table: "AspNetUserClaims",
                column: "MyApplicationIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserClaims",
                column: "MyApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserLogins",
                column: "MyApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserRoles",
                column: "MyApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserTokens",
                column: "MyApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_MyApplicationIdentityId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserTokens_MyApplicationIdentityId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_MyApplicationIdentityId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_MyApplicationIdentityId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_MyApplicationIdentityId",
                table: "AspNetUserClaims");

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

            migrationBuilder.DropColumn(
                name: "MyApplicationIdentityId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MyApplicationIdentityId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "MyApplicationIdentityId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "MyApplicationIdentityId",
                table: "AspNetUserClaims");

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("7c95d950-911b-4913-a024-c345f9c34bf1"), new DateTime(2021, 4, 21, 8, 49, 45, 28, DateTimeKind.Local).AddTicks(5614), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 50.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("56198f90-2341-4fb3-a4a8-a09d60da206a"), new DateTime(2021, 4, 20, 8, 49, 45, 29, DateTimeKind.Local).AddTicks(4102), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 96.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("a2516e07-cfc4-4c47-b050-c006bd81d10b"), new DateTime(2021, 4, 19, 8, 49, 45, 29, DateTimeKind.Local).AddTicks(4162), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 37.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("8ff6fae5-04be-4403-a7f0-1e2d92720b90"), new DateTime(2021, 4, 18, 8, 49, 45, 29, DateTimeKind.Local).AddTicks(4166), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 21.0, null, "万仙山", (byte)3, null, null }
                });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -1, "太美丽了", new Guid("7c95d950-911b-4913-a024-c345f9c34bf1"), "../images/1.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -2, "太美丽了11111", new Guid("56198f90-2341-4fb3-a4a8-a09d60da206a"), "../images/2.jpg" });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[] { -3, "<<<<<<太美丽了11", new Guid("a2516e07-cfc4-4c47-b050-c006bd81d10b"), "../images/3.jpg" });
        }
    }
}
