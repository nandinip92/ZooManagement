using System.ComponentModel.DataAnnotations.Schema;
using ZooManagement.Enums;

namespace ZooManagement.Models.Data;

public class Species
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required Classification Classification { get; set; }

    public int EnclosureId { get; set; }

    [ForeignKey(nameof(EnclosureId))]
    public Enclosure Enclosure { get; set; } = null!;
}
