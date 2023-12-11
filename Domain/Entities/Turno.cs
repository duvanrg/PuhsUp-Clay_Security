using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Turno : BaseEntity
{
    

    public string NombreTurno { get; set; } = null!;

    public DateTime HoraTurnoI { get; set; }

    public DateTime HoraTurnoF { get; set; }

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
