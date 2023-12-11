using Domain.Entities;

namespace API.Dtos;

public class TipodireccionDto :  BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    // public virtual ICollection<Dirpersona> Dirpersonas { get; set; } = new List<Dirpersona>();
}
