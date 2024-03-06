using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfAcquisition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { -99, 6, "worm" },
                    { -98, 6, "starfish" },
                    { -97, 6, "slug" },
                    { -96, 6, "seawasp" },
                    { -95, 6, "scorpion" },
                    { -94, 6, "octopus" },
                    { -93, 6, "lobster" },
                    { -92, 6, "crayfish" },
                    { -91, 6, "crab" },
                    { -90, 6, "clam" },
                    { -89, 3, "wasp" },
                    { -88, 3, "termite" },
                    { -87, 3, "moth" },
                    { -86, 3, "ladybird" },
                    { -85, 3, "housefly" },
                    { -84, 3, "honeybee" },
                    { -83, 3, "gnat" },
                    { -82, 3, "flea" },
                    { -81, 4, "toad" },
                    { -80, 4, "newt" },
                    { -79, 4, "frog" },
                    { -78, 5, "tuna" },
                    { -77, 5, "stingray" },
                    { -76, 5, "sole" },
                    { -75, 5, "seahorse" },
                    { -74, 5, "piranha" },
                    { -73, 5, "pike" },
                    { -72, 5, "herring" },
                    { -71, 5, "haddock" },
                    { -70, 5, "dogfish" },
                    { -69, 5, "chub" },
                    { -68, 5, "catfish" },
                    { -67, 5, "carp" },
                    { -66, 5, "bass" },
                    { -65, 1, "tuatara" },
                    { -64, 1, "tortoise" },
                    { -63, 1, "slowworm" },
                    { -62, 1, "seasnake" },
                    { -61, 1, "pitviper" },
                    { -60, 2, "wren" },
                    { -59, 2, "vulture" },
                    { -58, 2, "swan" },
                    { -57, 2, "sparrow" },
                    { -56, 2, "skua" },
                    { -55, 2, "skimmer" },
                    { -54, 2, "rhea" },
                    { -53, 2, "pheasant" },
                    { -52, 2, "penguin" },
                    { -51, 2, "parakeet" },
                    { -50, 2, "ostrich" },
                    { -49, 2, "lark" },
                    { -48, 2, "kiwi" },
                    { -47, 2, "hawk" },
                    { -46, 2, "gull" },
                    { -45, 2, "flamingo" },
                    { -44, 2, "duck" },
                    { -43, 2, "dove" },
                    { -42, 2, "crow" },
                    { -41, 2, "chicken" },
                    { -40, 0, "wolf" },
                    { -39, 0, "wallaby" },
                    { -38, 0, "vole" },
                    { -37, 0, "vampire" },
                    { -36, 0, "squirrel" },
                    { -35, 0, "sealion" },
                    { -34, 0, "seal" },
                    { -33, 0, "reindeer" },
                    { -32, 0, "raccoon" },
                    { -31, 0, "pussycat" },
                    { -30, 0, "puma" },
                    { -29, 0, "porpoise" },
                    { -28, 0, "pony" },
                    { -27, 0, "polecat" },
                    { -26, 0, "platypus" },
                    { -25, 0, "oryx" },
                    { -24, 0, "opossum" },
                    { -23, 0, "mongoose" },
                    { -22, 0, "mole" },
                    { -21, 0, "mink" },
                    { -20, 0, "lynx" },
                    { -19, 0, "lion" },
                    { -18, 0, "leopard" },
                    { -17, 0, "hare" },
                    { -16, 0, "hamster" },
                    { -15, 0, "gorilla" },
                    { -14, 0, "goat" },
                    { -13, 0, "giraffe" },
                    { -12, 0, "fruitbat" },
                    { -11, 0, "elephant" },
                    { -10, 0, "dolphin" },
                    { -9, 0, "deer" },
                    { -8, 0, "cheetah" },
                    { -7, 0, "cavy" },
                    { -6, 0, "calf" },
                    { -5, 0, "buffalo" },
                    { -4, 0, "boar" },
                    { -3, 0, "bear" },
                    { -2, 0, "antelope" },
                    { -1, 0, "aardvark" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 23, 0, 0, 0, DateTimeKind.Utc), "nala", 1, -19 },
                    { -1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 23, 0, 0, 0, DateTimeKind.Utc), "simba", 0, -19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
