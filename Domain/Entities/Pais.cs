using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Pais : BaseEntity
{
    

    public string NombrePais { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
