using Domain.Entities;

namespace API.Dtos;

public class TipocontactoDto :  BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    // public virtual ICollection<Contactoper> Contactopers { get; set; } = new List<Contactoper>();
}
