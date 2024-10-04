using Application.Common.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Infrastructure.Services
{
    public class BinaryFileStateChangeRepository : IStateChangeRepository
    {
        private readonly string _rutaArchivo = "./mision.bin";

        public void GuardarRegistro(StateChangeRecord registro)
        {
            using (FileStream fs = new FileStream(_rutaArchivo, FileMode.Append))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, registro);
            }
        }

        public IEnumerable<StateChangeRecord> ObtenerRegistros(DateTime fechaDesde, DateTime fechaHasta)
        {
            var registros = new List<StateChangeRecord>();

            if (!File.Exists(_rutaArchivo))
                return registros;

            using (FileStream fs = new FileStream(_rutaArchivo, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                while (fs.Position < fs.Length)
                {
                    var registro = (StateChangeRecord)formatter.Deserialize(fs);
                    if (registro.FechaHora >= fechaDesde && registro.FechaHora <= fechaHasta)
                    {
                        registros.Add(registro);
                    }
                }
            }

            return registros;
        }
    }
}
