using System.ComponentModel.DataAnnotations.Schema;

namespace application.Domain.Entities;

[Table("WeightRegistries")]
public class WeightRegistry
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public DateTime Date { get; set; }
    public int Weight { get; set; }
    public Pet Pet { get; set; } = default!;
}
