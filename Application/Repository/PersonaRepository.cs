using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
        private readonly ApiContext _context;
        public PersonaRepository(ApiContext context) : base(context)
        {
                _context = context;
        }

        public async Task<IEnumerable<Persona>> ListEmployees()
        {
                return await (from P in _context.Personas
                              where P.TpersonaId != 1
                              select P).ToListAsync();
        }
        public async Task<IEnumerable<Persona>> SelectVigilante()
        {
                return await (from P in _context.Personas
                                      // join Tp in _context.Tipopersonas on p.TpersonaId equals Tp.Id
                                      // where p.Descripcion == "Vigilante"
                              where P.TpersonaId == 3
                              select P).ToListAsync();
        }
        public async Task<IEnumerable<object>> SelectPhoneOfVigilante()
        {
                return await (from Cp in _context.Contactopers
                              join p in _context.Personas on Cp.PersonaId equals p.Id
                              where Cp.TcontactoId == 1 && p.TpersonaId == 3
                              select new
                              {
                                      p.IdPersona,
                                      p.Nombre,
                                      Cp.Descripcion
                              }
                                ).ToListAsync();
        }
        public async Task<IEnumerable<Persona>> SelectClientsInBGA()
        {
                return await (from P in _context.Personas
                              where P.CiudadId == 1 && P.TpersonaId == 1
                              select P).ToListAsync();
        }
        public async Task<IEnumerable<Persona>> ListEmployeesInGrnAndPdc()
        {
                return await (from P in _context.Personas
                              where P.TpersonaId != 1 && P.CiudadId == 3 || P.CiudadId == 4
                              select P).ToListAsync();
        }
        public async Task<IEnumerable<Persona>> SelectClients5Years()
        {
                return await (from P in _context.Personas
                              where P.DateReg <= DateTime.Now.AddYears(-5) && P.TpersonaId == 1
                              select P).ToListAsync();
        }
}
