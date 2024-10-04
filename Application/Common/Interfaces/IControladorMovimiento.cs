using Domain.Common;
using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IControladorMovimiento
    {
        Movimiento DeterminarMovimiento(SensorState sensorIzquierdo, SensorState sensorDerecho);
    }
}
