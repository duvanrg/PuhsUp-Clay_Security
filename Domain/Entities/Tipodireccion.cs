using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Tipodireccion : BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Dirpersona> Dirpersonas { get; set; } = new List<Dirpersona>();
}
