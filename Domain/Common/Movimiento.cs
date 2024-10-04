using Domain.Enums;

namespace Domain.Common
{
    public class Movimiento
    {
        public int PotenciaMotorIzquierdo { get; set; }
        public int PotenciaMotorDerecho { get; set; }
        public Direccion DireccionMotorIzquierdo { get; set; }
        public Direccion DireccionMotorDerecho { get; set; }
        public bool EmitirSonido { get; set; }
    }
}
