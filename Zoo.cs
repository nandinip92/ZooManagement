using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Enums;
using ZooManagement.Models.Data;

namespace ZooManagement;

public class Zoo : DbContext
{
    public DbSet<Animal> Animals { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // var lion = new Species
        // {
        //     Id = -1,
        //     Name = "lion",
        //     Classification = Classification.Mammal,
        // };
        var speciesClassificationsDatafileName = "./Data/SpeciesClassifications.csv";
        try
        {
            using var fileReader = new StreamReader(speciesClassificationsDatafileName);
            // var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            // {
            //     ReadingExceptionOccurred = args =>
            //     {
            //         if (args.Exception is TypeConverterException)
            //         {
            //             // _logger.LogWarning($"Bad Record Found {args.Exception.Context.Parser.RawRecord}");
            //             return false;
            //         }
            //         return true;
            //     }
            // };
            // using var csvData = new CsvReader(fileReader, csvConfig);
            using var csvData = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            int id = 0;

            foreach (var species in csvData.GetRecords<SpeciesClassification>())
            {
                var speciesClassType = species.ClassType;
                Classification classification;
                if (Enum.TryParse<Classification>(speciesClassType, out classification)) { 
                    var animalNames = species.AnimalNames.Split(',').ToList();
                    foreach(var animal in animalNames){
                        var newSpecies = new Species{
                            Id= --id,
                            Name = animal.Trim(),
                            Classification=classification
                        };
                        modelBuilder.Entity<Species>().HasData(newSpecies);
                    }
                }
            }
            Console.WriteLine("Loaded the Species Data.........");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Sorry, {speciesClassificationsDatafileName} was not found");
        }


         var simba = new Animal
        {
            Id = -1,
            Name = "simba",
            SpeciesId = -19,
            Sex = Sex.Male,
            DateOfBirth = new DateTime(1997, 10, 16).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2000, 1, 1).ToUniversalTime(),
        };
        var nala = new Animal
        {
            Id = -2,
            Name = "nala",
            SpeciesId = -19,
            Sex = Sex.Female,
            DateOfBirth = new DateTime(1997, 9, 10).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2001, 2, 3).ToUniversalTime(),
        };

        modelBuilder.Entity<Animal>().HasData(simba, nala);

    }

    
}
