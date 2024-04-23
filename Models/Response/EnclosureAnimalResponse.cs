namespace ZooManagement.Models.Response;

public class EnclosureAnimalResponse
{
    public required int AnimalId { get; set; }
    public required string AnimalName { get; set; }
    public required string Sex { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public required DateTime DateOfAcquisition { get; set; }
}
