namespace ZooManagement.Models.Response;

public class AnimalResponse
{
    public required int Id{get;set;}
    public required string Name { get; set; }
    public required string SpeciesName { get; set; }
    public required string Classification { get; set; }
    public required string Sex { get; set; }
    public required int EnclosureId{get;set;}
    public required string EnclosureName { get; set; }

    public DateTime? DateOfBirth { get; set; }
    public required DateTime DateOfAcquisition { get; set; }
}
