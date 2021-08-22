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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NavigationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentPageIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 4L, 2L, "string", 2L, "class", new Guid("6f973fd0-4656-481f-8c49-5a8e9f3fc9e7"), "btn" },
                    { 3L, 2L, "string", 1L, "text", new Guid("526c2da6-0630-4328-ab6a-9e85c7db6c92"), "Click" },
                    { 2L, 2L, "string", 0L, "type", new Guid("e4f3dc2d-b421-4485-b591-bbdabe6dbd73"), "button" },
                    { 1L, 1L, "int", 0L, "numberOfColumns", new Guid("adea54c7-0282-411b-87ce-022aa17e1f6f"), "1" }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockType", "CanHaveChildren", "DateCreated", "DateModified", "ParentId", "Title", "Uuid" },
                values: new object[,]
                {
                    { 1L, "columnContainer", true, new DateTime(2021, 8, 22, 4, 6, 11, 920, DateTimeKind.Local).AddTicks(8195), new DateTime(2021, 8, 22, 4, 6, 11, 920, DateTimeKind.Local).AddTicks(8746), 0L, "Columns", new Guid("a5334025-82f8-4322-a662-bcea5ab62155") },
                    { 23L, "image", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(847), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(851), 0L, "Image", new Guid("d28509e8-590e-47e2-abbd-7904913325e0") },
                    { 24L, "imageLink", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(860), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(864), 0L, "Image Link", new Guid("1c94af74-cd5f-44ce-8977-d13e866cf229") },
                    { 25L, "productGallery", true, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(869), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(873), 0L, "Product Listing", new Guid("f0c982fd-f81c-46cf-819f-d6e77979361a") },
                    { 26L, "product", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(878), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(882), 0L, "Product", new Guid("a3b6647a-96c8-47f6-88b7-e2e8f2cbe890") },
                    { 27L, "carousel", true, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(888), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(892), 0L, "Carousel", new Guid("2061db41-5a41-497a-93e9-10bffbee2baf") },
                    { 28L, "carouselItem", true, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(897), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(901), 0L, "Carousel Item", new Guid("b369c89e-d693-4ff4-8e05-b52c3c66f46f") },
                    { 30L, "registration", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(915), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(919), 0L, "Registration", new Guid("54c56227-6261-4c10-a155-e85f787e99d0") },
                    { 22L, "imageGallery", true, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(838), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(842), 0L, "Image Gallery", new Guid("439dca28-7e88-45c3-ad96-c713fe782413") },
                    { 31L, "shoppingBasket", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(924), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(928), 0L, "Shopping Basket", new Guid("85c66164-719a-4caf-8631-a431ae6101c8") },
                    { 32L, "checkout", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(937), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(941), 0L, "Checkout", new Guid("b76a9951-7b2e-4033-afd3-66d14c03d682") },
                    { 34L, "searchItem", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(955), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(959), 0L, "Search Item", new Guid("40abc6ec-89fe-47b9-b778-e87283eed082") },
                    { 35L, "card", true, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(965), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(968), 0L, "Card", new Guid("f5c5e200-ca81-4a83-96f6-13a2d7d21cc2") },
                    { 29L, "login", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(906), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(910), 0L, "Login", new Guid("c456e0df-808d-411b-8487-095f21809cf8") },
                    { 21L, "toggleSwitch", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(829), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(832), 0L, "Toggle Switch", new Guid("9dc6d17d-ab95-46f9-8095-c98fc0392a7a") },
                    { 33L, "search", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(946), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(950), 0L, "Search", new Guid("9e0783e4-32a8-4ac2-823f-82243d6bb7cb") },
                    { 19L, "textBox", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(810), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(814), 0L, "TextBox", new Guid("23a60039-2e0a-4c26-800b-39f5493c5dfa") },
                    { 20L, "timePicker", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(820), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(823), 0L, "Time Picker", new Guid("9f68e62d-2f71-45eb-a2e5-acb938f50189") },
                    { 2L, "button", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(608), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(630), 0L, "Button", new Guid("39530f11-ac8a-4896-8161-1e1fff4b4a11") },
                    { 4L, "checklist", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(647), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(652), 0L, "Checklist", new Guid("19494b2f-657e-4105-af09-2fb07b44c98c") },
                    { 5L, "dataListGroup", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(658), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(662), 0L, "Data List Group", new Guid("5e0cb0a1-3f78-405d-9b92-3a3f4d44aaca") },
                    { 6L, "datePicker", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(667), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(671), 0L, "Date Picker", new Guid("06cb0efa-75ed-4263-8cad-e98a609a3875") },
                    { 7L, "divider", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(676), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(680), 0L, "Divider", new Guid("64c7c960-6c1d-47ba-9c34-e5d885e64442") },
                    { 8L, "dropDown", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(702), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(706), 0L, "Drop-down", new Guid("14bfb1ce-3e88-4a6d-b417-82a667317ceb") },
                    { 9L, "editableTable", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(712), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(716), 0L, "Editable Table", new Guid("12dee6e5-d108-47d2-b668-4aa74e660221") },
                    { 3L, "checkbox", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(637), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(641), 0L, "Checkbox", new Guid("dd487984-13e3-489f-b20c-8cca82236970") },
                    { 11L, "heading", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(731), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(735), 0L, "heading", new Guid("19d12993-29b3-4d9e-adae-8cf11a3a59be") },
                    { 10L, "fileUpload", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(722), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(725), 0L, "File Upload", new Guid("dd74ffe4-3789-4e94-b87d-f245510ea2bb") },
                    { 17L, "table", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(791), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(795), 0L, "Table", new Guid("a41b634d-430c-4d92-8427-2a680cb25b6d") },
                    { 16L, "signature", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(782), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(786), 0L, "Signature", new Guid("3f9dfc63-080b-4ad6-9114-b02dea5f242a") },
                    { 15L, "radioGroup", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(768), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(772), 0L, "Radio Group", new Guid("fe713750-d1a2-402f-8592-9f821ce5b88a") },
                    { 18L, "textBlock", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(801), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(805), 0L, "Text Block", new Guid("7af6ae34-9538-48cc-9717-7eafd01ea76c") },
                    { 13L, "listGroup", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(750), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(754), 0L, "List Group", new Guid("c269ac9b-1011-4e1a-b6df-d0237cb9b64b") },
                    { 12L, "subHeading", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(740), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(744), 0L, "Sub-heading", new Guid("5670114d-bb15-4d53-9c00-20503239b917") },
                    { 14L, "multiLineTextbox", false, new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(759), new DateTime(2021, 8, 22, 4, 6, 11, 921, DateTimeKind.Local).AddTicks(763), 0L, "Multi-line Textbox", new Guid("dfd4b5a7-c45b-4316-be65-a3284dd5dab2") }
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
                values: new object[] { "ProductDetail", "{\"useBlocks\": true, \"title\": \"ProductDetail\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(6985) });

            migrationBuilder.InsertData(
                table: "PageTypes",
                columns: new[] { "Id", "Body", "DateCreated" },
                values: new object[,]
                {
                    { "ProductList", "{\"useBlocks\": true, \"title\": \"Product List\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(6979) },
                    { "StandardPage", "{\"useBlocks\": true, \"title\": \"Standard Page\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(6915) },
                    { "Root", "{\"useBlocks\": true, \"title\": \"Homepage\"}", new DateTime(2021, 8, 22, 4, 6, 11, 916, DateTimeKind.Local).AddTicks(487) },
                    { "ArticleList", "{\"useBlocks\": true, \"title\": \"Article List\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7001) },
                    { "ArticleDetail", "{\"useBlocks\": true, \"title\": \"Article Detail\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7005) },
                    { "Error", "{\"useBlocks\": true, \"title\": \"Error\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7014) },
                    { "Search", "{\"useBlocks\": true, \"title\": \"Search\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7019) },
                    { "SearchResults", "{\"useBlocks\": true, \"title\": \"Search Results\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7023) },
                    { "Member", "{\"useBlocks\": true, \"title\": \"Member\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7027) },
                    { "Transaction", "{\"useBlocks\": true, \"title\": \"Transaction\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7031) },
                    { "EventList", "{\"useBlocks\": true, \"title\": \"Event List\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(6991) },
                    { "FeatureLanding", "{\"useBlocks\": true, \"title\": \"Feature Landing\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(7009) },
                    { "EventDetail", "{\"useBlocks\": true, \"title\": \"Event Detail\"}", new DateTime(2021, 8, 22, 4, 6, 11, 918, DateTimeKind.Local).AddTicks(6996) }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Binned", "DateCreated", "DateModified", "DateScheduledExpiry", "DateScheduledPublish", "Disabled", "Draft", "Level", "MetaDescription", "MetaKeywords", "NavigationTitle", "PageIdentifier", "PageTypeId", "ParentPageIdentifier", "Published", "Route", "SiteId", "SortOrder", "Title" },
                values: new object[,]
                {
                    { 4L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2216), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2219), null, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2221), false, false, 1, "", "", "About", "d6f73c6b-da4f-475f-931a-0f8f3aa15c58", "StandardPage", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/about", 1L, 0L, "About" },
                    { 7L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2245), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2247), new DateTime(2021, 8, 21, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2253), new DateTime(2021, 8, 20, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2250), false, false, 0, "", "", "Home", "90686b10-a30a-4d7d-b942-fc752494af83", "Root", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/", 1L, 0L, "Home" },
                    { 6L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2235), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2237), null, new DateTime(2021, 8, 19, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2240), false, false, 0, "", "", "Home", "90686b10-a30a-4d7d-b942-fc752494af83", "Root", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/", 1L, 0L, "Home" },
                    { 5L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2225), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2228), null, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2230), false, false, 1, "", "", "Contact", "053ddd1a-6bd1-4ac0-b3a8-406e55232639", "StandardPage", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/contact", 1L, 2L, "Contact" },
                    { 3L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2206), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2209), null, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2211), false, false, 2, "", "", "Regulatory Services", "ca6e865f-ecaf-420b-91b7-ba54eebc8588", "StandardPage", "b178a0db-2358-41be-9dbe-350c41e459c8", true, "/portfolio/regulatory-services", 1L, 0L, "Regulatory Services" },
                    { 2L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2180), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2197), null, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2200), false, false, 1, "", "", "Portfolio", "b178a0db-2358-41be-9dbe-350c41e459c8", "StandardPage", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/portfolio", 1L, 1L, "Portfolio" },
                    { 1L, false, new DateTime(2021, 8, 22, 4, 6, 11, 926, DateTimeKind.Local).AddTicks(7111), new DateTime(2021, 8, 22, 4, 6, 11, 926, DateTimeKind.Local).AddTicks(7457), null, new DateTime(2021, 8, 18, 4, 6, 11, 926, DateTimeKind.Local).AddTicks(7785), false, false, 0, "", "", "Home", "90686b10-a30a-4d7d-b942-fc752494af83", "Root", "90686b10-a30a-4d7d-b942-fc752494af83", true, "/", 1L, 0L, "Home" },
                    { 8L, false, new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2257), new DateTime(2021, 8, 22, 4, 6, 11, 927, DateTimeKind.Local).AddTicks(2260), null, null, false, true, 0, "", "", "Home", "90686b10-a30a-4d7d-b942-fc752494af83", "Root", "90686b10-a30a-4d7d-b942-fc752494af83", false, "/", 1L, 0L, "Home" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Culture", "DomainName", "Protocol", "Uuid" },
                values: new object[] { 1L, "en-GB", "superjack.co.uk", "https", new Guid("6d624486-5520-4226-9e85-04fc15e24eed") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "FirstName", "PasswordHash", "PasswordSalt", "Status", "Surname", "Username" },
                values: new object[] { 1L, new DateTime(2021, 8, 22, 4, 6, 11, 926, DateTimeKind.Local).AddTicks(4039), "Stef", new byte[] { 189, 173, 141, 28, 75, 18, 55, 88, 229, 171, 17, 162, 138, 22, 14, 245, 131, 187, 255, 190, 208, 79, 137, 49, 241, 107, 48, 252, 207, 226, 205, 74, 54, 250, 45, 7, 134, 212, 205, 134, 31, 164, 130, 58, 15, 85, 46, 146, 175, 250, 142, 93, 116, 66, 125, 8, 49, 182, 227, 49, 143, 19, 180, 121 }, new byte[] { 188, 253, 4, 102, 241, 168, 56, 143, 82, 248, 19, 187, 208, 126, 135, 221, 63, 216, 184, 87, 179, 89, 158, 146, 253, 185, 224, 171, 217, 247, 145, 195, 115, 140, 59, 118, 235, 245, 88, 194, 35, 37, 246, 200, 21, 81, 123, 62, 7, 163, 246, 172, 250, 248, 211, 139, 3, 90, 179, 233, 9, 10, 125, 80, 167, 5, 254, 28, 99, 6, 118, 174, 37, 53, 182, 3, 197, 208, 121, 224, 115, 45, 228, 208, 145, 94, 243, 170, 234, 5, 87, 49, 243, 158, 159, 69, 97, 55, 58, 160, 37, 246, 228, 208, 133, 255, 213, 173, 3, 125, 105, 69, 83, 20, 37, 54, 198, 22, 48, 157, 241, 26, 134, 125, 118, 101, 147, 205 }, "Active", "Cunning", "services@superjack.co.uk" });
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
