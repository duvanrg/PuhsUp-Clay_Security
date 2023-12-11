using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Tipopersona : BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
