namespace CapaInterfaz.ci_GestionSeguridad
{
    partial class frmPermiso
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.comboBox1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.columnHeader5 = new DevComponents.Tree.ColumnHeader();
            this.btnguardar = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.ForeColor = System.Drawing.Color.Black;
            this.treeView1.Location = new System.Drawing.Point(123, 65);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(353, 357);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.beforecheck);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.aftercheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(217, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 26);
            this.comboBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            // 
            // btnguardar
            // 
            this.btnguardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnguardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnguardar.Location = new System.Drawing.Point(540, 268);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(75, 23);
            this.btnguardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnguardar.TabIndex = 3;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(495, 126);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(185, 62);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "Seleccione el rol y los permisos a los cuales tendra acceso este rol";
            this.labelX1.WordWrap = true;
            // 
            // frmPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeView1);
            this.DoubleBuffered = true;
            this.Name = "frmPermiso";
            this.Text = "frmPermiso";
            this.Load += new System.EventHandler(this.frmPermiso_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBox1;
        private DevComponents.Tree.ColumnHeader columnHeader5;
        private DevComponents.DotNetBar.ButtonX btnguardar;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}