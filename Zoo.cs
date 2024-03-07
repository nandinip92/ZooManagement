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
            EnclosureId = 118,
            Sex = Sex.Male,
            DateOfBirth = new DateTime(1997, 10, 16).ToUniversalTime(),
            DateOfAcquisition = new DateTime(2000, 1, 1).ToUniversalTime(),
        };
        var nala = new Animal
        {
            Id = -2,
            Name = "Nala",
            SpeciesId = 19,
            EnclosureId = 118,
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
                    //Creating an Enclosure for Birds, Fishes, Reptiles, Insects, Bugs etc
                    if (
                        !speciesClassType.Equals("Mammal")
                        && !speciesClassType.Equals("Invertebrate")
                    )
                    {
                        CreateNewEnclosure(modelBuilder, enclosureId++, speciesClassType);
                    }
                    var animalNames = species.AnimalNames.Split(',').ToList();
                    foreach (var animal in animalNames)
                    {
                        //Creating a new species
                        var newSpecies = new Species
                        {
                            Id = speciesId++,
                            Name = animal.Trim(),
                            Classification = classification
                        };
                        modelBuilder.Entity<Species>().HasData(newSpecies);
                        //Creating a new Enclosure
                        if (
                            speciesClassType.Equals("Mammal")
                            || speciesClassType.Equals("Invertebrate")
                        )
                        {
                            CreateNewEnclosure(
                                modelBuilder,
                                enclosureId++,
                                speciesClassType,
                                animal.Trim().ToLower()
                            );
                        }
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
        string speciesClassType
    )
    {
        _logger.LogInformation(
            $"Creating Enclosure For {speciesClassType} with id: : {enclosureId}"
        );
        string enclosureName = null;
        if (speciesClassType.Equals("Bird"))
        {
            enclosureName = "Aviatory";
        }
        if (speciesClassType.Equals("Fish"))
        {
            enclosureName = "Aquarium";
        }
        if (speciesClassType.Equals("Reptile"))
        {
            enclosureName = "Reptile House";
        }
        if (speciesClassType.Equals("Amphibian"))
        {
            enclosureName = "Secret Life Of Amphibians";
        }
        if (speciesClassType.Equals("Insect"))
        {
            enclosureName = "Bugs Enclosure";
        }
        if (enclosureName != null)
        {
            var newEnclosure = new Enclosure { Id = enclosureId, Name = enclosureName };
            modelBuilder.Entity<Enclosure>().HasData(newEnclosure);
            _logger.LogInformation($"Completed creating enclosure");
        }
        else
        {
            _logger.LogWarning($"{speciesClassType} is Not valid. No Enclosure Creation");
        }
    }

    protected void CreateNewEnclosure(
        ModelBuilder modelBuilder,
        int enclosureId,
        string speciesClassType,
        string animalName
    )
    {
        if (speciesClassType.Equals("Mammal") || speciesClassType.Equals("Invertebrate"))
        {
            //Capitalizing the first letter
            var enclosureName = char.ToUpper(animalName[0]) + animalName[1..] + " Enclosure";
            var newEnclosure = new Enclosure { Id = enclosureId, Name = enclosureName };
            modelBuilder.Entity<Enclosure>().HasData(newEnclosure);
        }
    }
}
