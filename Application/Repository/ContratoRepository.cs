using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ContratoRepository : GenericRepository<Contrato>, IContrato
{
        private readonly ApiContext _context;
        public ContratoRepository(ApiContext context) : base(context)
        {
                _context = context;
        }

        public async Task<IEnumerable<object>> SelectContractIsActive()
        {
                return await (from C in _context.Contratos
                                join E in _context.Personas on C.EmpleadoId equals E.Id into EmpleadosGroup
                                from Empleados in EmpleadosGroup.DefaultIfEmpty()
                                join Cl in _context.Personas on C.ClienteId equals Cl.Id into ClientesGroup
                                from Clientes in ClientesGroup.DefaultIfEmpty()
                                where C.EstatoId == 1 
                                select new {
                                        NumeroContrato = C.Id,
                                        Cliente = Clientes.Nombre,
                                        Empleado = Empleados.Nombre
                                }
                                ).ToListAsync();
        }
}
