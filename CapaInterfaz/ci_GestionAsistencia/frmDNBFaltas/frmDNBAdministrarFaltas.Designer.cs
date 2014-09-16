namespace CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas
{
    partial class frmDNBAdministrarFaltas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDNBAdministrarFaltas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolnuevo = new System.Windows.Forms.ToolStripButton();
            this.tooleliminar = new System.Windows.Forms.ToolStripButton();
            this.toolmodificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripcmbcalendario = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dtidia = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtbuscar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupbox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvfaltasdia = new System.Windows.Forms.DataGridView();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvfaltasrango = new System.Windows.Forms.DataGridView();
            this.txtbuscarrango = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dtiinicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtifin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvfaltasmes = new System.Windows.Forms.DataGridView();
            this.cmbmes = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtbuscarmes = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTooltip1 = new DevComponents.DotNetBar.SuperTooltip();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtidia)).BeginInit();
            this.groupbox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasdia)).BeginInit();
            this.superTabControlPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasrango)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiinicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtifin)).BeginInit();
            this.superTabControlPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasmes)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolnuevo,
            this.tooleliminar,
            this.toolmodificar,
            this.toolStripcmbcalendario,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(704, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolnuevo
            // 
            this.toolnuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolnuevo.Image")));
            this.toolnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolnuevo.Name = "toolnuevo";
            this.toolnuevo.Size = new System.Drawing.Size(62, 22);
            this.toolnuevo.Text = "Nuevo";
            this.toolnuevo.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tooleliminar
            // 
            this.tooleliminar.Image = ((System.Drawing.Image)(resources.GetObject("tooleliminar.Image")));
            this.tooleliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooleliminar.Name = "tooleliminar";
            this.tooleliminar.Size = new System.Drawing.Size(70, 22);
            this.tooleliminar.Text = "Eliminar";
            this.tooleliminar.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolmodificar
            // 
            this.toolmodificar.Image = ((System.Drawing.Image)(resources.GetObject("toolmodificar.Image")));
            this.toolmodificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolmodificar.Name = "toolmodificar";
            this.toolmodificar.Size = new System.Drawing.Size(78, 22);
            this.toolmodificar.Text = "Modificar";
            this.toolmodificar.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripcmbcalendario
            // 
            this.toolStripcmbcalendario.Name = "toolStripcmbcalendario";
            this.toolStripcmbcalendario.Size = new System.Drawing.Size(121, 25);
            this.toolStripcmbcalendario.SelectedIndexChanged += new System.EventHandler(this.toolStripcmbcalendario_SelectedIndexChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel1.Text = "Calendario";
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(12, 28);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(680, 402);
            this.superTabControl1.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.superTabItem3});
            this.superTabControl1.Text = "superTabControl1";
            this.superTabControl1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl1_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.dtidia);
            this.superTabControlPanel1.Controls.Add(this.labelX2);
            this.superTabControlPanel1.Controls.Add(this.labelX1);
            this.superTabControlPanel1.Controls.Add(this.txtbuscar);
            this.superTabControlPanel1.Controls.Add(this.groupbox1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(680, 375);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // dtidia
            // 
            // 
            // 
            // 
            this.dtidia.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtidia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtidia.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtidia.ButtonDropDown.Visible = true;
            this.dtidia.IsPopupCalendarOpen = false;
            this.dtidia.Location = new System.Drawing.Point(454, 17);
            // 
            // 
            // 
            this.dtidia.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtidia.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtidia.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtidia.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtidia.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtidia.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtidia.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtidia.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtidia.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtidia.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtidia.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtidia.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtidia.MonthCalendar.TodayButtonVisible = true;
            this.dtidia.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtidia.MonthCalendar.PaintLabel += new DevComponents.Editors.DateTimeAdv.DayPaintEventHandler(this.dtidia_MonthCalendar_PaintLabel);
            this.dtidia.Name = "dtidia";
            this.dtidia.Size = new System.Drawing.Size(128, 22);
            this.dtidia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtidia.TabIndex = 4;
            this.dtidia.ValueChanged += new System.EventHandler(this.dtidia_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(417, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Dia";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(113, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(51, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Buscar";
            // 
            // txtbuscar
            // 
            this.txtbuscar.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtbuscar.Border.Class = "TextBoxBorder";
            this.txtbuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbuscar.DisabledBackColor = System.Drawing.Color.White;
            this.txtbuscar.ForeColor = System.Drawing.Color.Black;
            this.txtbuscar.Location = new System.Drawing.Point(170, 17);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.PreventEnterBeep = true;
            this.txtbuscar.Size = new System.Drawing.Size(100, 22);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // groupbox1
            // 
            this.groupbox1.BackColor = System.Drawing.Color.White;
            this.groupbox1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupbox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.groupbox1.Controls.Add(this.dgvfaltasdia);
            this.groupbox1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupbox1.Location = new System.Drawing.Point(21, 43);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(639, 320);
            // 
            // 
            // 
            this.groupbox1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupbox1.Style.BackColorGradientAngle = 90;
            this.groupbox1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupbox1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox1.Style.BorderBottomWidth = 1;
            this.groupbox1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupbox1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox1.Style.BorderLeftWidth = 1;
            this.groupbox1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox1.Style.BorderRightWidth = 1;
            this.groupbox1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupbox1.Style.BorderTopWidth = 1;
            this.groupbox1.Style.CornerDiameter = 4;
            this.groupbox1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupbox1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupbox1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupbox1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupbox1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupbox1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupbox1.TabIndex = 0;
            this.groupbox1.Text = "Faltas por Día";
            // 
            // dgvfaltasdia
            // 
            this.dgvfaltasdia.AllowUserToAddRows = false;
            this.dgvfaltasdia.AllowUserToDeleteRows = false;
            this.dgvfaltasdia.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvfaltasdia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfaltasdia.Location = new System.Drawing.Point(3, 3);
            this.dgvfaltasdia.Name = "dgvfaltasdia";
            this.dgvfaltasdia.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvfaltasdia.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvfaltasdia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfaltasdia.Size = new System.Drawing.Size(627, 291);
            this.dgvfaltasdia.TabIndex = 31;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Faltas por Día";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.groupPanel2);
            this.superTabControlPanel3.Controls.Add(this.txtbuscarrango);
            this.superTabControlPanel3.Controls.Add(this.labelX7);
            this.superTabControlPanel3.Controls.Add(this.buttonX1);
            this.superTabControlPanel3.Controls.Add(this.labelX6);
            this.superTabControlPanel3.Controls.Add(this.labelX5);
            this.superTabControlPanel3.Controls.Add(this.dtiinicio);
            this.superTabControlPanel3.Controls.Add(this.dtifin);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(680, 375);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem3;
            this.superTabControlPanel3.Click += new System.EventHandler(this.superTabControlPanel3_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.White;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dgvfaltasrango);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(39, 52);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(597, 305);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 7;
            this.groupPanel2.Text = "Faltas por Rango";
            // 
            // dgvfaltasrango
            // 
            this.dgvfaltasrango.AllowUserToAddRows = false;
            this.dgvfaltasrango.AllowUserToDeleteRows = false;
            this.dgvfaltasrango.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvfaltasrango.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfaltasrango.Location = new System.Drawing.Point(4, 3);
            this.dgvfaltasrango.Name = "dgvfaltasrango";
            this.dgvfaltasrango.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvfaltasrango.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvfaltasrango.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfaltasrango.Size = new System.Drawing.Size(584, 276);
            this.dgvfaltasrango.TabIndex = 33;
            // 
            // txtbuscarrango
            // 
            this.txtbuscarrango.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtbuscarrango.Border.Class = "TextBoxBorder";
            this.txtbuscarrango.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbuscarrango.DisabledBackColor = System.Drawing.Color.White;
            this.txtbuscarrango.ForeColor = System.Drawing.Color.Black;
            this.txtbuscarrango.Location = new System.Drawing.Point(101, 16);
            this.txtbuscarrango.Name = "txtbuscarrango";
            this.txtbuscarrango.PreventEnterBeep = true;
            this.txtbuscarrango.Size = new System.Drawing.Size(100, 22);
            this.txtbuscarrango.TabIndex = 6;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(51, 17);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(44, 23);
            this.labelX7.TabIndex = 5;
            this.labelX7.Text = "Buscar";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(600, 16);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(40, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "OK";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(446, 16);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(54, 23);
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "Fecha Fin";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(284, 16);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(62, 23);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "Fecha Inicio";
            // 
            // dtiinicio
            // 
            // 
            // 
            // 
            this.dtiinicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiinicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiinicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiinicio.ButtonDropDown.Visible = true;
            this.dtiinicio.IsPopupCalendarOpen = false;
            this.dtiinicio.Location = new System.Drawing.Point(352, 16);
            // 
            // 
            // 
            this.dtiinicio.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiinicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiinicio.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiinicio.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiinicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiinicio.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtiinicio.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiinicio.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiinicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiinicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiinicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiinicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiinicio.MonthCalendar.TodayButtonVisible = true;
            this.dtiinicio.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiinicio.MonthCalendar.PaintLabel += new DevComponents.Editors.DateTimeAdv.DayPaintEventHandler(this.dtiinicio_MonthCalendar_PaintLabel);
            this.dtiinicio.Name = "dtiinicio";
            this.dtiinicio.Size = new System.Drawing.Size(88, 22);
            this.dtiinicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiinicio.TabIndex = 1;
            // 
            // dtifin
            // 
            // 
            // 
            // 
            this.dtifin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtifin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtifin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtifin.ButtonDropDown.Visible = true;
            this.dtifin.IsPopupCalendarOpen = false;
            this.dtifin.Location = new System.Drawing.Point(506, 17);
            // 
            // 
            // 
            this.dtifin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtifin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtifin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtifin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtifin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtifin.MonthCalendar.DisplayMonth = new System.DateTime(2014, 9, 1, 0, 0, 0, 0);
            this.dtifin.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtifin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtifin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtifin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtifin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtifin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtifin.MonthCalendar.TodayButtonVisible = true;
            this.dtifin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtifin.MonthCalendar.PaintLabel += new DevComponents.Editors.DateTimeAdv.DayPaintEventHandler(this.dtifin_MonthCalendar_PaintLabel);
            this.dtifin.Name = "dtifin";
            this.dtifin.Size = new System.Drawing.Size(88, 22);
            this.dtifin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtifin.TabIndex = 0;
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "Faltas por Rango";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.groupPanel1);
            this.superTabControlPanel2.Controls.Add(this.cmbmes);
            this.superTabControlPanel2.Controls.Add(this.labelX4);
            this.superTabControlPanel2.Controls.Add(this.txtbuscarmes);
            this.superTabControlPanel2.Controls.Add(this.labelX3);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(680, 375);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.White;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvfaltasmes);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(34, 43);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(609, 315);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "Faltas por Mes";
            // 
            // dgvfaltasmes
            // 
            this.dgvfaltasmes.AllowUserToAddRows = false;
            this.dgvfaltasmes.AllowUserToDeleteRows = false;
            this.dgvfaltasmes.BackgroundColor = System.Drawing.Color.Beige;
            this.dgvfaltasmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfaltasmes.Location = new System.Drawing.Point(4, 3);
            this.dgvfaltasmes.Name = "dgvfaltasmes";
            this.dgvfaltasmes.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvfaltasmes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvfaltasmes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfaltasmes.Size = new System.Drawing.Size(596, 286);
            this.dgvfaltasmes.TabIndex = 32;
            // 
            // cmbmes
            // 
            this.cmbmes.DisplayMember = "Text";
            this.cmbmes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbmes.FormattingEnabled = true;
            this.cmbmes.ItemHeight = 16;
            this.cmbmes.Location = new System.Drawing.Point(451, 15);
            this.cmbmes.Name = "cmbmes";
            this.cmbmes.Size = new System.Drawing.Size(121, 22);
            this.cmbmes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbmes.TabIndex = 3;
            this.cmbmes.SelectedIndexChanged += new System.EventHandler(this.cmbmes_SelectedIndexChanged);
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(406, 14);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(39, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "Mes";
            // 
            // txtbuscarmes
            // 
            this.txtbuscarmes.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtbuscarmes.Border.Class = "TextBoxBorder";
            this.txtbuscarmes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtbuscarmes.DisabledBackColor = System.Drawing.Color.White;
            this.txtbuscarmes.ForeColor = System.Drawing.Color.Black;
            this.txtbuscarmes.Location = new System.Drawing.Point(167, 15);
            this.txtbuscarmes.Name = "txtbuscarmes";
            this.txtbuscarmes.PreventEnterBeep = true;
            this.txtbuscarmes.Size = new System.Drawing.Size(100, 22);
            this.txtbuscarmes.TabIndex = 1;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(121, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(40, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Buscar";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "Faltas por Mes";
            // 
            // superTooltip1
            // 
            this.superTooltip1.DefaultTooltipSettings = new DevComponents.DotNetBar.SuperTooltipInfo("", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.Gray);
            // 
            // frmDNBAdministrarFaltas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.superTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDNBAdministrarFaltas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Faltas";
            this.Load += new System.EventHandler(this.frmDNBAdministrarFaltas_Load);
            this.Shown += new System.EventHandler(this.frmDNBAdministrarFaltas_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtidia)).EndInit();
            this.groupbox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasdia)).EndInit();
            this.superTabControlPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasrango)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiinicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtifin)).EndInit();
            this.superTabControlPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfaltasmes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolnuevo;
        private System.Windows.Forms.ToolStripButton tooleliminar;
        private System.Windows.Forms.ToolStripButton toolmodificar;
        private System.Windows.Forms.ToolStripComboBox toolStripcmbcalendario;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupbox1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbuscar;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtidia;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbmes;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbuscarmes;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiinicio;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtifin;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtbuscarrango;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.SuperTooltip superTooltip1;
        private System.Windows.Forms.DataGridView dgvfaltasdia;
        private System.Windows.Forms.DataGridView dgvfaltasmes;
        private System.Windows.Forms.DataGridView dgvfaltasrango;
    }
}