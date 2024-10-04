using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class DatabaseStateChangeRepository : IStateChangeRepository
    {

        //private readonly IDbContext _dbContext;

        //public DatabaseStateChangeRepository(IDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public void GuardarRegistro(StateChangeRecord registro)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<StateChangeRecord> ObtenerRegistros(DateTime fechaDesde, DateTime fechaHasta)
        {
            throw new NotImplementedException();
        }

    }
}
