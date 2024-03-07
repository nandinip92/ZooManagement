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
                    Name = table.Column<string>(type: "text", nullable: false)
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
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 23, 0, 0, 0, DateTimeKind.Utc), 118, "Nala", 1, -19 },
                    { -1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 23, 0, 0, 0, DateTimeKind.Utc), 118, "Simba", 0, -19 }
                });

            migrationBuilder.InsertData(
                table: "Enclosure",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 101, "Aardvark Enclosure" },
                    { 102, "Antelope Enclosure" },
                    { 103, "Bear Enclosure" },
                    { 104, "Boar Enclosure" },
                    { 105, "Buffalo Enclosure" },
                    { 106, "Calf Enclosure" },
                    { 107, "Cavy Enclosure" },
                    { 108, "Cheetah Enclosure" },
                    { 109, "Deer Enclosure" },
                    { 110, "Dolphin Enclosure" },
                    { 111, "Elephant Enclosure" },
                    { 112, "Fruitbat Enclosure" },
                    { 113, "Giraffe Enclosure" },
                    { 114, "Goat Enclosure" },
                    { 115, "Gorilla Enclosure" },
                    { 116, "Hamster Enclosure" },
                    { 117, "Hare Enclosure" },
                    { 118, "Leopard Enclosure" },
                    { 119, "Lion Enclosure" },
                    { 120, "Lynx Enclosure" },
                    { 121, "Mink Enclosure" },
                    { 122, "Mole Enclosure" },
                    { 123, "Mongoose Enclosure" },
                    { 124, "Opossum Enclosure" },
                    { 125, "Oryx Enclosure" },
                    { 126, "Platypus Enclosure" },
                    { 127, "Polecat Enclosure" },
                    { 128, "Pony Enclosure" },
                    { 129, "Porpoise Enclosure" },
                    { 130, "Puma Enclosure" },
                    { 131, "Pussycat Enclosure" },
                    { 132, "Raccoon Enclosure" },
                    { 133, "Reindeer Enclosure" },
                    { 134, "Seal Enclosure" },
                    { 135, "Sealion Enclosure" },
                    { 136, "Squirrel Enclosure" },
                    { 137, "Vampire Enclosure" },
                    { 138, "Vole Enclosure" },
                    { 139, "Wallaby Enclosure" },
                    { 140, "Wolf Enclosure" },
                    { 141, "Aviatory" },
                    { 142, "Reptile House" },
                    { 143, "Aquarium" },
                    { 144, "Secret Life Of Amphibians" },
                    { 145, "Bugs Enclosure" },
                    { 146, "Clam Enclosure" },
                    { 147, "Crab Enclosure" },
                    { 148, "Crayfish Enclosure" },
                    { 149, "Lobster Enclosure" },
                    { 150, "Octopus Enclosure" },
                    { 151, "Scorpion Enclosure" },
                    { 152, "Seawasp Enclosure" },
                    { 153, "Slug Enclosure" },
                    { 154, "Starfish Enclosure" },
                    { 155, "Worm Enclosure" }
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
                    { 37, 0, "vampire" },
                    { 38, 0, "vole" },
                    { 39, 0, "wallaby" },
                    { 40, 0, "wolf" },
                    { 41, 2, "chicken" },
                    { 42, 2, "crow" },
                    { 43, 2, "dove" },
                    { 44, 2, "duck" },
                    { 45, 2, "flamingo" },
                    { 46, 2, "gull" },
                    { 47, 2, "hawk" },
                    { 48, 2, "kiwi" },
                    { 49, 2, "lark" },
                    { 50, 2, "ostrich" },
                    { 51, 2, "parakeet" },
                    { 52, 2, "penguin" },
                    { 53, 2, "pheasant" },
                    { 54, 2, "rhea" },
                    { 55, 2, "skimmer" },
                    { 56, 2, "skua" },
                    { 57, 2, "sparrow" },
                    { 58, 2, "swan" },
                    { 59, 2, "vulture" },
                    { 60, 2, "wren" },
                    { 61, 1, "pitviper" },
                    { 62, 1, "seasnake" },
                    { 63, 1, "slowworm" },
                    { 64, 1, "tortoise" },
                    { 65, 1, "tuatara" },
                    { 66, 5, "bass" },
                    { 67, 5, "carp" },
                    { 68, 5, "catfish" },
                    { 69, 5, "chub" },
                    { 70, 5, "dogfish" },
                    { 71, 5, "haddock" },
                    { 72, 5, "herring" },
                    { 73, 5, "pike" },
                    { 74, 5, "piranha" },
                    { 75, 5, "seahorse" },
                    { 76, 5, "sole" },
                    { 77, 5, "stingray" },
                    { 78, 5, "tuna" },
                    { 79, 4, "frog" },
                    { 80, 4, "newt" },
                    { 81, 4, "toad" },
                    { 82, 3, "flea" },
                    { 83, 3, "gnat" },
                    { 84, 3, "honeybee" },
                    { 85, 3, "housefly" },
                    { 86, 3, "ladybird" },
                    { 87, 3, "moth" },
                    { 88, 3, "termite" },
                    { 89, 3, "wasp" },
                    { 90, 6, "clam" },
                    { 91, 6, "crab" },
                    { 92, 6, "crayfish" },
                    { 93, 6, "lobster" },
                    { 94, 6, "octopus" },
                    { 95, 6, "scorpion" },
                    { 96, 6, "seawasp" },
                    { 97, 6, "slug" },
                    { 98, 6, "starfish" },
                    { 99, 6, "worm" }
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
