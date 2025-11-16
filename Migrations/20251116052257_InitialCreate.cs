using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Arkham.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RealName = table.Column<string>(type: "text", nullable: true),
                    SubName = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    RealText = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SkillWillpower = table.Column<int>(type: "integer", nullable: true),
                    SkillIntellect = table.Column<int>(type: "integer", nullable: true),
                    SkillCombat = table.Column<int>(type: "integer", nullable: true),
                    SkillAgility = table.Column<int>(type: "integer", nullable: true),
                    SkillWild = table.Column<int>(type: "integer", nullable: true),
                    Health = table.Column<int>(type: "integer", nullable: true),
                    HealthPerInvestigator = table.Column<bool>(type: "boolean", nullable: false),
                    Sanity = table.Column<int>(type: "integer", nullable: true),
                    DeckLimit = table.Column<int>(type: "integer", nullable: true),
                    Slot = table.Column<string>(type: "text", nullable: true),
                    RealSlot = table.Column<string>(type: "text", nullable: true),
                    Flavor = table.Column<string>(type: "text", nullable: true),
                    Illustrator = table.Column<string>(type: "text", nullable: true),
                    IsUnique = table.Column<bool>(type: "boolean", nullable: false),
                    Permanent = table.Column<bool>(type: "boolean", nullable: false),
                    DoubleSided = table.Column<bool>(type: "boolean", nullable: false),
                    BackText = table.Column<string>(type: "text", nullable: true),
                    BackFlavor = table.Column<string>(type: "text", nullable: true),
                    OctgnId = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ImageSrc = table.Column<string>(type: "text", nullable: true),
                    BackImageSrc = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<int>(type: "integer", nullable: true),
                    Xp = table.Column<int>(type: "integer", nullable: true),
                    Position = table.Column<int>(type: "integer", nullable: false),
                    Exceptional = table.Column<bool>(type: "boolean", nullable: false),
                    Myriad = table.Column<bool>(type: "boolean", nullable: false),
                    DeckSize = table.Column<int>(type: "integer", nullable: true),
                    PackId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    FactionId = table.Column<int>(type: "integer", nullable: false),
                    SubTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_CardTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_SubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "SubTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardTraits",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    TraitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTraits", x => new { x.CardId, x.TraitId });
                    table.ForeignKey(
                        name: "FK_CardTraits_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTraits_Traits_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    LevelMin = table.Column<int>(type: "integer", nullable: true),
                    LevelMax = table.Column<int>(type: "integer", nullable: true),
                    Limit = table.Column<int>(type: "integer", nullable: true),
                    Not = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckOptions_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckRequirements_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckOptionFactions",
                columns: table => new
                {
                    DeckOptionId = table.Column<int>(type: "integer", nullable: false),
                    FactionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOptionFactions", x => new { x.DeckOptionId, x.FactionId });
                    table.ForeignKey(
                        name: "FK_DeckOptionFactions_DeckOptions_DeckOptionId",
                        column: x => x.DeckOptionId,
                        principalTable: "DeckOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckOptionFactions_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckOptionTraits",
                columns: table => new
                {
                    DeckOptionId = table.Column<int>(type: "integer", nullable: false),
                    TraitId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOptionTraits", x => new { x.DeckOptionId, x.TraitId });
                    table.ForeignKey(
                        name: "FK_DeckOptionTraits_DeckOptions_DeckOptionId",
                        column: x => x.DeckOptionId,
                        principalTable: "DeckOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckOptionTraits_Traits_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Traits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckRequirementCardChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeckRequirementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckRequirementCardChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckRequirementCardChoices_DeckRequirements_DeckRequirement~",
                        column: x => x.DeckRequirementId,
                        principalTable: "DeckRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckRequirementRandoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeckRequirementId = table.Column<int>(type: "integer", nullable: false),
                    Target = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckRequirementRandoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckRequirementRandoms_DeckRequirements_DeckRequirementId",
                        column: x => x.DeckRequirementId,
                        principalTable: "DeckRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeckRequirementCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeckRequirementCardChoiceId = table.Column<int>(type: "integer", nullable: false),
                    CardCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckRequirementCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckRequirementCards_DeckRequirementCardChoices_DeckRequire~",
                        column: x => x.DeckRequirementCardChoiceId,
                        principalTable: "DeckRequirementCardChoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_FactionId",
                table: "Cards",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PackId",
                table: "Cards",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SubTypeId",
                table: "Cards",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_TypeId",
                table: "Cards",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTraits_TraitId",
                table: "CardTraits",
                column: "TraitId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckOptionFactions_FactionId",
                table: "DeckOptionFactions",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckOptions_CardId",
                table: "DeckOptions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckOptionTraits_TraitId",
                table: "DeckOptionTraits",
                column: "TraitId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckRequirementCardChoices_DeckRequirementId",
                table: "DeckRequirementCardChoices",
                column: "DeckRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckRequirementCards_DeckRequirementCardChoiceId",
                table: "DeckRequirementCards",
                column: "DeckRequirementCardChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckRequirementRandoms_DeckRequirementId",
                table: "DeckRequirementRandoms",
                column: "DeckRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckRequirements_CardId",
                table: "DeckRequirements",
                column: "CardId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTraits");

            migrationBuilder.DropTable(
                name: "DeckOptionFactions");

            migrationBuilder.DropTable(
                name: "DeckOptionTraits");

            migrationBuilder.DropTable(
                name: "DeckRequirementCards");

            migrationBuilder.DropTable(
                name: "DeckRequirementRandoms");

            migrationBuilder.DropTable(
                name: "DeckOptions");

            migrationBuilder.DropTable(
                name: "Traits");

            migrationBuilder.DropTable(
                name: "DeckRequirementCardChoices");

            migrationBuilder.DropTable(
                name: "DeckRequirements");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Packs");

            migrationBuilder.DropTable(
                name: "SubTypes");
        }
    }
}
