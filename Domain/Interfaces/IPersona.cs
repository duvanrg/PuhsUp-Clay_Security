using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<Persona>> ListEmployees();
    Task<IEnumerable<Persona>> SelectVigilante();
    Task<IEnumerable<object>> SelectPhoneOfVigilante();
    Task<IEnumerable<Persona>> SelectClientsInBGA();
    Task<IEnumerable<Persona>> ListEmployeesInGrnAndPdc();
    Task<IEnumerable<Persona>> SelectClients5Years();
}
