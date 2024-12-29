using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addfranshise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FranshiseId",
                table: "Establishments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Franshises",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franshises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Franshises_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketingCampaigns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    EstablishmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingCampaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketingCampaigns_Establishments_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establishments_FranshiseId",
                table: "Establishments",
                column: "FranshiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Franshises_AppUserId",
                table: "Franshises",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketingCampaigns_EstablishmentId",
                table: "MarketingCampaigns",
                column: "EstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Establishments_Franshises_FranshiseId",
                table: "Establishments",
                column: "FranshiseId",
                principalTable: "Franshises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establishments_Franshises_FranshiseId",
                table: "Establishments");

            migrationBuilder.DropTable(
                name: "Franshises");

            migrationBuilder.DropTable(
                name: "MarketingCampaigns");

            migrationBuilder.DropIndex(
                name: "IX_Establishments_FranshiseId",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "FranshiseId",
                table: "Establishments");
        }
    }
}
