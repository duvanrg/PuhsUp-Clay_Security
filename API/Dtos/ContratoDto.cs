using Domain.Entities;

namespace API.Dtos;

public class ContratoDto :  BaseEntity
{
    

    public int ClienteId { get; set; }

    public DateOnly FechaContrato { get; set; }

    public int EmpleadoId { get; set; }

    public DateOnly FechaFin { get; set; }

    public int EstatoId { get; set; }

    // public virtual Persona Cliente { get; set; } = null!;

    // public virtual Persona Empleado { get; set; } = null!;

    // public virtual Estado Estato { get; set; } = null!;

    // public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
