using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Turno : BaseEntity
{
    

    public string NombreTurno { get; set; } = null!;

    public DateOnly HoraTurnoI { get; set; }

    public DateOnly HoraTurnoF { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
