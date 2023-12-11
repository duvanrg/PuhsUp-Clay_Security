using Domain.Entities;

namespace API.Dtos;

public class TipopersonaDto :  BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    // public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
