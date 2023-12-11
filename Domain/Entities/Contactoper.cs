using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Contactoper : BaseEntity
{
    public string Descripcion { get; set; } = null!;

    public int PersonaId { get; set; }

    public int TcontactoId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Tipocontacto Tcontacto { get; set; } = null!;
}
