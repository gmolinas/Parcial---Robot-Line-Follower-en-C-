using Application.Common.Interfaces;
using Domain.Common;
using Domain.Enums;

namespace Application.UseCase
{
    public class ControladorMovimiento : IControladorMovimiento
    {
        public Movimiento DeterminarMovimiento(SensorState sensorIzquierdo, SensorState sensorDerecho)
        {
            if (sensorIzquierdo == SensorState.Negro && sensorDerecho == SensorState.Negro)
            {
                // Caso 1: Avanzar
                return new Movimiento
                {
                    PotenciaMotorIzquierdo = 100,
                    PotenciaMotorDerecho = 100,
                    DireccionMotorIzquierdo = Direccion.Adelante,
                    DireccionMotorDerecho = Direccion.Adelante,
                    EmitirSonido = false
                };
            }
            else if (sensorIzquierdo == SensorState.Negro && sensorDerecho == SensorState.Blanco)
            {
                // Caso 2: Girar a la izquierda
                return new Movimiento
                {
                    PotenciaMotorIzquierdo = 50,
                    PotenciaMotorDerecho = 50,
                    DireccionMotorIzquierdo = Direccion.Atras,
                    DireccionMotorDerecho = Direccion.Adelante,
                    EmitirSonido = false
                };
            }
            else if (sensorIzquierdo == SensorState.Blanco && sensorDerecho == SensorState.Negro)
            {
                // Caso 3: Girar a la derecha
                return new Movimiento
                {
                    PotenciaMotorIzquierdo = 50,
                    PotenciaMotorDerecho = 50,
                    DireccionMotorIzquierdo = Direccion.Adelante,
                    DireccionMotorDerecho = Direccion.Atras,
                    EmitirSonido = false
                };
            }
            else
            {
                // Caso 4: Retroceder y emitir sonido
                return new Movimiento
                {
                    PotenciaMotorIzquierdo = 50,
                    PotenciaMotorDerecho = 50,
                    DireccionMotorIzquierdo = Direccion.Atras,
                    DireccionMotorDerecho = Direccion.Atras,
                    EmitirSonido = true
                };
            }
        }
    }
}
