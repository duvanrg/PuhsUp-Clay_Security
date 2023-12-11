using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.profiles
{
    public class MappinProfiles : Profile
    {
        public MappinProfiles()
        {
            CreateMap <Categoriaper, CategoriaperDto > ().ReverseMap();
            CreateMap <Ciudad, CiudadDto > ().ReverseMap();
            CreateMap <Contactoper, ContactoperDto > ().ReverseMap();
            CreateMap <Contrato, ContratoDto > ().ReverseMap();
            CreateMap <Departamento, DepartamentoDto > ().ReverseMap();
            CreateMap <Dirpersona, DirpersonaDto > ().ReverseMap();
            CreateMap <Estado, EstadoDto > ().ReverseMap();
            CreateMap <Pais, PaisDto > ().ReverseMap();
            CreateMap <Persona, PersonaDto > ().ReverseMap();
            CreateMap <Programacion, ProgramacionDto > ().ReverseMap();
            CreateMap <Tipocontacto, TipocontactoDto > ().ReverseMap();
            CreateMap <Tipodireccion, TipodireccionDto > ().ReverseMap();
            CreateMap <Tipopersona, TipopersonaDto > ().ReverseMap();
            CreateMap <Turno, TurnoDto > ().ReverseMap();

            
            
        }
    }
}