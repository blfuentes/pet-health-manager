using application.Domain.Entities;
using application.Infrastructure;

namespace application.Data;

public static class DbInitializer
{
    public static void Initialize(ApiDbContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Pets.Any())
        {
            return;   // DB has been seeded
        }
        var petColors = new Color[]
        {
            new Color() { Id = 1, Name = "Negro" },
            new Color() { Id = 2, Name = "Blanco" },
            new Color() { Id = 3, Name = "Marrón" },
            new Color() { Id = 4, Name = "Gris" }
        };
        context.PetColors.AddRange(petColors);
        context.SaveChanges();

        var pets = new Pet[]
        {
            new Pet()
            {
                Name = "Lester",
                Species = "Cobaya",
                Breed = "Abisinia",
                Adoption = new DateTime(year: 2022, month: 2, day: 24),
                Birth = new DateTime(year: 2021, month: 9, day: 1),
                Colors = new List<Color>(){ context.PetColors.Find(1), context.PetColors.Find(3), context.PetColors.Find(2) }
            },
            new Pet()
            {
                Name = "Paul",
                Species = "Cobaya",
                Breed = "Abisinia",
                Adoption = new DateTime(year: 2022, month: 2, day: 24),
                Birth = new DateTime(year: 2021, month: 11, day: 1),
                Colors = new List<Color>(){ context.PetColors.Find(1), context.PetColors.Find(2) }
            },
            new Pet()
            {
                Name = "Burrito",
                Species = "Hámster",
                Breed = "Roborovski",
                Adoption = new DateTime(year: 2022, month: 8, day: 24),
                Birth = new DateTime(year: 2022, month: 7, day: 1),
                Colors = new List<Color>(){ context.PetColors.Find(3), context.PetColors.Find(2) }
            },
            new Pet()
            {
                Name = "Piolla",
                Species = "Hámster",
                Breed = "Roborovski",
                Adoption = new DateTime(year: 2022, month: 10, day: 2),
                Birth = new DateTime(year: 2022, month: 9, day: 15),
                Death = new DateTime(year: 2022, month: 10, day: 8),
                Colors = new List<Color>(){ context.PetColors.Find(2), context.PetColors.Find(4) }
            },
            new Pet()
            {
                Name = "Morriña",
                Species = "Hámster",
                Breed = "Ruso",
                Adoption = new DateTime(year: 2022, month: 10, day: 15),
                Birth = new DateTime(year: 2022, month: 5, day: 23),
                Death = new DateTime(year: 2023, month: 5, day: 11),
                Colors = new List<Color>(){ context.PetColors.Find(4), context.PetColors.Find(2) }
            }
        };
        context.Pets.AddRange(pets);

        context.SaveChanges();
    }
}
