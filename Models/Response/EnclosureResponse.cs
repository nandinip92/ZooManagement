namespace ZooManagement.Models.Response;

class EnclosureResponse
{
    public required int EnclosureId { get; set; }
    public required string EnclosureName { get; set; }

    public required string Classification { get; set; }
    public required int AnimalsCount { get; set; }
    public required List<string> Animals { get; set; }
}
