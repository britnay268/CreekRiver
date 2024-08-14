using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CreekRiver.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampsiteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteTypeName = table.Column<string>(type: "text", nullable: false),
                    MaxReservationDays = table.Column<int>(type: "integer", nullable: false),
                    FeePerNight = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampsiteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campsites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CampsiteTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campsites_CampsiteTypes_CampsiteTypeId",
                        column: x => x.CampsiteTypeId,
                        principalTable: "CampsiteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampsiteId = table.Column<int>(type: "integer", nullable: false),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Campsites_CampsiteId",
                        column: x => x.CampsiteId,
                        principalTable: "Campsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CampsiteTypes",
                columns: new[] { "Id", "CampsiteTypeName", "FeePerNight", "MaxReservationDays" },
                values: new object[,]
                {
                    { 1, "Tent", 15.99m, 7 },
                    { 2, "RV", 26.50m, 14 },
                    { 3, "Primitive", 10.00m, 3 },
                    { 4, "Hammock", 12m, 7 }
                });

            migrationBuilder.InsertData(
                table: "Campsites",
                columns: new[] { "Id", "CampsiteTypeId", "ImageUrl", "Nickname" },
                values: new object[,]
                {
                    { 1, 1, "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg", "Barred Owl" },
                    { 2, 3, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTAIFIKpUCDpEyB2vt7AJwYfRmooPM427XeVTz5hkawhL7qZcwca6BcieZQq5s6qSHhuk&usqp=CAU", "Shadow Woods" },
                    { 3, 2, "https://cdnb.artstation.com/p/assets/images/images/024/924/901/large/korhan-alp-maden-sokakta-yalniz2-1.jpg?1583972930", "Night Vibes" },
                    { 4, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKRTjoE6NmCDX99Ruk713K9p16mu517TlYEQ&s", "Meet Greet" },
                    { 5, 4, "https://res.cloudinary.com/simpleview/image/upload/v1459362023/clients/boston/header_aboutboston_seasons_fall_publicgarden_c6fb1674-26d0-41c0-a160-e2bf87b92f10.jpg", "Solitude Fall" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campsites_CampsiteTypeId",
                table: "Campsites",
                column: "CampsiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CampsiteId",
                table: "Reservations",
                column: "CampsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserProfileId",
                table: "Reservations",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Campsites");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CampsiteTypes");
        }
    }
}
