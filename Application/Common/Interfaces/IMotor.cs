using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IMotor
    {
        void Configurar(int potencia, Direccion direccion);
        void Detener();
    }
}
