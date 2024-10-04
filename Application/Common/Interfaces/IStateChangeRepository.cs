using Domain.Common;
using System;
using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface IStateChangeRepository
    {
        void GuardarRegistro(StateChangeRecord registro);
        IEnumerable<StateChangeRecord> ObtenerRegistros(DateTime fechaDesde, DateTime fechaHasta);
    }
}
