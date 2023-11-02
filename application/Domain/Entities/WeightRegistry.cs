namespace application.Domain.Entities;

public class WeightRegistry
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public DateTime Date { get; set; }
    public int Weight { get; set; }
    public Pet Pet { get; set; } = default!;
}
