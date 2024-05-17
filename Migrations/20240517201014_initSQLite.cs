using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class initSQLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enclosures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enclosures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false),
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Species_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnclosureId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sex = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfAcquisition = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Enclosures_EnclosureId",
                        column: x => x.EnclosureId,
                        principalTable: "Enclosures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Enclosures",
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
                    { -98, 6, 154, "worm" },
                    { -97, 6, 153, "starfish" },
                    { -96, 6, 152, "slug" },
                    { -95, 6, 151, "seawasp" },
                    { -94, 6, 150, "scorpion" },
                    { -93, 6, 149, "octopus" },
                    { -92, 6, 148, "lobster" },
                    { -91, 6, 147, "crayfish" },
                    { -90, 6, 146, "crab" },
                    { -89, 6, 145, "clam" },
                    { -88, 3, 144, "wasp" },
                    { -87, 3, 144, "termite" },
                    { -86, 3, 144, "moth" },
                    { -85, 3, 144, "ladybird" },
                    { -84, 3, 144, "housefly" },
                    { -83, 3, 144, "honeybee" },
                    { -82, 3, 144, "gnat" },
                    { -81, 3, 144, "flea" },
                    { -80, 4, 143, "toad" },
                    { -79, 4, 143, "newt" },
                    { -78, 4, 143, "frog" },
                    { -77, 5, 142, "tuna" },
                    { -76, 5, 142, "stingray" },
                    { -75, 5, 142, "sole" },
                    { -74, 5, 142, "seahorse" },
                    { -73, 5, 142, "piranha" },
                    { -72, 5, 142, "pike" },
                    { -71, 5, 142, "herring" },
                    { -70, 5, 142, "haddock" },
                    { -69, 5, 142, "dogfish" },
                    { -68, 5, 142, "chub" },
                    { -67, 5, 142, "catfish" },
                    { -66, 5, 142, "carp" },
                    { -65, 5, 142, "bass" },
                    { -64, 1, 141, "tuatara" },
                    { -63, 1, 141, "tortoise" },
                    { -62, 1, 141, "slowworm" },
                    { -61, 1, 141, "seasnake" },
                    { -60, 1, 141, "pitviper" },
                    { -59, 2, 140, "wren" },
                    { -58, 2, 140, "vulture" },
                    { -57, 2, 140, "swan" },
                    { -56, 2, 140, "sparrow" },
                    { -55, 2, 140, "skua" },
                    { -54, 2, 140, "skimmer" },
                    { -53, 2, 140, "rhea" },
                    { -52, 2, 140, "pheasant" },
                    { -51, 2, 140, "penguin" },
                    { -50, 2, 140, "parakeet" },
                    { -49, 2, 140, "ostrich" },
                    { -48, 2, 140, "lark" },
                    { -47, 2, 140, "kiwi" },
                    { -46, 2, 140, "hawk" },
                    { -45, 2, 140, "gull" },
                    { -44, 2, 140, "flamingo" },
                    { -43, 2, 140, "duck" },
                    { -42, 2, 140, "dove" },
                    { -41, 2, 140, "crow" },
                    { -40, 2, 140, "chicken" },
                    { -39, 0, 139, "wolf" },
                    { -38, 0, 138, "wallaby" },
                    { -37, 0, 137, "vole" },
                    { -36, 0, 136, "squirrel" },
                    { -35, 0, 135, "sealion" },
                    { -34, 0, 134, "seal" },
                    { -33, 0, 133, "reindeer" },
                    { -32, 0, 132, "raccoon" },
                    { -31, 0, 131, "pussycat" },
                    { -30, 0, 130, "puma" },
                    { -29, 0, 129, "porpoise" },
                    { -28, 0, 128, "pony" },
                    { -27, 0, 127, "polecat" },
                    { -26, 0, 126, "platypus" },
                    { -25, 0, 125, "oryx" },
                    { -24, 0, 124, "opossum" },
                    { -23, 0, 123, "mongoose" },
                    { -22, 0, 122, "mole" },
                    { -21, 0, 121, "mink" },
                    { -20, 0, 120, "lynx" },
                    { -19, 0, 119, "lion" },
                    { -18, 0, 118, "leopard" },
                    { -17, 0, 117, "hare" },
                    { -16, 0, 116, "hamster" },
                    { -15, 0, 115, "gorilla" },
                    { -14, 0, 114, "goat" },
                    { -13, 0, 113, "giraffe" },
                    { -12, 0, 112, "fruitbat" },
                    { -11, 0, 111, "elephant" },
                    { -10, 0, 110, "dolphin" },
                    { -9, 0, 109, "deer" },
                    { -8, 0, 108, "cheetah" },
                    { -7, 0, 107, "cavy" },
                    { -6, 0, 106, "calf" },
                    { -5, 0, 105, "buffalo" },
                    { -4, 0, 104, "boar" },
                    { -3, 0, 103, "bear" },
                    { -2, 0, 102, "antelope" },
                    { -1, 0, 101, "aardvark" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "EnclosureId", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 23, 0, 0, 0, DateTimeKind.Utc), 119, "Nala", 1, -19 },
                    { -1, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 23, 0, 0, 0, DateTimeKind.Utc), 119, "Simba", 0, -19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureId",
                table: "Animals",
                column: "EnclosureId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Species_EnclosureId",
                table: "Species",
                column: "EnclosureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Enclosures");
        }
    }
}
