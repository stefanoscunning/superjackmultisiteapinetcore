using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Superjack.MultiSites.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                columns: new[] { "Id", "BlockId", "DataType", "SortOrder", "Title", "Value" },
                values: new object[] { 1L, 1L, "int", 0L, "Number of Columns", "1" });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockType", "CanHaveChildren", "DateCreated", "DateModified", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1L, "columnContainer", true, new DateTime(2021, 3, 29, 22, 18, 58, 913, DateTimeKind.Local).AddTicks(7682), new DateTime(2021, 3, 29, 22, 18, 58, 913, DateTimeKind.Local).AddTicks(9469), 0L, "Columns" },
                    { 21L, "toggleSwitch", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5886), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5894), 0L, "Toggle Switch" },
                    { 22L, "imageGallery", true, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5902), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5910), 0L, "Image Gallery" },
                    { 23L, "image", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5919), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5926), 0L, "Image" },
                    { 24L, "imageLink", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5936), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5944), 0L, "Image Link" },
                    { 25L, "productGallery", true, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5953), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5961), 0L, "Product Listing" },
                    { 26L, "product", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5969), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5977), 0L, "Product" },
                    { 27L, "carousel", true, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5986), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5994), 0L, "Carousel" },
                    { 28L, "carouselItem", true, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6002), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6010), 0L, "Carousel Item" },
                    { 29L, "login", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6019), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6027), 0L, "Login" },
                    { 30L, "registration", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6035), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6043), 0L, "Registration" },
                    { 32L, "checkout", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6069), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6077), 0L, "Checkout" },
                    { 33L, "search", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6086), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6094), 0L, "Search" },
                    { 34L, "searchItem", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6104), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6112), 0L, "Search Item" },
                    { 35L, "card", true, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6120), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6128), 0L, "Card" },
                    { 20L, "timePicker", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5869), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5877), 0L, "Time Picker" },
                    { 19L, "textBox", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5852), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5860), 0L, "TextBox" },
                    { 31L, "shoppingBasket", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6052), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(6060), 0L, "Shopping Basket" },
                    { 17L, "table", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5819), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5826), 0L, "Table" },
                    { 18L, "textBlock", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5835), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5843), 0L, "Text Block" },
                    { 3L, "checkbox", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5511), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5519), 0L, "Checkbox" },
                    { 4L, "checklist", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5528), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5536), 0L, "Checklist" },
                    { 5L, "dataListGroup", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5545), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5553), 0L, "Data List Group" },
                    { 6L, "datePicker", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5563), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5571), 0L, "Date Picker" },
                    { 7L, "divider", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5580), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5588), 0L, "Divider" },
                    { 8L, "dropDown", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5597), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5605), 0L, "Drop-down" },
                    { 2L, "button", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5429), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5498), 0L, "Button" },
                    { 10L, "fileUpload", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5631), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5639), 0L, "File Upload" },
                    { 11L, "heading", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5648), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5655), 0L, "heading" },
                    { 12L, "subHeading", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5664), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5672), 0L, "Sub-heading" },
                    { 13L, "listGroup", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5681), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5689), 0L, "List Group" },
                    { 14L, "multiLineTextbox", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5697), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5706), 0L, "Multi-line Textbox" },
                    { 15L, "radioGroup", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5715), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5723), 0L, "Radio Group" },
                    { 9L, "editableTable", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5615), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5622), 0L, "Editable Table" },
                    { 16L, "signature", false, new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5799), new DateTime(2021, 3, 29, 22, 18, 58, 914, DateTimeKind.Local).AddTicks(5810), 0L, "Signature" }
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
                values: new object[,]
                {
                    { "ProductDetail", "{\"useBlocks\": true, \"title\": \"ProductDetail\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(984) },
                    { "ProductList", "{\"useBlocks\": true, \"title\": \"Product List\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(970) },
                    { "StandardPage", "{\"useBlocks\": true, \"title\": \"Standard Page\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(821) },
                    { "Root", "{\"useBlocks\": true, \"title\": \"Homepage\"}", new DateTime(2021, 3, 29, 22, 18, 58, 892, DateTimeKind.Local).AddTicks(2821) }
                });

            migrationBuilder.InsertData(
                table: "PageTypes",
                columns: new[] { "Id", "Body", "DateCreated" },
                values: new object[,]
                {
                    { "ArticleList", "{\"useBlocks\": true, \"title\": \"Article List\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1010) },
                    { "Error", "{\"useBlocks\": true, \"title\": \"Error\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1038) },
                    { "FeatureLanding", "{\"useBlocks\": true, \"title\": \"Feature Landing\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1027) },
                    { "Search", "{\"useBlocks\": true, \"title\": \"Search\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1047) },
                    { "SearchResults", "{\"useBlocks\": true, \"title\": \"Search Results\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1057) },
                    { "Member", "{\"useBlocks\": true, \"title\": \"Member\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1066) },
                    { "EventList", "{\"useBlocks\": true, \"title\": \"Event List\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(993) },
                    { "Transaction", "{\"useBlocks\": true, \"title\": \"Transaction\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1075) },
                    { "ArticleDetail", "{\"useBlocks\": true, \"title\": \"Article Detail\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1019) },
                    { "EventDetail", "{\"useBlocks\": true, \"title\": \"Event Detail\"}", new DateTime(2021, 3, 29, 22, 18, 58, 905, DateTimeKind.Local).AddTicks(1001) }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Binned", "DateCreated", "DateModified", "DateScheduledExpiry", "DateScheduledPublish", "Disabled", "Draft", "Level", "MetaDescription", "MetaKeywords", "NavigationTitle", "PageIdentifier", "PageTypeId", "ParentPageIdentifier", "Published", "Route", "SiteId", "SortOrder", "Title" },
                values: new object[,]
                {
                    { 5L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8536), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8544), null, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8552), false, false, 1, null, null, "Contact", "9455e0e8-cbde-40c2-923a-f32bd0cec2b1", "StandardPage", "f8baa4da-57dc-4e55-a091-bc975ba824e7", true, "/contact", 1L, 2L, "Contact" },
                    { 7L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8599), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8607), new DateTime(2021, 3, 28, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8623), new DateTime(2021, 3, 27, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8615), false, false, 0, null, null, "Home", "f8baa4da-57dc-4e55-a091-bc975ba824e7", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 6L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8563), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8571), null, new DateTime(2021, 3, 26, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8579), false, false, 0, null, null, "Home", "f8baa4da-57dc-4e55-a091-bc975ba824e7", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 4L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8507), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8516), null, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8524), false, false, 1, null, null, "About", "528af808-61b1-48bc-b9d7-560f2d0718a8", "StandardPage", "f8baa4da-57dc-4e55-a091-bc975ba824e7", true, "/about", 1L, 0L, "About" },
                    { 3L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8477), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8487), null, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8495), false, false, 2, null, null, "Regulatory Services", "9068031f-cf82-44b8-bf21-8216b6923311", "StandardPage", "4e9ee63a-fe9e-4be9-b8d7-0529969450cf", true, "/portfolio/regulatory-services", 1L, 0L, "Regulatory Services" },
                    { 2L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8322), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8447), null, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8457), false, false, 1, null, null, "Portfolio", "4e9ee63a-fe9e-4be9-b8d7-0529969450cf", "StandardPage", "f8baa4da-57dc-4e55-a091-bc975ba824e7", true, "/portfolio", 1L, 1L, "Portfolio" },
                    { 1L, false, new DateTime(2021, 3, 29, 22, 18, 58, 937, DateTimeKind.Local).AddTicks(8742), new DateTime(2021, 3, 29, 22, 18, 58, 938, DateTimeKind.Local).AddTicks(2097), null, new DateTime(2021, 3, 25, 22, 18, 58, 938, DateTimeKind.Local).AddTicks(4527), false, false, 0, null, null, "Home", "f8baa4da-57dc-4e55-a091-bc975ba824e7", "Root", null, true, "/", 1L, 0L, "Home" },
                    { 8L, false, new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8635), new DateTime(2021, 3, 29, 22, 18, 58, 940, DateTimeKind.Local).AddTicks(8643), null, null, false, true, 0, null, null, "Home", "f8baa4da-57dc-4e55-a091-bc975ba824e7", "Root", null, false, "/", 1L, 0L, "Home" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Culture", "DomainName", "Protocol" },
                values: new object[] { 1L, "en-GB", "superjack.co.uk", "https" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "FirstName", "PasswordHash", "PasswordSalt", "Status", "Surname", "Username" },
                values: new object[] { 1L, new DateTime(2021, 3, 29, 22, 18, 58, 933, DateTimeKind.Local).AddTicks(7317), "Stef", new byte[] { 128, 195, 86, 129, 189, 56, 47, 228, 124, 241, 46, 224, 203, 197, 183, 132, 109, 54, 96, 125, 213, 209, 92, 110, 29, 99, 223, 46, 162, 106, 98, 171, 94, 9, 166, 250, 127, 103, 241, 97, 196, 247, 21, 229, 234, 61, 72, 170, 184, 21, 41, 237, 216, 30, 42, 48, 177, 154, 92, 106, 155, 185, 132, 130 }, new byte[] { 145, 179, 67, 188, 159, 39, 127, 16, 36, 239, 10, 96, 145, 244, 241, 147, 166, 194, 110, 140, 221, 223, 149, 217, 248, 55, 35, 91, 219, 212, 203, 243, 253, 55, 235, 22, 150, 224, 167, 194, 179, 226, 22, 220, 44, 13, 177, 145, 6, 56, 239, 130, 34, 112, 121, 134, 129, 234, 144, 23, 23, 76, 50, 143, 52, 233, 206, 147, 132, 111, 1, 88, 176, 177, 72, 216, 164, 12, 125, 242, 129, 150, 177, 166, 13, 90, 2, 15, 201, 228, 24, 134, 237, 20, 103, 231, 227, 9, 131, 131, 127, 48, 213, 167, 166, 222, 34, 171, 40, 82, 68, 52, 48, 123, 88, 252, 113, 178, 118, 243, 140, 233, 220, 110, 184, 193, 24, 186 }, "Active", "Cunning", "services@superjack.co.uk" });
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
