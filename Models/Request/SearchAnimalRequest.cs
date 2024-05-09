using System.ComponentModel;
using CsvHelper.Configuration.Attributes;
using ZooManagement.Enums;

namespace ZooManagement.Models.Request;

public class SearchAnimalRequest
{
    [DefaultValue(1)]
    public int PageNumber { get; set; } = 1;

    [DefaultValue(10)]
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } //AnimalName|| SpeciesName || Classification || Sex
    public bool? SortOrder { get; set; }
}
