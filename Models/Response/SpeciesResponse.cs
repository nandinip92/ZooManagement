namespace ZooManagement.Models.Response;

class SpeciesResponse
{
    public required int SpeciesId { get; set; }
    public required string SpeciesName { get; set; }
    
    public required EnclosureResponse Enclosure{get;set;}
}