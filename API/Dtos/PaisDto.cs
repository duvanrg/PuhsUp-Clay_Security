using Domain.Entities;

namespace API.Dtos;

public class PaisDto :  BaseEntity
{
    

    public string NombrePais { get; set; } = null!;

    // public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
