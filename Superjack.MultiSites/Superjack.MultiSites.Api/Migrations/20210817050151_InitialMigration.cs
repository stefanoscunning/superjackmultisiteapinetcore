using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjack.MultiSites.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    BlockType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanHaveChildren = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageBlocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<long>(type: "bigint", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageBlockId = table.Column<long>(type: "bigint", nullable: false),
                    FieldId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigationTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentPageIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DateScheduledPublish = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateScheduledExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Draft = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Binned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Protocol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DomainName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlockFields",
                columns: new[] { "Id", "BlockId", "DataType", "SortOrder", "Title", "Uuid", "Value" },
                values: new object[,]
                {
                    { 4L, 2L, "string", 2L, "class", new Guid("a173a2fb-f817-4c6c-82f8-72f8e2b2dcb4"), "btn" },
                    { 3L, 2L, "string", 1L, "text", new Guid("15fcb375-aceb-46bb-95f1-2d7642f067c3"), "Click" },
                    { 2L, 2L, "string", 0L, "type", new Guid("d758bcb3-e67f-4332-bffb-f5c6112842bd"), "button" },
                    { 1L, 1L, "int", 0L, "numberOfColumns", new Guid("674813a9-25e1-455b-9d9f-a48891689f56"), "1" }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockType", "CanHaveChildren", "DateCreated", "DateModified", "ParentId", "Title", "Uuid" },
                values: new object[,]
                {
                    { 1L, "columnContainer", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(2648), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(3032), 0L, "Columns", new Guid("a34e1081-f366-47e6-bc82-c36ccb75bf4e") },
                    { 23L, "image", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4448), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4451), 0L, "Image", new Guid("c9b04e1d-2cd9-4fb5-a86a-f1a9cf8228c4") },
                    { 24L, "imageLink", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4455), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4458), 0L, "Image Link", new Guid("d67e7198-082d-4066-90ad-6602e39e26b0") },
                    { 25L, "productGallery", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4462), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4464), 0L, "Product Listing", new Guid("4e05ee00-d8c2-48ed-af1e-b1cc70f3e25f") },
                    { 26L, "product", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4468), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4471), 0L, "Product", new Guid("e8289a0e-c50d-425a-8cc0-0f7ed5d0f5f6") },
                    { 27L, "carousel", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4475), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4477), 0L, "Carousel", new Guid("05279ecc-9a0b-402b-95f4-87ae29a88a2d") },
                    { 28L, "carouselItem", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4481), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4484), 0L, "Carousel Item", new Guid("e9e28982-0145-4afc-9418-003df62c252d") },
                    { 30L, "registration", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4497), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4499), 0L, "Registration", new Guid("a8247b1c-7b2f-492a-bef7-cb6fc01f13b5") },
                    { 22L, "imageGallery", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4442), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4444), 0L, "Image Gallery", new Guid("6571dd6c-eff9-40c4-a8aa-fdace8cb0588") },
                    { 31L, "shoppingBasket", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4503), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4506), 0L, "Shopping Basket", new Guid("99782897-9985-4f23-9c40-9f9abd8b920f") },
                    { 32L, "checkout", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4510), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4513), 0L, "Checkout", new Guid("f7d331ca-6081-494d-b463-08fbe396ffcd") },
                    { 34L, "searchItem", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4523), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4526), 0L, "Search Item", new Guid("c96987cf-7d6a-4a6e-bc6f-13bc3038858c") },
                    { 35L, "card", true, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4530), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4532), 0L, "Card", new Guid("b1719a5e-96b0-4484-92a0-a44014862de4") },
                    { 29L, "login", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4490), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4493), 0L, "Login", new Guid("a7a85383-8438-4730-9e4f-6870c9eeebb3") },
                    { 21L, "toggleSwitch", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4435), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4438), 0L, "Toggle Switch", new Guid("cc10da55-2cdd-4fa9-bda6-eeb2f3b65eeb") },
                    { 33L, "search", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4516), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4519), 0L, "Search", new Guid("f48328c4-8676-42af-a343-08ea2a20c15b") },
                    { 19L, "textBox", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4419), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4421), 0L, "TextBox", new Guid("5921d796-32fa-496e-ab40-3c0fb381b339") },
                    { 20L, "timePicker", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4425), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4428), 0L, "Time Picker", new Guid("c5578a5f-8639-4d29-a80b-9efcb617115e") },
                    { 2L, "button", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4274), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4289), 0L, "Button", new Guid("79d5e8db-1a56-476a-a4d8-c1a092a9e203") },
                    { 4L, "checklist", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4300), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4303), 0L, "Checklist", new Guid("4e0da359-e8dc-41ad-879f-2290a83a8adb") },
                    { 5L, "dataListGroup", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4320), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4322), 0L, "Data List Group", new Guid("6ba04336-662d-4d79-b5dc-d8aedb021a85") },
                    { 6L, "datePicker", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4327), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4329), 0L, "Date Picker", new Guid("f58ffd9d-e287-49fa-b7b3-0bc24e77196d") },
                    { 7L, "divider", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4333), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4336), 0L, "Divider", new Guid("25c1244a-dd67-4611-aa96-31c5b490bdc4") },
                    { 8L, "dropDown", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4340), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4343), 0L, "Drop-down", new Guid("76f34739-4eb0-4c7c-b7a2-69e8471ae9f3") },
                    { 9L, "editableTable", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4347), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4349), 0L, "Editable Table", new Guid("55d8109c-568d-44b3-8f2a-52fb18c915ca") },
                    { 3L, "checkbox", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4294), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4297), 0L, "Checkbox", new Guid("9d5a2498-d7a2-4908-ae72-7a022f1970f4") },
                    { 11L, "heading", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4363), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4366), 0L, "heading", new Guid("408df0c0-8eed-4584-9497-fd1151d8d898") },
                    { 10L, "fileUpload", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4353), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4356), 0L, "File Upload", new Guid("689bbf97-a547-402b-9378-f3d8b6d3f780") },
                    { 17L, "table", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4406), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4409), 0L, "Table", new Guid("2cf0f106-a6a1-4c65-b0da-59c428d09244") },
                    { 16L, "signature", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4399), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4402), 0L, "Signature", new Guid("d3a2900b-9f9d-4094-9756-b37e74421c77") },
                    { 15L, "radioGroup", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4393), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4395), 0L, "Radio Group", new Guid("a78921dc-c657-450b-9552-96dd7fa93198") },
                    { 18L, "textBlock", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4412), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4415), 0L, "Text Block", new Guid("1e1372a6-8721-4744-a0bd-ab12db04a97f") },
                    { 13L, "listGroup", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4379), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4382), 0L, "List Group", new Guid("cb6290be-aea6-4748-89e1-343a80b68303") },
                    { 12L, "subHeading", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4369), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4372), 0L, "Sub-heading", new Guid("67856401-6a6c-4935-be7a-a105a6bb265b") },
                    { 14L, "multiLineTextbox", false, new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4386), new DateTime(2021, 8, 17, 6, 1, 50, 696, DateTimeKind.Local).AddTicks(4388), 0L, "Multi-line Textbox", new Guid("62dab29b-a81f-4c82-b545-f699565f99f4") }
                });

            migrationBuilder.InsertData(
                table: "PageBlocks",
                columns: new[] { "Id", "BlockId", "PageId", "ParentId", "SortOrder" },
                values: new object[] { 1L, 1L, 1L, 0L, 0L });

            migrationBuilder.InsertData(
                table: "PageFields",
                columns: new[] { "Id", "DataType", "FieldId", "PageBlockId", "SortOrder", "Title", "Value" },
                values: new object[] { 1L, "int", 1L, 1L, 0L, "Number of Columns", "3" });

            migrationBuilder.InsertData(
                table: "PageTypes",
                columns: new[] { "Id", "Body", "DateCreated" },
                values: new object[] { "ProductDetail", "{\"useBlocks\": true, \"title\": \"ProductDetail\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7414) });

            migrationBuilder.InsertData(
                table: "PageTypes",
                columns: new[] { "Id", "Body", "DateCreated" },
                values: new object[,]
                {
                    { "ProductList", "{\"useBlocks\": true, \"title\": \"Product List\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7409) },
                    { "StandardPage", "{\"useBlocks\": true, \"title\": \"Standard Page\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7368) },
                    { "Root", "{\"useBlocks\": true, \"title\": \"Homepage\"}", new DateTime(2021, 8, 17, 6, 1, 50, 692, DateTimeKind.Local).AddTicks(2767) },
                    { "ArticleList", "{\"useBlocks\": true, \"title\": \"Article List\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7424) },
                    { "ArticleDetail", "{\"useBlocks\": true, \"title\": \"Article Detail\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7427) },
                    { "Error", "{\"useBlocks\": true, \"title\": \"Error\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7433) },
                    { "Search", "{\"useBlocks\": true, \"title\": \"Search\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7436) },
                    { "SearchResults", "{\"useBlocks\": true, \"title\": \"Search Results\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7438) },
                    { "Member", "{\"useBlocks\": true, \"title\": \"Member\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7441) },
                    { "Transaction", "{\"useBlocks\": true, \"title\": \"Transaction\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7444) },
                    { "EventList", "{\"useBlocks\": true, \"title\": \"Event List\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7418) },
                    { "FeatureLanding", "{\"useBlocks\": true, \"title\": \"Feature Landing\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7430) },
                    { "EventDetail", "{\"useBlocks\": true, \"title\": \"Event Detail\"}", new DateTime(2021, 8, 17, 6, 1, 50, 694, DateTimeKind.Local).AddTicks(7421) }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Binned", "DateCreated", "DateModified", "DateScheduledExpiry", "DateScheduledPublish", "Disabled", "Draft", "Level", "MetaDescription", "MetaKeywords", "NavigationTitle", "PageIdentifier", "PageTypeId", "ParentPageIdentifier", "Published", "Route", "SiteId", "SortOrder", "Title" },
                values: new object[,]
                {
                    { 4L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4270), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4272), null, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4275), false, false, 1, null, null, "About", "1140bd07-b78e-4181-90d2-7a15867e902c", "StandardPage", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", true, "/about", 1L, 0L, "About" },
                    { 7L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4298), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4301), new DateTime(2021, 8, 16, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4306), new DateTime(2021, 8, 15, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4304), false, false, 0, null, null, "Home", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 6L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4289), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4291), null, new DateTime(2021, 8, 14, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4294), false, false, 0, null, null, "Home", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 5L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4279), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4282), null, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4284), false, false, 1, null, null, "Contact", "e1a0b1e8-53f4-46e9-a986-b5a912ced43a", "StandardPage", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", true, "/contact", 1L, 2L, "Contact" },
                    { 3L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4260), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4263), null, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4265), false, false, 2, null, null, "Regulatory Services", "da5c2b0d-5617-407d-a04b-045c945b89ca", "StandardPage", "8b2c6ae6-40a4-4920-9b09-14bf27c9de14", true, "/portfolio/regulatory-services", 1L, 0L, "Regulatory Services" },
                    { 2L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4235), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4251), null, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4254), false, false, 1, null, null, "Portfolio", "8b2c6ae6-40a4-4920-9b09-14bf27c9de14", "StandardPage", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", true, "/portfolio", 1L, 1L, "Portfolio" },
                    { 1L, false, new DateTime(2021, 8, 17, 6, 1, 50, 700, DateTimeKind.Local).AddTicks(9239), new DateTime(2021, 8, 17, 6, 1, 50, 700, DateTimeKind.Local).AddTicks(9585), null, new DateTime(2021, 8, 13, 6, 1, 50, 700, DateTimeKind.Local).AddTicks(9914), false, false, 0, null, null, "Home", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 8L, false, new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4311), new DateTime(2021, 8, 17, 6, 1, 50, 701, DateTimeKind.Local).AddTicks(4313), null, null, false, true, 0, null, null, "Home", "2aaf5367-5bb6-4c9b-aa6f-37ee7c8e5389", "Root", null, false, "/", 1L, 0L, "Home" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Culture", "DomainName", "Protocol", "Uuid" },
                values: new object[] { 1L, "en-GB", "superjack.co.uk", "https", new Guid("b42a2198-1393-46bf-8d82-70f5eeecfa9a") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "FirstName", "PasswordHash", "PasswordSalt", "Status", "Surname", "Username" },
                values: new object[] { 1L, new DateTime(2021, 8, 17, 6, 1, 50, 700, DateTimeKind.Local).AddTicks(6593), "Stef", new byte[] { 233, 65, 27, 88, 163, 0, 41, 251, 167, 190, 175, 230, 184, 147, 213, 249, 124, 29, 218, 14, 233, 159, 11, 52, 133, 180, 6, 92, 137, 127, 161, 97, 27, 22, 23, 8, 131, 41, 233, 165, 156, 95, 115, 50, 65, 17, 105, 230, 160, 185, 170, 230, 195, 28, 226, 176, 122, 14, 181, 141, 71, 251, 250, 99 }, new byte[] { 212, 97, 134, 241, 158, 201, 186, 65, 150, 116, 171, 70, 228, 27, 183, 80, 230, 38, 166, 250, 3, 145, 91, 28, 102, 203, 53, 45, 50, 198, 136, 132, 248, 18, 210, 36, 87, 49, 181, 255, 121, 83, 167, 123, 216, 254, 135, 241, 113, 27, 99, 44, 252, 167, 40, 113, 93, 245, 38, 18, 109, 133, 199, 63, 104, 165, 174, 248, 158, 14, 59, 61, 96, 212, 28, 224, 230, 45, 239, 118, 189, 195, 8, 52, 128, 13, 252, 25, 65, 149, 81, 26, 41, 165, 242, 65, 31, 2, 76, 243, 110, 208, 159, 191, 239, 155, 32, 129, 183, 69, 40, 3, 171, 8, 49, 38, 58, 109, 208, 40, 176, 0, 148, 13, 144, 138, 61, 116 }, "Active", "Cunning", "services@superjack.co.uk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockFields");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "PageBlocks");

            migrationBuilder.DropTable(
                name: "PageFields");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PageTypes");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
