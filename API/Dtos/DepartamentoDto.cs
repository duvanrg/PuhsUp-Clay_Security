using Domain.Entities;

namespace API.Dtos;

public class DepartamentoDto :  BaseEntity
{
    

    public string NombreDep { get; set; } = null!;

    public int PaisId { get; set; }

    // public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    // public virtual Pais Pais { get; set; } = null!;
}
