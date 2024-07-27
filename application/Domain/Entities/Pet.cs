namespace application.Domain.Entities;

public class Pet
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Species { get; set; }

    public required string Breed { get; set; }

    public ICollection<Color> Colors { get; set; } = new HashSet<Color>();

    public ICollection<WeightRegistry> WeightRegistries { get; set; } = new HashSet<WeightRegistry>();

    public DateTime Birth { get; set; }

    public DateTime? Death { get; set; }

    public DateTime Adoption { get; set; }

    public required string ImgContent { get; set; }
}
