using System.ComponentModel;
using System.Text.Json.Serialization;

namespace application.Domain.Entities;

public class EventAnnotation
{
    public int Id { get; set; }

    public int PetId { get; set; }

    public DateTime Date { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EventAnnotationType EventType { get; set; }

    public string? Note { get; set; }

    public virtual required Pet Pet { get; set; }
}

public enum EventAnnotationType
{
    [Description("Birth")]
    Birth,
    [Description("Death")]
    Death,
    [Description("Adoption")]
    Adoption,
    [Description("Nail trimming")]
    NailTrimming,
    [Description("Vet visit")]
    VetVisit,
    [Description("Grooming")]
    Grooming,
    [Description("Other")]
    Other
}