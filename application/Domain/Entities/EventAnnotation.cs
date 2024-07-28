namespace application.Domain.Entities;

public class EventAnnotation
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public DateTime Date { get; set; }

    public EventType EventType { get; set; }

    public string? Note { get; set; }

    public virtual required Pet Pet { get; set; }
}

public enum EventType
{
    Birth,
    Death,
    Adoption,
    NailTrimming,
    VetVisit,
    Grooming,
    Other
}