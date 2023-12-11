using Domain.Entities;

namespace API.Dtos;

public class CiudadDto :  BaseEntity
{
    

    public string NombreCiu { get; set; } = null!;

    public int DepId { get; set; }

    // public virtual DepartamentoDto Dep { get; set; } = null!;

    // public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
