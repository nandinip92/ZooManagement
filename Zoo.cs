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
    private readonly ILogger<Zoo> _logger;

    public Zoo(DbContextOptions<Zoo> options, ILogger<Zoo> logger)
        : base(options)
    {
        _logger = logger;
    }

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
        var speciesClassificationsDatafile = "./Data/SpeciesClassifications.csv";
        GetSpeciesFromCSVFile(modelBuilder, speciesClassificationsDatafile);

        var simba = new Animal
        {
            Id = -1,
            Name = "Simba",
            SpeciesId = 19,
            EnclosureId = 119,
            Sex = Sex.Male,
            DateOfBirth = new DateTime(1997, 10, 16).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2000, 1, 1).ToUniversalTime(),
        };
        var nala = new Animal
        {
            Id = -2,
            Name = "Nala",
            SpeciesId = 19,
            EnclosureId = 119,
            Sex = Sex.Female,
            DateOfBirth = new DateTime(1997, 9, 10).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2001, 2, 3).ToUniversalTime(),
        };

        modelBuilder.Entity<Animal>().HasData(simba, nala);
    }

    protected void GetSpeciesFromCSVFile(ModelBuilder modelBuilder, string fileName)
    {
        try
        {
            using var fileReader = new StreamReader(fileName);
            // using var csvData = new CsvReader(fileReader, CultureInfo.InvariantCulture);

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ReadingExceptionOccurred = args =>
                {
                    if (args.Exception is TypeConverterException)
                    {
                        _logger.LogWarning(
                            $"Bad Record Found {args.Exception.Context.Parser.RawRecord}"
                        );
                        return false;
                    }
                    return true;
                }
            };
            using var csvData = new CsvReader(fileReader, csvConfig);
            int speciesId = 1;
            int enclosureId = 100;
            foreach (var species in csvData.GetRecords<SpeciesClassification>())
            {
                var speciesClassType = species.ClassType;
                Classification classification;
                if (Enum.TryParse<Classification>(speciesClassType, out classification))
                {
                    // var SpeciesEnclosureId = enclosureId++;
                    //Creating an Enclosure for Birds, Fishes, Reptiles, Insects, Bugs etc
                    if (
                        classification != Classification.Mammal
                        && classification != Classification.Invertebrate
                    )
                    {
                        CreateNewEnclosure(modelBuilder, ++enclosureId, classification);
                    }
                    var animalNames = species.AnimalNames.Split(',').ToList();
                    foreach (var animal in animalNames)
                    {
                         //Creating a new Enclosure
                        if (
                            classification == Classification.Mammal
                            || classification == Classification.Invertebrate
                        )
                        {
                            // SpeciesEnclosureId=enclosureId++;
                            CreateNewEnclosure(
                                modelBuilder,
                                ++enclosureId,
                                classification,
                                animal.Trim().ToLower()
                            );
                        }
                        //Creating a new species
                        var newSpecies = new Species
                        {
                            Id = speciesId++,
                            Name = animal.Trim(),
                            EnclosureId=enclosureId,
                            Classification = classification
                        };
                        modelBuilder.Entity<Species>().HasData(newSpecies);
                       
                    }
                }
            }
            Console.WriteLine("Loaded the Species Data.........");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Sorry, {fileName} was not found");
        }
    }

    protected void CreateNewEnclosure(
        ModelBuilder modelBuilder,
        int enclosureId,
        Classification classification
    )
    {
        _logger.LogInformation(
            $"Creating Enclosure For {classification.ToString()} with id: : {enclosureId}"
        );
        string? enclosureName = null;
        if (classification == Classification.Bird)
        {
            enclosureName = "Aviatory";
        }
        if (classification == Classification.Fish)
        {
            enclosureName = "Aquarium";
        }
        if (classification == Classification.Reptile)
        {
            enclosureName = "Reptile House";
        }
        if (classification == Classification.Amphibian)
        {
            enclosureName = "Secret Life Of Amphibians";
        }
        if (classification == Classification.Insect)
        {
            enclosureName = "Bugs Enclosure";
        }
        if (enclosureName != null)
        {
            var newEnclosure = new Enclosure
            {
                Id = enclosureId,
                Name = enclosureName,
                Classification = classification
            };
            modelBuilder.Entity<Enclosure>().HasData(newEnclosure);
            _logger.LogInformation($"Completed creating enclosure");
        }
        else
        {
            _logger.LogWarning($"{classification.ToString()} is Not valid. No Enclosure Creation");
        }
    }

    protected void CreateNewEnclosure(
        ModelBuilder modelBuilder,
        int enclosureId,
        Classification classification,
        string animalName
    )
    {
        if (
            classification == Classification.Mammal
            || classification == Classification.Invertebrate
        )
        {
            //Capitalizing the first letter
            var enclosureName = char.ToUpper(animalName[0]) + animalName[1..] + " Enclosure";
            var newEnclosure = new Enclosure
            {
                Id = enclosureId,
                Name = enclosureName,
                Classification = classification
            };
            modelBuilder.Entity<Enclosure>().HasData(newEnclosure);
        }
    }
}
