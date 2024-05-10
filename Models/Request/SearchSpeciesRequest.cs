using ZooManagement.Enums;

namespace ZooManagement.Models.Request;

public class SearchSpeciesRequest
{
    public Classification? Classification { get; set; }

    public string? SearchSpecies { get; set; }
}
