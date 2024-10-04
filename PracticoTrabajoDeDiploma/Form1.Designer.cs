namespace PracticoTrabajoDeDiploma
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controles de la interfaz
        private System.Windows.Forms.Button btnSensorIzquierdoNegro;
        private System.Windows.Forms.Button btnSensorIzquierdoBlanco;
        private System.Windows.Forms.Button btnSensorDerechoNegro;
        private System.Windows.Forms.Button btnSensorDerechoBlanco;
        private System.Windows.Forms.Label lblSensorIzquierdo;
        private System.Windows.Forms.Label lblSensorDerecho;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Button btnBuscarRegistros;
        private System.Windows.Forms.ListView lstRegistros;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSensorIzquierdoNegro = new System.Windows.Forms.Button();
            this.btnSensorIzquierdoBlanco = new System.Windows.Forms.Button();
            this.btnSensorDerechoNegro = new System.Windows.Forms.Button();
            this.btnSensorDerechoBlanco = new System.Windows.Forms.Button();
            this.btnBuscarRegistros = new System.Windows.Forms.Button();
            this.lblSensorIzquierdo = new System.Windows.Forms.Label();
            this.lblSensorDerecho = new System.Windows.Forms.Label();
            this.lblAccion = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.lstRegistros = new System.Windows.Forms.ListView();
            this.LblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSensorIzquierdoNegro
            // 
            this.btnSensorIzquierdoNegro.Location = new System.Drawing.Point(62, 105);
            this.btnSensorIzquierdoNegro.Name = "btnSensorIzquierdoNegro";
            this.btnSensorIzquierdoNegro.Size = new System.Drawing.Size(151, 32);
            this.btnSensorIzquierdoNegro.TabIndex = 0;
            this.btnSensorIzquierdoNegro.Text = "btnSensorIzquierdoNegro";
            this.btnSensorIzquierdoNegro.UseVisualStyleBackColor = true;
            this.btnSensorIzquierdoNegro.Click += new System.EventHandler(this.BtnSensor_Click);
            // 
            // btnSensorIzquierdoBlanco
            // 
            this.btnSensorIzquierdoBlanco.Location = new System.Drawing.Point(62, 152);
            this.btnSensorIzquierdoBlanco.Name = "btnSensorIzquierdoBlanco";
            this.btnSensorIzquierdoBlanco.Size = new System.Drawing.Size(151, 32);
            this.btnSensorIzquierdoBlanco.TabIndex = 1;
            this.btnSensorIzquierdoBlanco.Text = "btnSensorIzquierdoBlanco";
            this.btnSensorIzquierdoBlanco.UseVisualStyleBackColor = true;
            this.btnSensorIzquierdoBlanco.Click += new System.EventHandler(this.BtnSensor_Click);
            // 
            // btnSensorDerechoNegro
            // 
            this.btnSensorDerechoNegro.Location = new System.Drawing.Point(219, 105);
            this.btnSensorDerechoNegro.Name = "btnSensorDerechoNegro";
            this.btnSensorDerechoNegro.Size = new System.Drawing.Size(151, 32);
            this.btnSensorDerechoNegro.TabIndex = 0;
            this.btnSensorDerechoNegro.Text = "btnSensorDerechoNegro";
            this.btnSensorDerechoNegro.UseVisualStyleBackColor = true;
            this.btnSensorDerechoNegro.Click += new System.EventHandler(this.BtnSensor_Click);
            // 
            // btnSensorDerechoBlanco
            // 
            this.btnSensorDerechoBlanco.Location = new System.Drawing.Point(219, 152);
            this.btnSensorDerechoBlanco.Name = "btnSensorDerechoBlanco";
            this.btnSensorDerechoBlanco.Size = new System.Drawing.Size(151, 32);
            this.btnSensorDerechoBlanco.TabIndex = 0;
            this.btnSensorDerechoBlanco.Text = "btnSensorDerechoBlanco";
            this.btnSensorDerechoBlanco.UseVisualStyleBackColor = true;
            this.btnSensorDerechoBlanco.Click += new System.EventHandler(this.BtnSensor_Click);
            // 
            // btnBuscarRegistros
            // 
            this.btnBuscarRegistros.Location = new System.Drawing.Point(113, 255);
            this.btnBuscarRegistros.Name = "btnBuscarRegistros";
            this.btnBuscarRegistros.Size = new System.Drawing.Size(117, 40);
            this.btnBuscarRegistros.TabIndex = 0;
            this.btnBuscarRegistros.Text = "Buscar Registros";
            this.btnBuscarRegistros.UseVisualStyleBackColor = true;
            this.btnBuscarRegistros.Click += new System.EventHandler(this.BtnBuscarRegistros_Click);
            // 
            // lblSensorIzquierdo
            // 
            this.lblSensorIzquierdo.AutoSize = true;
            this.lblSensorIzquierdo.Location = new System.Drawing.Point(93, 65);
            this.lblSensorIzquierdo.Name = "lblSensorIzquierdo";
            this.lblSensorIzquierdo.Size = new System.Drawing.Size(93, 13);
            this.lblSensorIzquierdo.TabIndex = 2;
            this.lblSensorIzquierdo.Text = "lblSensorIzquierdo";
            this.lblSensorIzquierdo.Click += new System.EventHandler(this.BtnSensor_Click);
            // 
            // lblSensorDerecho
            // 
            this.lblSensorDerecho.AutoSize = true;
            this.lblSensorDerecho.Location = new System.Drawing.Point(243, 65);
            this.lblSensorDerecho.Name = "lblSensorDerecho";
            this.lblSensorDerecho.Size = new System.Drawing.Size(91, 13);
            this.lblSensorDerecho.TabIndex = 3;
            this.lblSensorDerecho.Text = "lblSensorDerecho";
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Location = new System.Drawing.Point(184, 26);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(50, 13);
            this.lblAccion.TabIndex = 4;
            this.lblAccion.Text = "lblAccion";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaDesde.Location = new System.Drawing.Point(29, 214);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(133, 20);
            this.dtpFechaDesde.TabIndex = 5;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaHasta.Location = new System.Drawing.Point(179, 214);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(138, 20);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // lstRegistros
            // 
            this.lstRegistros.HideSelection = false;
            this.lstRegistros.Location = new System.Drawing.Point(29, 19);
            this.lstRegistros.Name = "lstRegistros";
            this.lstRegistros.Size = new System.Drawing.Size(288, 165);
            this.lstRegistros.TabIndex = 7;
            this.lstRegistros.UseCompatibleStateImageBehavior = false;
            this.lstRegistros.View = System.Windows.Forms.View.List;
            // 
            // LblDesde
            // 
            this.LblDesde.AutoSize = true;
            this.LblDesde.Location = new System.Drawing.Point(26, 198);
            this.LblDesde.Name = "LblDesde";
            this.LblDesde.Size = new System.Drawing.Size(38, 13);
            this.LblDesde.TabIndex = 8;
            this.LblDesde.Text = "Desde";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(186, 198);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 9;
            this.lblHasta.Text = "Hasta";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lstRegistros);
            this.groupBox.Controls.Add(this.lblHasta);
            this.groupBox.Controls.Add(this.LblDesde);
            this.groupBox.Controls.Add(this.dtpFechaDesde);
            this.groupBox.Controls.Add(this.dtpFechaHasta);
            this.groupBox.Controls.Add(this.btnBuscarRegistros);
            this.groupBox.Location = new System.Drawing.Point(423, 26);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(335, 323);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Registros";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.lblAccion);
            this.Controls.Add(this.lblSensorDerecho);
            this.Controls.Add(this.lblSensorIzquierdo);
            this.Controls.Add(this.btnSensorIzquierdoNegro);
            this.Controls.Add(this.btnSensorIzquierdoBlanco);
            this.Controls.Add(this.btnSensorDerechoNegro);
            this.Controls.Add(this.btnSensorDerechoBlanco);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label LblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.GroupBox groupBox;
    }
}
