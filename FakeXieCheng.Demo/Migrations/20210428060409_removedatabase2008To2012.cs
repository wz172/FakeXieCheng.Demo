using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.Demo.Migrations
{
    public partial class removedatabase2008To2012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristRout",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DriinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    MyApplicationIdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_MyApplicationIdentityId",
                        column: x => x.MyApplicationIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    MyApplicationIdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_MyApplicationIdentityId",
                        column: x => x.MyApplicationIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    MyApplicationIdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_MyApplicationIdentityId",
                        column: x => x.MyApplicationIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    MyApplicationIdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_MyApplicationIdentityId",
                        column: x => x.MyApplicationIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    CreateTimeUtc = table.Column<DateTime>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    ThirdPartyPayMent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userOrders_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "CartLineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristID = table.Column<Guid>(nullable: false),
                    TouristRoutID = table.Column<Guid>(nullable: true),
                    ShoppingCartId = table.Column<Guid>(nullable: true),
                    OrederId = table.Column<Guid>(nullable: true),
                    DiscountPresent = table.Column<float>(nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartLineItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLineItems_TouristRout_TouristRoutID",
                        column: x => x.TouristRoutID,
                        principalTable: "TouristRout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLineItems_userOrders_UserOrderId",
                        column: x => x.UserOrderId,
                        principalTable: "userOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3faa1348-c9a0-49aa-912b-0d5007f806a7", "b0eb9187-1004-4771-8965-d16461b9e26c", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb28d4b9-bb87-4e9f-8157-8710337d21ab", 0, null, "3466eb42-745b-461a-b9a9-a1048621d4d4", "172@qq.com", true, false, null, "172@QQ.COM", "172@QQ.COM", "AQAAAAEAACcQAAAAEKKz/H8hm7L24PIRM8OvIoLyEfPUApIaNOo4iSGsIgkVqsSpjuKmWGcIUL4al5bCkQ==", "123456", false, "ef1afb21-3529-4029-8286-f81448fe52ab", false, "172@qq.com" });

            migrationBuilder.InsertData(
                table: "TouristRout",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "DriinalPrice", "Features", "Fees", "Notes", "OriginalPrice", "Rating", "StratCity", "Title", "TravlDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("6c15d8b3-1788-4db0-a13e-64b1a2c566c9"), new DateTime(2021, 4, 28, 14, 4, 9, 181, DateTimeKind.Local).AddTicks(8636), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 36.0, 0, "青天河", (byte)0, 3, null },
                    { new Guid("82f53116-dd3b-4ecd-8abc-df2c62ec9d66"), new DateTime(2021, 4, 27, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2734), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 12.0, 1, "云台山", (byte)1, 1, null },
                    { new Guid("dfb22b7c-4206-45e2-9590-7cc09ddec02c"), new DateTime(2021, 4, 26, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2911), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 69.0, null, "八里沟", (byte)2, null, null },
                    { new Guid("22640ece-9092-471e-ac60-e50adb80bd58"), new DateTime(2021, 4, 25, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2923), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 2.0, null, "万仙山", (byte)3, null, null },
                    { new Guid("3c0ed37e-6836-4ef3-ad82-7cc49121ea4e"), new DateTime(2021, 4, 24, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2927), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 91.0, null, "青天河", (byte)4, null, null },
                    { new Guid("64190267-b924-4a82-a711-88793a5d63e4"), new DateTime(2021, 4, 23, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2931), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 8.0, null, "云台山", (byte)5, null, null },
                    { new Guid("0bb13ad9-fce9-42fe-a4ea-4a580ad15543"), new DateTime(2021, 4, 22, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2933), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 88.0, 3, "八里沟", (byte)6, 2, null },
                    { new Guid("d3685074-5bac-421b-9232-001a35e0f3be"), new DateTime(2021, 4, 21, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2945), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 55.0, 3, "万仙山", (byte)7, 2, null },
                    { new Guid("e7aac598-86c7-411c-b028-92cf02e65708"), new DateTime(2021, 4, 20, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2949), null, "都是水", null, 0m, "吃喝玩乐", "住宿费自己掏", "注意安全", 1300m, 24.0, 3, "青天河", (byte)8, 2, null },
                    { new Guid("25ef0fbe-805c-4051-9cba-1303006c8184"), new DateTime(2021, 4, 19, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2951), null, "都是水111", null, 0m, "```吃喝玩乐", "555住宿费自己掏", "··注意安全", 1200m, 54.0, 3, "云台山", (byte)9, 2, null },
                    { new Guid("838d30e2-163b-440e-878a-e3aa6a1ea69f"), new DateTime(2021, 4, 18, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2955), null, "水比较多", null, 0m, "可以划船", "巴拉巴拉", "··注意安全。。", 120m, 97.0, 3, "八里沟", (byte)10, 2, null },
                    { new Guid("530a830f-dbf9-45c2-b8a2-a436bfeb2197"), new DateTime(2021, 4, 17, 14, 4, 9, 183, DateTimeKind.Local).AddTicks(2958), null, "山比较多", null, 0m, "路比较远", "玩玩赶紧回家", "··注意巴拉巴拉安全。。", 100m, 86.0, 3, "万仙山", (byte)11, 2, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "MyApplicationIdentityId" },
                values: new object[] { "bb28d4b9-bb87-4e9f-8157-8710337d21ab", "3faa1348-c9a0-49aa-912b-0d5007f806a7", null });

            migrationBuilder.InsertData(
                table: "TouristRoutPictures",
                columns: new[] { "ID", "Destription", "TouristRoutID", "Url" },
                values: new object[,]
                {
                    { -1, "太美丽了", new Guid("6c15d8b3-1788-4db0-a13e-64b1a2c566c9"), "../images/1.jpg" },
                    { -2, "太美丽了11111", new Guid("82f53116-dd3b-4ecd-8abc-df2c62ec9d66"), "../images/2.jpg" },
                    { -3, "<<<<<<太美丽了11", new Guid("dfb22b7c-4206-45e2-9590-7cc09ddec02c"), "../images/3.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_MyApplicationIdentityId",
                table: "AspNetUserClaims",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_MyApplicationIdentityId",
                table: "AspNetUserLogins",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_MyApplicationIdentityId",
                table: "AspNetUserRoles",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_MyApplicationIdentityId",
                table: "AspNetUserTokens",
                column: "MyApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItems_ShoppingCartId",
                table: "CartLineItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItems_TouristRoutID",
                table: "CartLineItems",
                column: "TouristRoutID");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItems_UserOrderId",
                table: "CartLineItems",
                column: "UserOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserID",
                table: "ShoppingCarts",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TouristRoutPictures_TouristRoutID",
                table: "TouristRoutPictures",
                column: "TouristRoutID");

            migrationBuilder.CreateIndex(
                name: "IX_userOrders_UserID",
                table: "userOrders",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartLineItems");

            migrationBuilder.DropTable(
                name: "TouristRoutPictures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "userOrders");

            migrationBuilder.DropTable(
                name: "TouristRout");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
