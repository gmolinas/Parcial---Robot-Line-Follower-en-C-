using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class StateChangeService
    {
        private readonly IStateChangeRepository _repository;

        public StateChangeService(IStateChangeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<StateChangeRecord> ObtenerRegistros(DateTime fechaDesde, DateTime fechaHasta)
        {
            return _repository.ObtenerRegistros(fechaDesde, fechaHasta);
        }
    }
}
