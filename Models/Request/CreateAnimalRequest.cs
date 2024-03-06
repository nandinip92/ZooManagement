using ZooManagement.Enums;
namespace ZooManagement.Models.Request;

public class CreateAnimalRequest
{
    public required string Name { get; set; }
    public required int SpeciesId { get; set; }
    public required Sex Sex { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public required DateTime DateOfAcquisition { get; set; }
}