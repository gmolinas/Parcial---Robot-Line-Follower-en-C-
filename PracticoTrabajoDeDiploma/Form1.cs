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
using Infrastructure.Tools;
using System.Configuration;

namespace PracticoTrabajoDeDiploma
{
    public partial class Form1 : Form, IObserver
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
            _robotController.Attach(this);

            // Creación del servicio de registros
            _stateChangeService = new StateChangeService(stateChangeRepository);
        }

        public void Update()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ActualizarInterfaz));
            }
            else
            {
                ActualizarInterfaz();
            }
        }

        private void ConfigurarEventos()
        {
            btnSensorIzquierdoNegro.Click += BtnSensor_Click;
            btnSensorIzquierdoBlanco.Click += BtnSensor_Click;
            btnSensorDerechoNegro.Click += BtnSensor_Click;
            btnSensorDerechoBlanco.Click += BtnSensor_Click;
            btnBuscarRegistros.Click += BtnSensor_Click;
        }

        private void BtnSensor_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            SensorState sensorIzquierdo = _robotController.LecturaSensorIzquierdo;
            SensorState sensorDerecho = _robotController.LecturaSensorDerecho;

            // Determinar qué botón fue presionado utilizando su Name o Tag
            switch (button.Name)
            {
                case "btnSensorIzquierdoNegro":
                    sensorIzquierdo = SensorState.Negro;
                    break;
                case "btnSensorIzquierdoBlanco":
                    sensorIzquierdo = SensorState.Blanco;
                    break;
                case "btnSensorDerechoNegro":
                    sensorDerecho = SensorState.Negro;
                    break;
                case "btnSensorDerechoBlanco":
                    sensorDerecho = SensorState.Blanco;
                    break;
            }

            ActualizarEstadoSensores(sensorIzquierdo, sensorDerecho);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Desuscribir la UI al cerrar el formulario
            _robotController.Detach(this);
            base.OnFormClosing(e);
        }


        private void BtnBuscarRegistros_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = dtpFechaDesde.Value.Date;
            DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1);
            var registros = _stateChangeService.ObtenerRegistros(fechaDesde, fechaHasta);

            lstRegistros.Items.Clear();
            foreach (var registro in registros)
            {
                var item = new ListViewItem($"{registro.FechaHora.ToString()}, S1:[{registro.ValorSensor1.ToString()}], S2 [{registro.ValorSensor2.ToString()}] -");
                lstRegistros.Items.Add(item);
            }
        }
    }
}
