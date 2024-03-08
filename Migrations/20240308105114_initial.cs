using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosure", x => x.Id);
                });

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
                    EnclosureId = table.Column<int>(type: "integer", nullable: false),
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
                table: "Enclosure",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { 100, 0, "Aardvark Enclosure" },
                    { 101, 0, "Antelope Enclosure" },
                    { 102, 0, "Bear Enclosure" },
                    { 103, 0, "Boar Enclosure" },
                    { 104, 0, "Buffalo Enclosure" },
                    { 105, 0, "Calf Enclosure" },
                    { 106, 0, "Cavy Enclosure" },
                    { 107, 0, "Cheetah Enclosure" },
                    { 108, 0, "Deer Enclosure" },
                    { 109, 0, "Dolphin Enclosure" },
                    { 110, 0, "Elephant Enclosure" },
                    { 111, 0, "Fruitbat Enclosure" },
                    { 112, 0, "Giraffe Enclosure" },
                    { 113, 0, "Goat Enclosure" },
                    { 114, 0, "Gorilla Enclosure" },
                    { 115, 0, "Hamster Enclosure" },
                    { 116, 0, "Hare Enclosure" },
                    { 117, 0, "Leopard Enclosure" },
                    { 118, 0, "Lion Enclosure" },
                    { 119, 0, "Lynx Enclosure" },
                    { 120, 0, "Mink Enclosure" },
                    { 121, 0, "Mole Enclosure" },
                    { 122, 0, "Mongoose Enclosure" },
                    { 123, 0, "Opossum Enclosure" },
                    { 124, 0, "Oryx Enclosure" },
                    { 125, 0, "Platypus Enclosure" },
                    { 126, 0, "Polecat Enclosure" },
                    { 127, 0, "Pony Enclosure" },
                    { 128, 0, "Porpoise Enclosure" },
                    { 129, 0, "Puma Enclosure" },
                    { 130, 0, "Pussycat Enclosure" },
                    { 131, 0, "Raccoon Enclosure" },
                    { 132, 0, "Reindeer Enclosure" },
                    { 133, 0, "Seal Enclosure" },
                    { 134, 0, "Sealion Enclosure" },
                    { 135, 0, "Squirrel Enclosure" },
                    { 136, 0, "Vole Enclosure" },
                    { 137, 0, "Wallaby Enclosure" },
                    { 138, 0, "Wolf Enclosure" },
                    { 139, 2, "Aviatory" },
                    { 140, 1, "Reptile House" },
                    { 141, 5, "Aquarium" },
                    { 142, 4, "Secret Life Of Amphibians" },
                    { 143, 3, "Bugs Enclosure" },
                    { 144, 6, "Clam Enclosure" },
                    { 145, 6, "Crab Enclosure" },
                    { 146, 6, "Crayfish Enclosure" },
                    { 147, 6, "Lobster Enclosure" },
                    { 148, 6, "Octopus Enclosure" },
                    { 149, 6, "Scorpion Enclosure" },
                    { 150, 6, "Seawasp Enclosure" },
                    { 151, 6, "Slug Enclosure" },
                    { 152, 6, "Starfish Enclosure" },
                    { 153, 6, "Worm Enclosure" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { 1, 0, "aardvark" },
                    { 2, 0, "antelope" },
                    { 3, 0, "bear" },
                    { 4, 0, "boar" },
                    { 5, 0, "buffalo" },
                    { 6, 0, "calf" },
                    { 7, 0, "cavy" },
                    { 8, 0, "cheetah" },
                    { 9, 0, "deer" },
                    { 10, 0, "dolphin" },
                    { 11, 0, "elephant" },
                    { 12, 0, "fruitbat" },
                    { 13, 0, "giraffe" },
                    { 14, 0, "goat" },
                    { 15, 0, "gorilla" },
                    { 16, 0, "hamster" },
                    { 17, 0, "hare" },
                    { 18, 0, "leopard" },
                    { 19, 0, "lion" },
                    { 20, 0, "lynx" },
                    { 21, 0, "mink" },
                    { 22, 0, "mole" },
                    { 23, 0, "mongoose" },
                    { 24, 0, "opossum" },
                    { 25, 0, "oryx" },
                    { 26, 0, "platypus" },
                    { 27, 0, "polecat" },
                    { 28, 0, "pony" },
                    { 29, 0, "porpoise" },
                    { 30, 0, "puma" },
                    { 31, 0, "pussycat" },
                    { 32, 0, "raccoon" },
                    { 33, 0, "reindeer" },
                    { 34, 0, "seal" },
                    { 35, 0, "sealion" },
                    { 36, 0, "squirrel" },
                    { 37, 0, "vole" },
                    { 38, 0, "wallaby" },
                    { 39, 0, "wolf" },
                    { 40, 2, "chicken" },
                    { 41, 2, "crow" },
                    { 42, 2, "dove" },
                    { 43, 2, "duck" },
                    { 44, 2, "flamingo" },
                    { 45, 2, "gull" },
                    { 46, 2, "hawk" },
                    { 47, 2, "kiwi" },
                    { 48, 2, "lark" },
                    { 49, 2, "ostrich" },
                    { 50, 2, "parakeet" },
                    { 51, 2, "penguin" },
                    { 52, 2, "pheasant" },
                    { 53, 2, "rhea" },
                    { 54, 2, "skimmer" },
                    { 55, 2, "skua" },
                    { 56, 2, "sparrow" },
                    { 57, 2, "swan" },
                    { 58, 2, "vulture" },
                    { 59, 2, "wren" },
                    { 60, 1, "pitviper" },
                    { 61, 1, "seasnake" },
                    { 62, 1, "slowworm" },
                    { 63, 1, "tortoise" },
                    { 64, 1, "tuatara" },
                    { 65, 5, "bass" },
                    { 66, 5, "carp" },
                    { 67, 5, "catfish" },
                    { 68, 5, "chub" },
                    { 69, 5, "dogfish" },
                    { 70, 5, "haddock" },
                    { 71, 5, "herring" },
                    { 72, 5, "pike" },
                    { 73, 5, "piranha" },
                    { 74, 5, "seahorse" },
                    { 75, 5, "sole" },
                    { 76, 5, "stingray" },
                    { 77, 5, "tuna" },
                    { 78, 4, "frog" },
                    { 79, 4, "newt" },
                    { 80, 4, "toad" },
                    { 81, 3, "flea" },
                    { 82, 3, "gnat" },
                    { 83, 3, "honeybee" },
                    { 84, 3, "housefly" },
                    { 85, 3, "ladybird" },
                    { 86, 3, "moth" },
                    { 87, 3, "termite" },
                    { 88, 3, "wasp" },
                    { 89, 6, "clam" },
                    { 90, 6, "crab" },
                    { 91, 6, "crayfish" },
                    { 92, 6, "lobster" },
                    { 93, 6, "octopus" },
                    { 94, 6, "scorpion" },
                    { 95, 6, "seawasp" },
                    { 96, 6, "slug" },
                    { 97, 6, "starfish" },
                    { 98, 6, "worm" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 23, 0, 0, 0, DateTimeKind.Utc), 118, "Nala", 1, 19 },
                    { -1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 23, 0, 0, 0, DateTimeKind.Utc), 118, "Simba", 0, 19 }
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
                name: "Enclosure");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
