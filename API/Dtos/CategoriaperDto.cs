using Domain.Entities;

namespace API.Dtos;

public class CategoriaperDto : BaseEntity
{
    public string NombreCat { get; set; } = null!;

    // public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
