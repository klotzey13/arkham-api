using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arkham.API.Migrations
{
    /// <inheritdoc />
    public partial class AddFaction2Card : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Factions_FactionId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "Faction2Id",
                table: "Cards",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Faction2Id",
                table: "Cards",
                column: "Faction2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Factions_Faction2Id",
                table: "Cards",
                column: "Faction2Id",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Factions_FactionId",
                table: "Cards",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Factions_Faction2Id",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Factions_FactionId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_Faction2Id",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Faction2Id",
                table: "Cards");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Factions_FactionId",
                table: "Cards",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
