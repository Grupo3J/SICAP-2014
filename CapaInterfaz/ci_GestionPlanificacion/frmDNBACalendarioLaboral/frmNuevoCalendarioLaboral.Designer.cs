namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBACalendarioLaboral
{
    partial class frmNuevoCalendarioLaboral
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtretraso = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtihorafin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtihoraentrada = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.comboNombre = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.label2 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePFin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtihorafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtihoraentrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(581, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "Datos Calendario Laboral";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CapaInterfaz.Properties.Resources._48px_Crystal_Clear_device_3floppy_mount;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
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
            this.toolStripButton2.Image = global::CapaInterfaz.Properties.Resources._48px_Crystal_Clear_action_reload;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton2.Text = "Cancelar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtretraso);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.dtihorafin);
            this.groupPanel1.Controls.Add(this.dtihoraentrada);
            this.groupPanel1.Controls.Add(this.comboNombre);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.textDescripcion);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.dateTimePFin);
            this.groupPanel1.Controls.Add(this.dateTimePInicio);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(30, 44);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(523, 314);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "Datos Calendario Laboral";
            // 
            // txtretraso
            // 
            this.txtretraso.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtretraso.Border.Class = "TextBoxBorder";
            this.txtretraso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtretraso.DisabledBackColor = System.Drawing.Color.White;
            this.txtretraso.ForeColor = System.Drawing.Color.Black;
            this.txtretraso.Location = new System.Drawing.Point(337, 160);
            this.txtretraso.Name = "txtretraso";
            this.txtretraso.PreventEnterBeep = true;
            this.txtretraso.Size = new System.Drawing.Size(100, 22);
            this.txtretraso.TabIndex = 31;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(443, 162);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(51, 17);
            this.labelX4.TabIndex = 30;
            this.labelX4.Text = "Minutos";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(276, 162);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(55, 17);
            this.labelX3.TabIndex = 30;
            this.labelX3.Text = "Retraso:";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(40, 212);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 14);
            this.labelX2.TabIndex = 29;
            this.labelX2.Text = "Hora Salida:";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(40, 168);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(84, 11);
            this.labelX1.TabIndex = 29;
            this.labelX1.Text = "Hora Entrada:";
            // 
            // dtihorafin
            // 
            // 
            // 
            // 
            this.dtihorafin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtihorafin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihorafin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtihorafin.ButtonDropDown.Visible = true;
            this.dtihorafin.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dtihorafin.IsPopupCalendarOpen = false;
            this.dtihorafin.Location = new System.Drawing.Point(130, 204);
            // 
            // 
            // 
            this.dtihorafin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtihorafin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihorafin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtihorafin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtihorafin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihorafin.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtihorafin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtihorafin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtihorafin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtihorafin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtihorafin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtihorafin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihorafin.MonthCalendar.TodayButtonVisible = true;
            this.dtihorafin.MonthCalendar.Visible = false;
            this.dtihorafin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtihorafin.Name = "dtihorafin";
            this.dtihorafin.Size = new System.Drawing.Size(126, 22);
            this.dtihorafin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtihorafin.TabIndex = 28;
            // 
            // dtihoraentrada
            // 
            // 
            // 
            // 
            this.dtihoraentrada.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtihoraentrada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihoraentrada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtihoraentrada.ButtonDropDown.Visible = true;
            this.dtihoraentrada.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime;
            this.dtihoraentrada.IsPopupCalendarOpen = false;
            this.dtihoraentrada.Location = new System.Drawing.Point(130, 160);
            // 
            // 
            // 
            this.dtihoraentrada.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtihoraentrada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihoraentrada.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtihoraentrada.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtihoraentrada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihoraentrada.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtihoraentrada.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtihoraentrada.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtihoraentrada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtihoraentrada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtihoraentrada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtihoraentrada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtihoraentrada.MonthCalendar.TodayButtonVisible = true;
            this.dtihoraentrada.MonthCalendar.Visible = false;
            this.dtihoraentrada.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtihoraentrada.Name = "dtihoraentrada";
            this.dtihoraentrada.Size = new System.Drawing.Size(126, 22);
            this.dtihoraentrada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtihoraentrada.TabIndex = 27;
            // 
            // comboNombre
            // 
            this.comboNombre.DisplayMember = "Text";
            this.comboNombre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboNombre.FormattingEnabled = true;
            this.comboNombre.ItemHeight = 16;
            this.comboNombre.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.comboNombre.Location = new System.Drawing.Point(130, 25);
            this.comboNombre.Name = "comboNombre";
            this.comboNombre.Size = new System.Drawing.Size(259, 22);
            this.comboNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboNombre.TabIndex = 26;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "MATUTINO";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "VESPERTINO";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "NOCTURNO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Descripción:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(130, 251);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(346, 22);
            this.textDescripcion.TabIndex = 24;
            this.textDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDescripcion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha Inicio:";
            // 
            // dateTimePFin
            // 
            this.dateTimePFin.Location = new System.Drawing.Point(130, 118);
            this.dateTimePFin.Name = "dateTimePFin";
            this.dateTimePFin.Size = new System.Drawing.Size(185, 22);
            this.dateTimePFin.TabIndex = 21;
            // 
            // dateTimePInicio
            // 
            this.dateTimePInicio.Location = new System.Drawing.Point(130, 75);
            this.dateTimePInicio.Name = "dateTimePInicio";
            this.dateTimePInicio.Size = new System.Drawing.Size(185, 22);
            this.dateTimePInicio.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNuevoCalendarioLaboral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 384);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNuevoCalendarioLaboral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Calendario Laboral";
            this.Load += new System.EventHandler(this.frmNuevoCalendarioLaboral_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtihorafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtihoraentrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePFin;
        private System.Windows.Forms.DateTimePicker dateTimePInicio;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboNombre;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtretraso;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtihorafin;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtihoraentrada;
    }
}