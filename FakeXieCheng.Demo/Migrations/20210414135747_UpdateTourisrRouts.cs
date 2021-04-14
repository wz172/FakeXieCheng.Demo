using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class UpdateTourisrRouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("49758b3e-724f-4942-9ec2-70e73f6810da"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("7c88ac9d-ab92-4302-b0a8-95d9613cae8d"));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "TouristRout",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StratCity",
                table: "TouristRout",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TravlDays",
                table: "TouristRout",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "TripType",
                table: "TouristRout",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("780a1962-602f-46a2-9719-72f72810106e"), new DateTime(2021, 4, 14, 21, 57, 46, 927, DateTimeKind.Local).AddTicks(7708), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, null, null, "青天河", (byte)0, null, null });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[] { new Guid("8e34dd2f-bdb6-4053-b4d5-3443f712b9c0"), new DateTime(2021, 4, 13, 21, 57, 46, 929, DateTimeKind.Local).AddTicks(3806), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, null, null, "云台山", (byte)0, null, null });

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -3,
                column: "TouristRoutID",
                value: new Guid("8e34dd2f-bdb6-4053-b4d5-3443f712b9c0"));

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -2,
                column: "TouristRoutID",
                value: new Guid("8e34dd2f-bdb6-4053-b4d5-3443f712b9c0"));

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -1,
                column: "TouristRoutID",
                value: new Guid("780a1962-602f-46a2-9719-72f72810106e"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("780a1962-602f-46a2-9719-72f72810106e"));

            migrationBuilder.DeleteData(
                table: "TouristRout",
                keyColumn: "ID",
                keyValue: new Guid("8e34dd2f-bdb6-4053-b4d5-3443f712b9c0"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "TouristRout");

            migrationBuilder.DropColumn(
                name: "StratCity",
                table: "TouristRout");

            migrationBuilder.DropColumn(
                name: "TravlDays",
                table: "TouristRout");

            migrationBuilder.DropColumn(
                name: "TripType",
                table: "TouristRout");

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("49758b3e-724f-4942-9ec2-70e73f6810da"), new DateTime(2021, 4, 14, 21, 36, 8, 688, DateTimeKind.Local).AddTicks(5422), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, "青天河", null });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("7c88ac9d-ab92-4302-b0a8-95d9613cae8d"), new DateTime(2021, 4, 13, 21, 36, 8, 690, DateTimeKind.Local).AddTicks(1344), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, "云台山", null });

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -3,
                column: "TouristRoutID",
                value: new Guid("7c88ac9d-ab92-4302-b0a8-95d9613cae8d"));

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -2,
                column: "TouristRoutID",
                value: new Guid("7c88ac9d-ab92-4302-b0a8-95d9613cae8d"));

            migrationBuilder.UpdateData(
                table: "TouristRoutPictures",
                keyColumn: "ID",
                keyValue: -1,
                column: "TouristRoutID",
                value: new Guid("49758b3e-724f-4942-9ec2-70e73f6810da"));
        }
    }
}
