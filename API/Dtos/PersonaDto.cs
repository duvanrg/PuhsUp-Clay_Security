using Domain.Entities;

namespace API.Dtos;

public class PersonaDto :  BaseEntity
{
    

    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime DateReg { get; set; }

    public int TpersonaId { get; set; }

    public int CatId { get; set; }

    public int CiudadId { get; set; }

    // public virtual Categoriaper Cat { get; set; } = null!;

    // public virtual Ciudad Ciudad { get; set; } = null!;

    // public virtual ICollection<Contactoper> Contactopers { get; set; } = new List<Contactoper>();

    // public virtual ICollection<Contrato> ContratoClientes { get; set; } = new List<Contrato>();

    // public virtual ICollection<Contrato> ContratoEmpleados { get; set; } = new List<Contrato>();

    // public virtual ICollection<Dirpersona> Dirpersonas { get; set; } = new List<Dirpersona>();

    // public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();

    // public virtual Tipopersona Tpersona { get; set; } = null!;
}
