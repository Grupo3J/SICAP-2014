namespace CapaInterfaz.ci_GestionPlanificacion.frmCalendarioLaboral
{
    partial class frmModificarCalendario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificarCalendario));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBoxCaledario = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBoxCaledario.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(481, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Guardar";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton2.Text = "Cancelar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBoxCaledario
            // 
            this.groupBoxCaledario.Controls.Add(this.label4);
            this.groupBoxCaledario.Controls.Add(this.label3);
            this.groupBoxCaledario.Controls.Add(this.dateTimePFin);
            this.groupBoxCaledario.Controls.Add(this.dateTimePInicio);
            this.groupBoxCaledario.Controls.Add(this.label2);
            this.groupBoxCaledario.Controls.Add(this.label1);
            this.groupBoxCaledario.Controls.Add(this.textDescripcion);
            this.groupBoxCaledario.Controls.Add(this.textNombre);
            this.groupBoxCaledario.Location = new System.Drawing.Point(12, 47);
            this.groupBoxCaledario.Name = "groupBoxCaledario";
            this.groupBoxCaledario.Size = new System.Drawing.Size(457, 202);
            this.groupBoxCaledario.TabIndex = 4;
            this.groupBoxCaledario.TabStop = false;
            this.groupBoxCaledario.Text = "Datos Calendario Laboral";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fecha Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fecha Inicio:";
            // 
            // dateTimePFin
            // 
            this.dateTimePFin.Location = new System.Drawing.Point(106, 150);
            this.dateTimePFin.Name = "dateTimePFin";
            this.dateTimePFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePFin.TabIndex = 13;
            // 
            // dateTimePInicio
            // 
            this.dateTimePInicio.Location = new System.Drawing.Point(106, 107);
            this.dateTimePInicio.Name = "dateTimePInicio";
            this.dateTimePInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePInicio.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(106, 57);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(334, 20);
            this.textDescripcion.TabIndex = 9;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(106, 22);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(140, 20);
            this.textNombre.TabIndex = 8;
            // 
            // frmModificarCalendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 269);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBoxCaledario);
            this.Name = "frmModificarCalendario";
            this.Text = "Modificar Calendario Laboral";
            this.Load += new System.EventHandler(this.frmModificarCalendario_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxCaledario.ResumeLayout(false);
            this.groupBoxCaledario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBoxCaledario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePFin;
        private System.Windows.Forms.DateTimePicker dateTimePInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.TextBox textNombre;
    }
}