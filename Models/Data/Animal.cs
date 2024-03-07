using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Animal
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int SpeciesId { get; set; }

    [ForeignKey(nameof(SpeciesId))]
    public Species Species { get; set; } = null!;

    public int EnclosureId{get;set;}
    [ForeignKey(nameof(Enclosure.Id))]
    public required Sex Sex { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public required DateTime DateOfAcquisition { get; set; }
}
