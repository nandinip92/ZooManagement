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
                    EnclosureId = table.Column<int>(type: "integer", nullable: false),
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
                    { 101, 0, "Aardvark Enclosure" },
                    { 102, 0, "Antelope Enclosure" },
                    { 103, 0, "Bear Enclosure" },
                    { 104, 0, "Boar Enclosure" },
                    { 105, 0, "Buffalo Enclosure" },
                    { 106, 0, "Calf Enclosure" },
                    { 107, 0, "Cavy Enclosure" },
                    { 108, 0, "Cheetah Enclosure" },
                    { 109, 0, "Deer Enclosure" },
                    { 110, 0, "Dolphin Enclosure" },
                    { 111, 0, "Elephant Enclosure" },
                    { 112, 0, "Fruitbat Enclosure" },
                    { 113, 0, "Giraffe Enclosure" },
                    { 114, 0, "Goat Enclosure" },
                    { 115, 0, "Gorilla Enclosure" },
                    { 116, 0, "Hamster Enclosure" },
                    { 117, 0, "Hare Enclosure" },
                    { 118, 0, "Leopard Enclosure" },
                    { 119, 0, "Lion Enclosure" },
                    { 120, 0, "Lynx Enclosure" },
                    { 121, 0, "Mink Enclosure" },
                    { 122, 0, "Mole Enclosure" },
                    { 123, 0, "Mongoose Enclosure" },
                    { 124, 0, "Opossum Enclosure" },
                    { 125, 0, "Oryx Enclosure" },
                    { 126, 0, "Platypus Enclosure" },
                    { 127, 0, "Polecat Enclosure" },
                    { 128, 0, "Pony Enclosure" },
                    { 129, 0, "Porpoise Enclosure" },
                    { 130, 0, "Puma Enclosure" },
                    { 131, 0, "Pussycat Enclosure" },
                    { 132, 0, "Raccoon Enclosure" },
                    { 133, 0, "Reindeer Enclosure" },
                    { 134, 0, "Seal Enclosure" },
                    { 135, 0, "Sealion Enclosure" },
                    { 136, 0, "Squirrel Enclosure" },
                    { 137, 0, "Vole Enclosure" },
                    { 138, 0, "Wallaby Enclosure" },
                    { 139, 0, "Wolf Enclosure" },
                    { 140, 2, "Aviatory" },
                    { 141, 1, "Reptile House" },
                    { 142, 5, "Aquarium" },
                    { 143, 4, "Secret Life Of Amphibians" },
                    { 144, 3, "Bugs Enclosure" },
                    { 145, 6, "Clam Enclosure" },
                    { 146, 6, "Crab Enclosure" },
                    { 147, 6, "Crayfish Enclosure" },
                    { 148, 6, "Lobster Enclosure" },
                    { 149, 6, "Octopus Enclosure" },
                    { 150, 6, "Scorpion Enclosure" },
                    { 151, 6, "Seawasp Enclosure" },
                    { 152, 6, "Slug Enclosure" },
                    { 153, 6, "Starfish Enclosure" },
                    { 154, 6, "Worm Enclosure" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "EnclosureId", "Name" },
                values: new object[,]
                {
                    { 1, 0, 101, "aardvark" },
                    { 2, 0, 102, "antelope" },
                    { 3, 0, 103, "bear" },
                    { 4, 0, 104, "boar" },
                    { 5, 0, 105, "buffalo" },
                    { 6, 0, 106, "calf" },
                    { 7, 0, 107, "cavy" },
                    { 8, 0, 108, "cheetah" },
                    { 9, 0, 109, "deer" },
                    { 10, 0, 110, "dolphin" },
                    { 11, 0, 111, "elephant" },
                    { 12, 0, 112, "fruitbat" },
                    { 13, 0, 113, "giraffe" },
                    { 14, 0, 114, "goat" },
                    { 15, 0, 115, "gorilla" },
                    { 16, 0, 116, "hamster" },
                    { 17, 0, 117, "hare" },
                    { 18, 0, 118, "leopard" },
                    { 19, 0, 119, "lion" },
                    { 20, 0, 120, "lynx" },
                    { 21, 0, 121, "mink" },
                    { 22, 0, 122, "mole" },
                    { 23, 0, 123, "mongoose" },
                    { 24, 0, 124, "opossum" },
                    { 25, 0, 125, "oryx" },
                    { 26, 0, 126, "platypus" },
                    { 27, 0, 127, "polecat" },
                    { 28, 0, 128, "pony" },
                    { 29, 0, 129, "porpoise" },
                    { 30, 0, 130, "puma" },
                    { 31, 0, 131, "pussycat" },
                    { 32, 0, 132, "raccoon" },
                    { 33, 0, 133, "reindeer" },
                    { 34, 0, 134, "seal" },
                    { 35, 0, 135, "sealion" },
                    { 36, 0, 136, "squirrel" },
                    { 37, 0, 137, "vole" },
                    { 38, 0, 138, "wallaby" },
                    { 39, 0, 139, "wolf" },
                    { 40, 2, 140, "chicken" },
                    { 41, 2, 140, "crow" },
                    { 42, 2, 140, "dove" },
                    { 43, 2, 140, "duck" },
                    { 44, 2, 140, "flamingo" },
                    { 45, 2, 140, "gull" },
                    { 46, 2, 140, "hawk" },
                    { 47, 2, 140, "kiwi" },
                    { 48, 2, 140, "lark" },
                    { 49, 2, 140, "ostrich" },
                    { 50, 2, 140, "parakeet" },
                    { 51, 2, 140, "penguin" },
                    { 52, 2, 140, "pheasant" },
                    { 53, 2, 140, "rhea" },
                    { 54, 2, 140, "skimmer" },
                    { 55, 2, 140, "skua" },
                    { 56, 2, 140, "sparrow" },
                    { 57, 2, 140, "swan" },
                    { 58, 2, 140, "vulture" },
                    { 59, 2, 140, "wren" },
                    { 60, 1, 141, "pitviper" },
                    { 61, 1, 141, "seasnake" },
                    { 62, 1, 141, "slowworm" },
                    { 63, 1, 141, "tortoise" },
                    { 64, 1, 141, "tuatara" },
                    { 65, 5, 142, "bass" },
                    { 66, 5, 142, "carp" },
                    { 67, 5, 142, "catfish" },
                    { 68, 5, 142, "chub" },
                    { 69, 5, 142, "dogfish" },
                    { 70, 5, 142, "haddock" },
                    { 71, 5, 142, "herring" },
                    { 72, 5, 142, "pike" },
                    { 73, 5, 142, "piranha" },
                    { 74, 5, 142, "seahorse" },
                    { 75, 5, 142, "sole" },
                    { 76, 5, 142, "stingray" },
                    { 77, 5, 142, "tuna" },
                    { 78, 4, 143, "frog" },
                    { 79, 4, 143, "newt" },
                    { 80, 4, 143, "toad" },
                    { 81, 3, 144, "flea" },
                    { 82, 3, 144, "gnat" },
                    { 83, 3, 144, "honeybee" },
                    { 84, 3, 144, "housefly" },
                    { 85, 3, 144, "ladybird" },
                    { 86, 3, 144, "moth" },
                    { 87, 3, 144, "termite" },
                    { 88, 3, 144, "wasp" },
                    { 89, 6, 145, "clam" },
                    { 90, 6, 146, "crab" },
                    { 91, 6, 147, "crayfish" },
                    { 92, 6, 148, "lobster" },
                    { 93, 6, 149, "octopus" },
                    { 94, 6, 150, "scorpion" },
                    { 95, 6, 151, "seawasp" },
                    { 96, 6, 152, "slug" },
                    { 97, 6, 153, "starfish" },
                    { 98, 6, 154, "worm" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 23, 0, 0, 0, DateTimeKind.Utc), 119, "Nala", 1, 19 },
                    { -1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 23, 0, 0, 0, DateTimeKind.Utc), 119, "Simba", 0, 19 }
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
