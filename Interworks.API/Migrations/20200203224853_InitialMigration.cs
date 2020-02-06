using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Interworks.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    shippingCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    expiresAt = table.Column<DateTimeOffset>(nullable: true),
                    startsAt = table.Column<DateTimeOffset>(nullable: true),
                    isFixed = table.Column<bool>(nullable: false),
                    priority = table.Column<int>(nullable: false),
                    thresholdAmount = table.Column<decimal>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    isAutomaticallyApplied = table.Column<bool>(nullable: false),
                    maxUses = table.Column<int>(nullable: true),
                    maxUsesPerUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "templates",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    key = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_templates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    isSubscription = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    monthsCycle = table.Column<int>(nullable: false),
                    monthsActive = table.Column<int>(nullable: false),
                    categoryId = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    deletedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    token = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    countryId = table.Column<Guid>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    address_line = table.Column<string>(nullable: true),
                    zip_code = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_countries_countryId",
                        column: x => x.countryId,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "fields",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<int>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    pageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fields", x => x.id);
                    table.ForeignKey(
                        name: "FK_fields_pages_pageId",
                        column: x => x.pageId,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productDiscounts",
                columns: table => new
                {
                    productId = table.Column<Guid>(nullable: false),
                    discountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDiscounts", x => new { x.productId, x.discountId });
                    table.ForeignKey(
                        name: "FK_productDiscounts_discounts_discountId",
                        column: x => x.discountId,
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productDiscounts_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    startsAt = table.Column<DateTimeOffset>(nullable: false),
                    endsAt = table.Column<DateTimeOffset>(nullable: false),
                    monthsCycle = table.Column<int>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    validityDays = table.Column<int>(nullable: false),
                    validityMonths = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false),
                    productId = table.Column<Guid>(nullable: false),
                    Productid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_products_Productid",
                        column: x => x.Productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usedDiscounts",
                columns: table => new
                {
                    userId = table.Column<Guid>(nullable: false),
                    discountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usedDiscounts", x => new { x.userId, x.discountId });
                    table.ForeignKey(
                        name: "FK_usedDiscounts_discounts_discountId",
                        column: x => x.discountId,
                        principalTable: "discounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usedDiscounts_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fieldOptions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    fieldId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldOptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_fieldOptions_fields_fieldId",
                        column: x => x.fieldId,
                        principalTable: "fields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "datum",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createdAt = table.Column<DateTimeOffset>(nullable: false),
                    updatedAt = table.Column<DateTimeOffset>(nullable: true),
                    textbox = table.Column<string>(nullable: true),
                    fieldOptionId = table.Column<Guid>(nullable: true),
                    fieldOptionid = table.Column<Guid>(nullable: true),
                    imagePath = table.Column<string>(nullable: true),
                    userId = table.Column<Guid>(nullable: false),
                    fieldId = table.Column<Guid>(nullable: false),
                    deletedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datum", x => x.id);
                    table.ForeignKey(
                        name: "FK_datum_fields_fieldId",
                        column: x => x.fieldId,
                        principalTable: "fields",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_datum_fieldOptions_fieldOptionId",
                        column: x => x.fieldOptionId,
                        principalTable: "fieldOptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_datum_fieldOptions_fieldOptionid",
                        column: x => x.fieldOptionid,
                        principalTable: "fieldOptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_datum_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "createdAt", "name", "updatedAt" },
                values: new object[] { new Guid("df17ae7f-6898-4358-9328-75d1df8ac9cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Product Name", null });

            migrationBuilder.InsertData(
                table: "discounts",
                columns: new[] { "id", "amount", "code", "createdAt", "description", "expiresAt", "isAutomaticallyApplied", "isFixed", "maxUses", "maxUsesPerUser", "name", "priority", "startsAt", "thresholdAmount", "updatedAt" },
                values: new object[] { new Guid("54fbef96-0535-4ad0-bd85-421c2a4fc793"), 50m, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "this is a sample discount", new DateTimeOffset(new DateTime(2008, 5, 1, 8, 6, 32, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), true, true, null, null, null, 1, null, null, null });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "address_line", "city", "countryId", "createdAt", "firstName", "lastName", "password", "phone", "token", "type", "updatedAt", "username", "zip_code" },
                values: new object[] { new Guid("cc680d14-76ea-479c-8041-15b2073d45ac"), null, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "test", null, null, 0, null, "test", null });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "categoryId", "createdAt", "deletedAt", "description", "isSubscription", "monthsActive", "monthsCycle", "name", "price", "updatedAt" },
                values: new object[] { new Guid("8608cbbf-9c7e-4a7c-86bf-30cde97ed266"), new Guid("df17ae7f-6898-4358-9328-75d1df8ac9cb"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "This is a sample subscription product", false, 24, 6, "Product Name", 340m, null });

            migrationBuilder.CreateIndex(
                name: "IX_countries_code",
                table: "countries",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_datum_fieldId",
                table: "datum",
                column: "fieldId");

            migrationBuilder.CreateIndex(
                name: "IX_datum_fieldOptionId",
                table: "datum",
                column: "fieldOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_datum_fieldOptionid",
                table: "datum",
                column: "fieldOptionid");

            migrationBuilder.CreateIndex(
                name: "IX_datum_userId",
                table: "datum",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_fieldOptions_fieldId",
                table: "fieldOptions",
                column: "fieldId");

            migrationBuilder.CreateIndex(
                name: "IX_fields_pageId",
                table: "fields",
                column: "pageId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Productid",
                table: "orders",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_orders_productId",
                table: "orders",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_userId",
                table: "orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_productDiscounts_discountId",
                table: "productDiscounts",
                column: "discountId");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_usedDiscounts_discountId",
                table: "usedDiscounts",
                column: "discountId");

            migrationBuilder.CreateIndex(
                name: "IX_users_countryId",
                table: "users",
                column: "countryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "datum");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "productDiscounts");

            migrationBuilder.DropTable(
                name: "templates");

            migrationBuilder.DropTable(
                name: "usedDiscounts");

            migrationBuilder.DropTable(
                name: "fieldOptions");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "fields");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "pages");
        }
    }
}
