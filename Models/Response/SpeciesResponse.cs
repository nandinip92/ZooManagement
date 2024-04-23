namespace ZooManagement.Models.Data;

class SpeciesResponse
{
    public required int SpeciesId { get; set; }
    public required string SpeciesName { get; set; }
    
    public required AnimalListResponse Animals{get;set;}
}