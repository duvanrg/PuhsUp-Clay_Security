using Domain.Entities;

namespace API.Dtos;

public class DirpersonaDto :  BaseEntity
{
    

    public string Direccion { get; set; } = null!;

    public int PersonaId { get; set; }

    public int TdireccionId { get; set; }

    // public virtual Persona Persona { get; set; } = null!;

    // public virtual Tipodireccion Tdireccion { get; set; } = null!;
}
