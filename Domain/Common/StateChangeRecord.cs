using Domain.Enums;
using System;

namespace Domain.Common
{
    [Serializable]
    public class StateChangeRecord
    {
        public DateTime FechaHora { get; set; }
        public SensorState ValorSensor1 { get; set; }
        public SensorState ValorSensor2 { get; set; }
    }
}
