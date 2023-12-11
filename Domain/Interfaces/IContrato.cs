using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IContrato : IGenericRepository<Contrato>
{
    Task<IEnumerable<object>> SelectContractIsActive();
}
