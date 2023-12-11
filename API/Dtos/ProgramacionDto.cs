using Domain.Entities;

namespace API.Dtos;

public class ProgramacionDto :  BaseEntity
{
    

    public int ContratoId { get; set; }

    public int TurnoId { get; set; }

    public int EmpleadoId { get; set; }

    // public virtual Contrato Contrato { get; set; } = null!;

    // public virtual Persona Empleado { get; set; } = null!;

    // public virtual Turno Turno { get; set; } = null!;
}
