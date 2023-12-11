using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Dirpersona : BaseEntity
{
    

    public string Direccion { get; set; } = null!;

    public int PersonaId { get; set; }

    public int TdireccionId { get; set; }

    public virtual Persona Persona { get; set; } = null!;

    public virtual Tipodireccion Tdireccion { get; set; } = null!;
}
