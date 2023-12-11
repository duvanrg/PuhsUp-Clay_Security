using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiContext _context;

        public UnitOfWork(ApiContext context)
        {
            _context = context;
        }


        private CategoriaperRepository _Categoriapers;
        private CiudadRepository _Ciudades;
        private ContactoperRepository _Contactopers;
        private ContratoRepository _Contratos;
        private DepartamentoRepository _Departamentos;
        private DirpersonaRepository _Dirpersonas;
        private EstadoRepository _Estados;
        private PaisRepository _Paises;
        private PersonaRepository _Personas;
        private ProgramacionRepository _Programaciones;
        private TipocontactoRepository _Tipocontactos;
        private TipodireccionRepository _Tipodirecciones;
        private TipopersonaRepository _Tipopersonas;
        private TurnoRepository _Turnos;

        public ICategoriaper categoriapers
        {
            get
            {
                if(_Categoriapers == null) _Categoriapers = new CategoriaperRepository(_context);
                return _Categoriapers;
            }
        }
        
        public ICiudad Ciudades
        {
            get
            {
                if(_Ciudades == null) _Ciudades = new CiudadRepository(_context);
                return _Ciudades;
            }
        }

        public IContactoper Contactopers
        {
            get
            {
                if(_Contactopers == null) _Contactopers = new ContactoperRepository(_context);
                return _Contactopers;
            }
        }
        
        public IContrato Contratos
        {
            get
            {
                if(_Contratos == null) _Contratos = new ContratoRepository(_context);
                return _Contratos;
            }
        }
        
        public IDepartamento Departamentos
        {
            get
            {
                if(_Departamentos == null) _Departamentos = new DepartamentoRepository(_context);
                return _Departamentos;
            }
        }
        
        public IDirpersona Dirpersonas
        {
            get
            {
                if(_Dirpersonas == null) _Dirpersonas = new DirpersonaRepository(_context);
                return _Dirpersonas;
            }
        }
        
        public IEstado Estados
        {
            get
            {
                if(_Estados == null) _Estados = new EstadoRepository(_context);
                return _Estados;
            }
        }
        
        public IPais Paises
        {
            get
            {
                if(_Paises == null) _Paises = new PaisRepository(_context);
                return _Paises;
            }
        }
        
        public IPersona Personas
        {
            get
            {
                if(_Personas == null) _Personas = new PersonaRepository(_context);
                return _Personas;
            }
        }
        
        public IProgramacion Programaciones
        {
            get
            {
                if(_Programaciones == null) _Programaciones = new ProgramacionRepository(_context);
                return _Programaciones;
            }
        }
        
        public ITipocontacto Tipocontactos  
        {
            get
            {
                if(_Tipocontactos == null) _Tipocontactos = new TipocontactoRepository(_context);
                return _Tipocontactos;
            }
        }
        
        public ITipodireccion Tipodirecciones
        {
            get
            {
                if(_Tipodirecciones == null) _Tipodirecciones = new TipodireccionRepository(_context);
                return _Tipodirecciones;
            }
        }
        
        public ITipopersona Tipopersonas
        {
            get
            {
                if(_Tipopersonas == null) _Tipopersonas = new TipopersonaRepository(_context);
                return _Tipopersonas;
            }
        }
        
        public ITurno Turnos
        {
            get
            {
                if(_Turnos == null) _Turnos = new TurnoRepository(_context);
                return _Turnos;
            }
        }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}