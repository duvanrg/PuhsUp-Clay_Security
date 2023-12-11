using Domain.Entities;

namespace API.Dtos;

public class EstadoDto :  BaseEntity
{
    

    public string Descripcion { get; set; } = null!;

    // public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
