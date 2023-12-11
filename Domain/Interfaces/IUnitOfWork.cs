namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriaper categoriapers { get; }
        ICiudad Ciudades { get; }
        IContactoper Contactopers { get; }
        IContrato Contratos { get; }
        IDepartamento Departamentos { get; }
        IDirpersona Dirpersonas { get; }
        IEstado Estados { get; }
        IPais Paises { get; }
        IPersona Personas { get; }
        IProgramacion Programaciones { get; }
        ITipocontacto Tipocontactos { get; }
        ITipodireccion Tipodirecciones { get; }
        ITurno Turnos { get; }

        Task<int> SaveAsync();
    }
}