using Domain.Entities;

namespace API.Dtos;

public class ContactoperDto :  BaseEntity
{
    public string Descripcion { get; set; } = null!;

    public int PersonaId { get; set; }

    public int TcontactoId { get; set; }

    // public virtual Persona Persona { get; set; } = null!;

    // public virtual Tipocontacto Tcontacto { get; set; } = null!;
}
