namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    partial class frmAdministrarHuella
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butCargarHuella1 = new System.Windows.Forms.Button();
            this.pictureBoxHuella2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxHuella1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPrueba = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuella2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuella1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrueba)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.listarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.nuevoToolStripMenuItem.Text = "Guardar";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.listarToolStripMenuItem.Text = "Listar";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(320, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(430, 221);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCargarHuella1);
            this.groupBox1.Controls.Add(this.pictureBoxHuella2);
            this.groupBox1.Controls.Add(this.pictureBoxHuella1);
            this.groupBox1.Location = new System.Drawing.Point(21, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 229);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Huella";
            // 
            // butCargarHuella1
            // 
            this.butCargarHuella1.Location = new System.Drawing.Point(84, 185);
            this.butCargarHuella1.Name = "butCargarHuella1";
            this.butCargarHuella1.Size = new System.Drawing.Size(87, 23);
            this.butCargarHuella1.TabIndex = 2;
            this.butCargarHuella1.Text = "Cargar Huella";
            this.butCargarHuella1.UseVisualStyleBackColor = true;
            this.butCargarHuella1.Click += new System.EventHandler(this.butCargarHuella1_Click);
            // 
            // pictureBoxHuella2
            // 
            this.pictureBoxHuella2.Location = new System.Drawing.Point(143, 32);
            this.pictureBoxHuella2.Name = "pictureBoxHuella2";
            this.pictureBoxHuella2.Size = new System.Drawing.Size(100, 129);
            this.pictureBoxHuella2.TabIndex = 1;
            this.pictureBoxHuella2.TabStop = false;
            // 
            // pictureBoxHuella1
            // 
            this.pictureBoxHuella1.Location = new System.Drawing.Point(15, 32);
            this.pictureBoxHuella1.Name = "pictureBoxHuella1";
            this.pictureBoxHuella1.Size = new System.Drawing.Size(100, 129);
            this.pictureBoxHuella1.TabIndex = 0;
            this.pictureBoxHuella1.TabStop = false;
            // 
            // pictureBoxPrueba
            // 
            this.pictureBoxPrueba.Location = new System.Drawing.Point(72, 313);
            this.pictureBoxPrueba.Name = "pictureBoxPrueba";
            this.pictureBoxPrueba.Size = new System.Drawing.Size(100, 81);
            this.pictureBoxPrueba.TabIndex = 4;
            this.pictureBoxPrueba.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // frmAdministrarHuella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 406);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPrueba);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmAdministrarHuella";
            this.Text = "Administrar Huella  Dactilar";
            this.Load += new System.EventHandler(this.frmAdministrarHuella_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuella2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHuella1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrueba)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butCargarHuella1;
        private System.Windows.Forms.PictureBox pictureBoxHuella2;
        private System.Windows.Forms.PictureBox pictureBoxHuella1;
        private System.Windows.Forms.PictureBox pictureBoxPrueba;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.Label label1;

    }
}