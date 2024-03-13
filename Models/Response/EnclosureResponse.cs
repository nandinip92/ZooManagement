using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ZooManagement.Models.Data;

class EnclosureResponse
{
    public required int EnclosureId { get; set; }
    public required string EnclosureName { get; set; }
    public required string Classification { get; set; }
    // public List<Animal> Animals { get; set; }=[];
    public required int AnimalsCount{get;set;}
}
