using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Species
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int EnclosureId{get;set;}
    [ForeignKey (nameof(Enclosure.Id))]
    public required Classification Classification { get; set; }
    
}
