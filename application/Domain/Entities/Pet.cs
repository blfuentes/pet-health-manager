namespace application.Domain.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Species { get; set; } = default!;
    public string Breed { get; set; } = default!;
    public ICollection<Color> Colors { get; set; } = new HashSet<Color>();
    public DateTime Birth { get; set; }
    public DateTime? Death { get; set; }
    public DateTime Adoption { get; set; }
}
