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
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<long>(type: "bigint", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    SortOrder = table.Column<long>(type: "bigint", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
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
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageBlockId = table.Column<long>(type: "bigint", nullable: false),
                    FieldId = table.Column<long>(type: "bigint", nullable: true),
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
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    { 3L, 2L, "string", 2L, "class", new Guid("a62ab556-5d7f-42eb-8891-3077015c7834"), "btn" },
                    { 2L, 2L, "string", 1L, "text", new Guid("4a5f2ecf-b460-4c29-8723-16b653fb113e"), "Click" },
                    { 1L, 2L, "string", 0L, "type", new Guid("eb273b0f-0be0-492d-8fe8-7d70a3b2481f"), "button" }
                });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Id", "BlockType", "CanHaveChildren", "DateCreated", "DateModified", "ParentId", "Title", "Uuid" },
                values: new object[,]
                {
                    { 1L, "columnContainer", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(7460), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(7838), 0L, "Columns", new Guid("7906aff9-9fdd-4d61-b247-36638d4e6778") },
                    { 23L, "image", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9176), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9179), 0L, "Image", new Guid("ce5d1a3c-e10c-48f6-b34d-97f991345165") },
                    { 24L, "imageLink", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9183), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9185), 0L, "Image Link", new Guid("1fd4e5e2-bc71-431b-9e01-bb8962309241") },
                    { 25L, "productGallery", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9189), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9192), 0L, "Product Listing", new Guid("d12f06de-a888-4358-96d9-0869354681dc") },
                    { 26L, "product", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9195), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9198), 0L, "Product", new Guid("8ed708a6-486d-4a15-a4f9-be74cacec18c") },
                    { 27L, "carousel", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9202), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9204), 0L, "Carousel", new Guid("a2c22e69-afb8-482a-a256-ba237b29f319") },
                    { 28L, "carouselItem", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9208), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9211), 0L, "Carousel Item", new Guid("ec008e5c-1449-4c76-9263-1c8ed14c78bb") },
                    { 30L, "registration", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9221), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9224), 0L, "Registration", new Guid("ec401c00-da5f-4970-b5ef-0e1be8c73bdb") },
                    { 22L, "imageGallery", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9167), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9169), 0L, "Image Gallery", new Guid("0523d1cb-8001-43bf-a678-51c1e51e8662") },
                    { 31L, "shoppingBasket", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9230), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9233), 0L, "Shopping Basket", new Guid("021ab399-599a-4fd1-b3d8-e26b4f97025e") },
                    { 32L, "checkout", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9236), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9239), 0L, "Checkout", new Guid("4651c814-52a7-4696-b3d8-a79e4be6fa01") },
                    { 33L, "search", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9243), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9245), 0L, "Search", new Guid("f5e2e383-3b7b-4453-b7d0-53a0c70355da") },
                    { 34L, "searchItem", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9249), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9252), 0L, "Search Item", new Guid("a3132e7c-e80c-47d3-88db-df4b14b1f6ec") },
                    { 35L, "card", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9256), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9258), 0L, "Card", new Guid("9ea280cf-827e-404e-a8e3-195c20eaa205") },
                    { 29L, "login", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9215), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9217), 0L, "Login", new Guid("090b7b7a-12f4-47a6-a72c-cbefc5a4f60e") },
                    { 21L, "toggleSwitch", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9160), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9163), 0L, "Toggle Switch", new Guid("914864f0-9642-4847-8dda-691f8569d3c4") },
                    { 36L, "rowContainer", true, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9262), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9265), 0L, "Row", new Guid("44bafd5d-d789-4327-bae3-90e175d75336") },
                    { 19L, "textBox", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9150), 0L, "TextBox", new Guid("1ffa20f2-7254-473d-8d7d-1d71c6e66bc6") },
                    { 2L, "button", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9012), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9024), 0L, "Button", new Guid("48615ec2-373a-4434-b602-b79a658e44a9") },
                    { 3L, "checkbox", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9029), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9032), 0L, "Checkbox", new Guid("9eaf3348-eaf6-4bc0-937d-0c04674b39ed") },
                    { 4L, "checklist", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9035), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9038), 0L, "Checklist", new Guid("5ced95f3-4de5-4a16-80d2-8a9ed05f408e") },
                    { 5L, "dataListGroup", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9042), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9044), 0L, "Data List Group", new Guid("d91974c0-dba3-4315-b555-9edde2e42ff9") },
                    { 6L, "datePicker", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9048), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9051), 0L, "Date Picker", new Guid("94085fae-fe47-4bfd-8572-1ca0a917cb6e") },
                    { 7L, "divider", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9065), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9067), 0L, "Divider", new Guid("c283fe5a-c8e8-4bc2-ae94-63f14bc42119") },
                    { 8L, "dropDown", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9072), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9074), 0L, "Drop-down", new Guid("d5992241-7c7f-4ab6-abd7-28a28fbb31a3") },
                    { 10L, "fileUpload", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9085), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9087), 0L, "File Upload", new Guid("f8b7aac5-d6ff-46ee-be4b-18274ec1242e") },
                    { 9L, "editableTable", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9078), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9080), 0L, "Editable Table", new Guid("82138da6-a17b-4cd0-9e20-02c34716509e") },
                    { 12L, "subHeading", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9098), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9101), 0L, "Sub-heading", new Guid("d07b879c-d999-42f5-ab34-21a5865def61") },
                    { 13L, "listGroup", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9104), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9107), 0L, "List Group", new Guid("7b83ab9b-23a0-4bc0-a8cd-3349aa068665") },
                    { 14L, "multiLineTextbox", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9111), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9114), 0L, "Multi-line Textbox", new Guid("b44c3b74-5ab5-492d-a95d-42c7ddc06f7f") },
                    { 15L, "radioGroup", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9121), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9124), 0L, "Radio Group", new Guid("757bf62f-b4c6-434d-8278-492e71ce0cfd") },
                    { 16L, "signature", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9128), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9130), 0L, "Signature", new Guid("74f374c0-8b83-47b6-9505-c0c09d4a0e49") },
                    { 17L, "table", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9134), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9137), 0L, "Table", new Guid("ac4efd38-73e0-4754-a1af-45b495d257fb") },
                    { 18L, "textBlock", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9140), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9143), 0L, "Text Block", new Guid("43072c9e-646f-48cc-947b-b879d1b3f685") },
                    { 11L, "heading", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9092), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9094), 0L, "heading", new Guid("b1d49402-7bcd-448b-ae7f-1e714927675e") },
                    { 20L, "timePicker", false, new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9154), new DateTime(2021, 8, 26, 22, 39, 33, 958, DateTimeKind.Local).AddTicks(9156), 0L, "Time Picker", new Guid("7f9b059d-bee6-4222-8610-58e191fa05fe") }
                });

            migrationBuilder.InsertData(
                table: "PageBlocks",
                columns: new[] { "Id", "BlockId", "Level", "PageId", "ParentId", "SortOrder", "Uuid" },
                values: new object[,]
                {
                    { 1L, 36L, 0, 8L, 0L, 0L, new Guid("b4d486d3-221a-4849-b403-6b3e5443636e") },
                    { 3L, 1L, 1, 8L, 1L, 1L, new Guid("d7296de8-0002-43cb-9f8b-b7e3a1588eac") },
                    { 2L, 1L, 1, 8L, 1L, 0L, new Guid("78aef83c-07cf-4e8b-aa2a-c80bc27a1a3d") }
                });

            migrationBuilder.InsertData(
                table: "PageBlocks",
                columns: new[] { "Id", "BlockId", "Level", "PageId", "ParentId", "SortOrder", "Uuid" },
                values: new object[,]
                {
                    { 5L, 2L, 2, 8L, 4L, 0L, new Guid("f86e19a1-571b-455a-8c70-5099822a44c9") },
                    { 4L, 1L, 1, 8L, 1L, 2L, new Guid("f0dbc306-c303-46a9-ac38-24a213de2ede") }
                });

            migrationBuilder.InsertData(
                table: "PageFields",
                columns: new[] { "Id", "DataType", "FieldId", "PageBlockId", "SortOrder", "Title", "Uuid", "Value" },
                values: new object[,]
                {
                    { 3L, "string", 3L, 5L, 2L, "class", new Guid("1c89816d-7fb2-48b8-a2e6-51e9e7718b3f"), "btn btn-success" },
                    { 2L, "string", 2L, 5L, 1L, "text", new Guid("7ccc5cd7-0513-40da-b49c-a5d1d33ecba5"), "Save and continue" },
                    { 1L, "string", 1L, 5L, 0L, "type", new Guid("b77615d2-170c-4f74-b300-bac139b2325f"), "button" },
                    { 4L, "string", null, 5L, 3L, "icon", new Guid("e64d597c-0bd3-421a-b96b-8268a2b28a17"), "fas fa-check" }
                });

            migrationBuilder.InsertData(
                table: "PageTypes",
                columns: new[] { "Id", "Body", "DateCreated" },
                values: new object[,]
                {
                    { "Root", "{\"useBlocks\": true, \"title\": \"Homepage\"}", new DateTime(2021, 8, 26, 22, 39, 33, 954, DateTimeKind.Local).AddTicks(6999) },
                    { "StandardPage", "{\"useBlocks\": true, \"title\": \"Standard Page\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2331) },
                    { "ProductList", "{\"useBlocks\": true, \"title\": \"Product List\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2366) },
                    { "ProductDetail", "{\"useBlocks\": true, \"title\": \"ProductDetail\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2370) },
                    { "SearchResults", "{\"useBlocks\": true, \"title\": \"Search Results\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2396) },
                    { "ArticleDetail", "{\"useBlocks\": true, \"title\": \"Article Detail\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2384) },
                    { "FeatureLanding", "{\"useBlocks\": true, \"title\": \"Feature Landing\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2387) },
                    { "Error", "{\"useBlocks\": true, \"title\": \"Error\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2390) },
                    { "Search", "{\"useBlocks\": true, \"title\": \"Search\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2394) },
                    { "EventList", "{\"useBlocks\": true, \"title\": \"Event List\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2373) },
                    { "Member", "{\"useBlocks\": true, \"title\": \"Member\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2399) },
                    { "Transaction", "{\"useBlocks\": true, \"title\": \"Transaction\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2402) },
                    { "ArticleList", "{\"useBlocks\": true, \"title\": \"Article List\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2380) },
                    { "EventDetail", "{\"useBlocks\": true, \"title\": \"Event Detail\"}", new DateTime(2021, 8, 26, 22, 39, 33, 957, DateTimeKind.Local).AddTicks(2377) }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "Binned", "DateCreated", "DateModified", "DateScheduledExpiry", "DateScheduledPublish", "Disabled", "Draft", "Level", "MetaDescription", "MetaKeywords", "NavigationTitle", "PageIdentifier", "PageTypeId", "ParentPageIdentifier", "Published", "Route", "SiteId", "SortOrder", "Title", "Uuid" },
                values: new object[,]
                {
                    { 7L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3567), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3570), new DateTime(2021, 8, 25, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3575), new DateTime(2021, 8, 24, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3572), false, false, 0, "", "", "Home", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", "Root", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/", 1L, 0L, "Home", new Guid("8e6f4d54-18e6-4df8-b1b6-1fbe5082d07f") },
                    { 6L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3556), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3559), null, new DateTime(2021, 8, 23, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3561), false, false, 0, "", "", "Home", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", "Root", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/", 1L, 0L, "Home", new Guid("05316ec4-d42e-47c0-8017-76098aef102f") },
                    { 5L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3546), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3549), null, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3551), false, false, 1, "", "", "Contact", "26970072-f1fa-4d96-b39b-7ef42f4a8b10", "StandardPage", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/contact", 1L, 2L, "Contact", new Guid("3b0516dd-cc52-48a0-a313-12e772327f1e") },
                    { 4L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3535), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3538), null, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3541), false, false, 1, "", "", "About", "78fdd3d9-1e1e-41c2-80d1-288edfbb3393", "StandardPage", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/about", 1L, 0L, "About", new Guid("7c362f0b-75f4-4717-b83b-89fbc911cee1") },
                    { 3L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3525), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3528), null, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3530), false, false, 2, "", "", "Regulatory Services", "1cd014c0-9db4-4deb-99d0-9505330b707c", "StandardPage", "bce6ab55-0fc2-4b61-ae68-4785e52c1a42", true, "/portfolio/regulatory-services", 1L, 0L, "Regulatory Services", new Guid("8e044a66-5423-4417-9c51-5a30a89e9040") },
                    { 2L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3500), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3514), null, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3517), false, false, 1, "", "", "Portfolio", "bce6ab55-0fc2-4b61-ae68-4785e52c1a42", "StandardPage", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/portfolio", 1L, 1L, "Portfolio", new Guid("4022ccd7-497f-40f4-a879-c32bc53e51d1") },
                    { 1L, false, new DateTime(2021, 8, 26, 22, 39, 33, 963, DateTimeKind.Local).AddTicks(8726), new DateTime(2021, 8, 26, 22, 39, 33, 963, DateTimeKind.Local).AddTicks(9058), null, new DateTime(2021, 8, 22, 22, 39, 33, 963, DateTimeKind.Local).AddTicks(9367), false, false, 0, "", "", "Home", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", "Root", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", true, "/", 1L, 0L, "Home", new Guid("634ac125-9558-4e4e-b069-4d1a8590802f") },
                    { 8L, false, new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3580), new DateTime(2021, 8, 26, 22, 39, 33, 964, DateTimeKind.Local).AddTicks(3583), null, null, false, true, 0, "", "", "Home", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", "Root", "9b9f70f6-d828-4aa0-a363-219ecaf55a98", false, "/", 1L, 0L, "Home", new Guid("ee4a174d-4c54-4fc5-abe6-13b91b97f04c") }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Culture", "DomainName", "Protocol", "Uuid" },
                values: new object[] { 1L, "en-GB", "superjack.co.uk", "https", new Guid("2ee0f3c0-a4f4-40b5-a227-2f2d5450c333") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "FirstName", "PasswordHash", "PasswordSalt", "Status", "Surname", "Username" },
                values: new object[] { 1L, new DateTime(2021, 8, 26, 22, 39, 33, 963, DateTimeKind.Local).AddTicks(5076), "Stef", new byte[] { 102, 253, 151, 91, 246, 124, 31, 249, 111, 243, 101, 140, 224, 104, 177, 57, 251, 2, 250, 103, 36, 67, 216, 30, 83, 234, 198, 17, 187, 118, 52, 100, 174, 40, 59, 113, 173, 133, 3, 48, 97, 59, 239, 193, 54, 13, 198, 133, 199, 42, 181, 174, 51, 187, 196, 145, 37, 231, 32, 34, 66, 219, 183, 97 }, new byte[] { 59, 238, 160, 70, 131, 240, 252, 121, 119, 38, 64, 214, 166, 160, 240, 28, 231, 84, 207, 125, 205, 145, 222, 78, 182, 38, 120, 75, 125, 116, 137, 223, 225, 180, 117, 82, 191, 96, 112, 87, 35, 46, 178, 77, 113, 121, 166, 40, 187, 116, 49, 83, 28, 16, 200, 132, 162, 79, 242, 140, 195, 131, 134, 74, 219, 228, 124, 133, 80, 76, 124, 216, 175, 53, 187, 37, 161, 196, 33, 59, 42, 218, 63, 210, 70, 70, 191, 245, 132, 138, 191, 22, 53, 36, 53, 1, 115, 116, 112, 8, 202, 35, 72, 33, 130, 23, 105, 54, 115, 223, 140, 21, 71, 248, 46, 161, 127, 248, 64, 82, 127, 61, 31, 19, 78, 141, 186, 120 }, "Active", "Cunning", "services@superjack.co.uk" });
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
