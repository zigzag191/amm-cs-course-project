using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "order_state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "processor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    NumberOfCores = table.Column<int>(type: "int", nullable: false),
                    Tdp = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    StorageSize = table.Column<int>(type: "int", nullable: false),
                    RamSize = table.Column<int>(type: "int", nullable: false),
                    ProcessorId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_phone_manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phone_processor_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "processor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderStateId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_order_state_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "order_state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_in_shopping_cart",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_in_shopping_cart", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_item_in_shopping_cart_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_in_shopping_cart_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phone_comment",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone_comment", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_phone_comment_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phone_comment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phone_rating",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phone_rating", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_phone_rating_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_phone_rating_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedPhones",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPhones", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderedPhones_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedPhones_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrator_ExternalId",
                table: "administrator",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_in_shopping_cart_ExternalId",
                table: "item_in_shopping_cart",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_in_shopping_cart_PhoneId",
                table: "item_in_shopping_cart",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_manufacturer_ExternalId",
                table: "manufacturer",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_ExternalId",
                table: "order",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_OrderStateId",
                table: "order",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_order_state_ExternalId",
                table: "order_state",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPhones_ExternalId",
                table: "OrderedPhones",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderedPhones_PhoneId",
                table: "OrderedPhones",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_phone_ExternalId",
                table: "phone",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phone_ManufacturerId",
                table: "phone",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_phone_ProcessorId",
                table: "phone",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_phone_comment_ExternalId",
                table: "phone_comment",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phone_comment_PhoneId",
                table: "phone_comment",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_phone_rating_ExternalId",
                table: "phone_rating",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_phone_rating_PhoneId",
                table: "phone_rating",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_processor_ExternalId",
                table: "processor",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_ExternalId",
                table: "user",
                column: "ExternalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator");

            migrationBuilder.DropTable(
                name: "item_in_shopping_cart");

            migrationBuilder.DropTable(
                name: "OrderedPhones");

            migrationBuilder.DropTable(
                name: "phone_comment");

            migrationBuilder.DropTable(
                name: "phone_rating");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "phone");

            migrationBuilder.DropTable(
                name: "order_state");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "processor");
        }
    }
}
