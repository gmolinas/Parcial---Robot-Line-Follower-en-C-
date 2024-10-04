using Application.Common.Interfaces;
using Application.UseCase;
using Domain.Enums;
using Infrastructure.Services;
using PracticoTrabajoDeDiploma.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Common;

namespace PracticoTrabajoDeDiploma
{
    public partial class Form1 : Form
    {

        private RobotController _robotController;
        private StateChangeService _stateChangeService;

        public Form1()
        {
            InitializeComponent();
            InicializarDependencias();
            ConfigurarEventos();
        }

        private void InicializarDependencias()
        {
            // Creación de instancias de lógica
            IControladorMovimiento controladorMovimiento = new ControladorMovimiento();
            IStateChangeRepository stateChangeRepository = new BinaryFileStateChangeRepository();

            // Creación del controlador del robot
            _robotController = new RobotController(controladorMovimiento, stateChangeRepository);

            // Creación del servicio de registros
            _stateChangeService = new StateChangeService(stateChangeRepository);
        }
        private void ConfigurarEventos()
        {
            btnSensorIzquierdoNegro.Click += BtnSensorIzquierdoNegro_Click;
            btnSensorIzquierdoBlanco.Click += BtnSensorIzquierdoBlanco_Click;
            btnSensorDerechoNegro.Click += BtnSensorDerechoNegro_Click;
            btnSensorDerechoBlanco.Click += BtnSensorDerechoBlanco_Click;
            btnBuscarRegistros.Click += BtnBuscarRegistros_Click;
        }

        private void BtnSensorIzquierdoNegro_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSensores(SensorState.Negro, _robotController.LecturaSensorDerecho);
        }

        private void BtnSensorIzquierdoBlanco_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSensores(SensorState.Blanco, _robotController.LecturaSensorDerecho);
        }

        private void BtnSensorDerechoNegro_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSensores(_robotController.LecturaSensorIzquierdo, SensorState.Negro);
        }

        private void BtnSensorDerechoBlanco_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSensores(_robotController.LecturaSensorIzquierdo, SensorState.Blanco);
        }

        private void ActualizarEstadoSensores(SensorState sensorIzquierdo, SensorState sensorDerecho)
        {
            _robotController.ActualizarEstado(sensorIzquierdo, sensorDerecho);
            ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            lblSensorIzquierdo.Text = _robotController.LecturaSensorIzquierdo.ToString();
            lblSensorDerecho.Text = _robotController.LecturaSensorDerecho.ToString();
            lblAccion.Text = _robotController.AccionActual;
        }

        private void BtnBuscarRegistros_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpFechaDesde.Value.Date;
            DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1);
            var registros = _stateChangeService.ObtenerRegistros(fechaDesde, fechaHasta);

            lstRegistros.Items.Clear();
            foreach (var registro in registros)
            {
                var item = new ListViewItem(registro.FechaHora.ToString());
                item.SubItems.Add(registro.ValorSensor1.ToString());
                item.SubItems.Add(registro.ValorSensor2.ToString());
                lstRegistros.Items.Add(item);
            }
        }
    }
}
