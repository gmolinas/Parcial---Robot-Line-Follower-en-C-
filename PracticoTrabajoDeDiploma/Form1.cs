using Application.Common.Interfaces;
using Application.UseCase;
using Domain.Enums;
using Infrastructure.Services;
using PracticoTrabajoDeDiploma.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticoTrabajoDeDiploma
{
    public partial class Form1 : Form, IObserver
    {
        private Panel simulationPanel;
        private RobotController _robotController;
        private StateChangeService _stateChangeService;
        private System.Windows.Forms.Timer timer;
        private int backgroundOffsetX = 0;
        private int backgroundOffsetY = 0;
        private string lastAction = "";

        public Form1()
        {
            InitializeComponent();
            InicializarDependencias();
            ConfigurarEventos();

            // Configuración del formulario
            this.ClientSize = new Size(800, 400);
            this.DoubleBuffered = true;

            // Creación del panel de simulación
            simulationPanel = new Panel
            {
                Location = new Point(150,200),
                Size = new Size(150, 150),
                BorderStyle = BorderStyle.FixedSingle
            };
            simulationPanel.DoubleBuffered(true);
            this.Controls.Add(simulationPanel);

            // Suscripción al evento Paint del panel
            simulationPanel.Paint += SimulationPanel_Paint;

            // Inicialización del temporizador
            timer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            timer.Tick += Timer_Tick;
            timer.Start();
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
            btnBuscarRegistros.Click += BtnBuscarRegistros_Click;
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
            // La interfaz se actualizará a través del patrón Observer
        }

        private void ActualizarInterfaz()
        {
            lblSensorIzquierdo.Text = _robotController.LecturaSensorIzquierdo.ToString();
            lblSensorDerecho.Text = _robotController.LecturaSensorDerecho.ToString();
            lblAccion.Text = _robotController.AccionActual;

            lastAction = _robotController.AccionActual;
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
                var item = new ListViewItem($"{registro.FechaHora}, S1: [{registro.ValorSensor1}], S2: [{registro.ValorSensor2}]");
                lstRegistros.Items.Add(item);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var movimiento = _robotController.MovimientoActual;
            if (movimiento != null)
            {
                // Configuraciones de los motores
                int potenciaIzquierda = movimiento.PotenciaMotorIzquierdo;
                int potenciaDerecha = movimiento.PotenciaMotorDerecho;
                Direccion direccionIzquierda = movimiento.DireccionMotorIzquierdo;
                Direccion direccionDerecha = movimiento.DireccionMotorDerecho;

                // Calcular velocidad (ajusta el divisor para controlar la velocidad en la UI)
                int velocidad = (potenciaIzquierda + potenciaDerecha) / 20;

                // Ajustar desplazamiento del fondo
                if (direccionIzquierda == Direccion.Adelante && direccionDerecha == Direccion.Adelante)
                {
                    // Avanzar
                    backgroundOffsetY += velocidad;
                }
                else if (direccionIzquierda == Direccion.Atras && direccionDerecha == Direccion.Atras)
                {
                    // Retroceder
                    backgroundOffsetY -= velocidad;
                }
                else if (direccionIzquierda == Direccion.Atras && direccionDerecha == Direccion.Adelante)
                {
                    // Girar a la izquierda
                    backgroundOffsetX += velocidad;
                    backgroundOffsetY += velocidad;
                }
                else if (direccionIzquierda == Direccion.Adelante && direccionDerecha == Direccion.Atras)
                {
                    // Girar a la derecha
                    backgroundOffsetX -= velocidad;
                    backgroundOffsetY += velocidad;
                }
            }

            // Asegurar que los desplazamientos estén dentro de los límites
            backgroundOffsetX = backgroundOffsetX % simulationPanel.Width;
            backgroundOffsetY = backgroundOffsetY % simulationPanel.Height;

            simulationPanel.Invalidate();
        }

        private void SimulationPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Gray, 1);

            // Tamaño del patrón del fondo
            int patternSize = 25;

            // Dibujar líneas verticales
            for (int x = -patternSize + (backgroundOffsetX % patternSize); x < simulationPanel.Width; x += patternSize)
            {
                g.DrawLine(pen, x, 0, x, simulationPanel.Height);
            }

            // Dibujar líneas horizontales
            for (int y = -patternSize + (backgroundOffsetY % patternSize); y < simulationPanel.Height; y += patternSize)
            {
                g.DrawLine(pen, 0, y, simulationPanel.Width, y);
            }

            // Dibujar el auto estático en el centro inferior del panel
            int carWidth = 40;
            int carHeight = 60;
            int carX = simulationPanel.Width / 2 - carWidth / 2;
            int carY = simulationPanel.Height - carHeight - 10;

            Brush carBrush = Brushes.Red;
            g.FillRectangle(carBrush, carX, carY, carWidth, carHeight);

            pen.Dispose();
        }
    }

    // Extensión para habilitar DoubleBuffered en controles
    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(control, enable, null);
        }
    }
}
