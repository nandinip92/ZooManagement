using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Enclosure
{
    public int Id { get; set; } // Enclosure Id
    public required string Name { get; set; } // Lion (10), Aviary (50), Reptile (40), Giraffe (6), Hippo (10)

    public required Classification Classification { get; set; }

    [InverseProperty(nameof(Animal.Enclosure))]
    public List<Animal> Animals { get; set; } = [];
}
