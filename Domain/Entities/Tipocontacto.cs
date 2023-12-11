using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Tipocontacto : BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Contactoper> Contactopers { get; set; } = new List<Contactoper>();
}
