using Application.Common.Interfaces;
using Domain.Common;
using Domain.Enums;
using System;

namespace PracticoTrabajoDeDiploma.Controllers
{
    public class RobotController
    {
        private readonly IControladorMovimiento _controladorMovimiento;
        private readonly IStateChangeRepository _stateChangeRepository;

        public SensorState LecturaSensorIzquierdo { get; private set; }
        public SensorState LecturaSensorDerecho { get; private set; }
        public string AccionActual { get; private set; }

        private StateChangeRecord _ultimoRegistro;

        public RobotController(IControladorMovimiento controladorMovimiento, IStateChangeRepository stateChangeRepository)
        {
            _controladorMovimiento = controladorMovimiento;
            _stateChangeRepository = stateChangeRepository;
        }

        public void ActualizarEstado(SensorState lecturaIzquierda, SensorState lecturaDerecha)
        {
            LecturaSensorIzquierdo = lecturaIzquierda;
            LecturaSensorDerecho = lecturaDerecha;

            var nuevoRegistro = new StateChangeRecord
            {
                FechaHora = DateTime.Now,
                ValorSensor1 = LecturaSensorIzquierdo,
                ValorSensor2 = LecturaSensorDerecho
            };

            // Verificar si hubo un cambio de estado
            if (_ultimoRegistro == null ||
                _ultimoRegistro.ValorSensor1 != nuevoRegistro.ValorSensor1 ||
                _ultimoRegistro.ValorSensor2 != nuevoRegistro.ValorSensor2)
            {
                // Guardar el nuevo registro
                _stateChangeRepository.GuardarRegistro(nuevoRegistro);
                _ultimoRegistro = nuevoRegistro;
            }

            // Obtener el movimiento y actualizar la acción actual
            var movimiento = _controladorMovimiento.DeterminarMovimiento(LecturaSensorIzquierdo, LecturaSensorDerecho);
            AccionActual = ObtenerDescripcionAccion(movimiento);
        }

        private string ObtenerDescripcionAccion(Movimiento movimiento)
        {
            if (movimiento.EmitirSonido)
                return "Retroceder y emitir sonido";

            if (movimiento.DireccionMotorIzquierdo == Direccion.Adelante && movimiento.DireccionMotorDerecho == Direccion.Adelante)
                return "Avanzar";

            if (movimiento.DireccionMotorIzquierdo == Direccion.Atras && movimiento.DireccionMotorDerecho == Direccion.Adelante)
                return "Girar a la izquierda";

            if (movimiento.DireccionMotorIzquierdo == Direccion.Adelante && movimiento.DireccionMotorDerecho == Direccion.Atras)
                return "Girar a la derecha";

            return "Acción desconocida";
        }
    }
}
