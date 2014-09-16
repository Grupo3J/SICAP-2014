namespace CapaInterfaz.ci_GestionSeguridad
{
    partial class frmUsuarioLogged
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioLogged));
            this.lblrol = new DevComponents.DotNetBar.LabelX();
            this.lblnameuser = new DevComponents.DotNetBar.LabelX();
            this.radialMenu1 = new DevComponents.DotNetBar.RadialMenu();
            this.raidalhome = new DevComponents.DotNetBar.RadialMenuItem();
            this.raidallogout = new DevComponents.DotNetBar.RadialMenuItem();
            this.raidalacercade = new DevComponents.DotNetBar.RadialMenuItem();
            this.raidalmiperfil = new DevComponents.DotNetBar.RadialMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblrol
            // 
            this.lblrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblrol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblrol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrol.ForeColor = System.Drawing.Color.Black;
            this.lblrol.Location = new System.Drawing.Point(445, 46);
            this.lblrol.Name = "lblrol";
            this.lblrol.Size = new System.Drawing.Size(168, 25);
            this.lblrol.TabIndex = 17;
            this.lblrol.Text = "Rol";
            this.lblrol.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblnameuser
            // 
            this.lblnameuser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblnameuser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblnameuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnameuser.ForeColor = System.Drawing.Color.Black;
            this.lblnameuser.Location = new System.Drawing.Point(441, 24);
            this.lblnameuser.Name = "lblnameuser";
            this.lblnameuser.Size = new System.Drawing.Size(168, 25);
            this.lblnameuser.TabIndex = 16;
            this.lblnameuser.Text = "User";
            this.lblnameuser.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // radialMenu1
            // 
            this.radialMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.radialMenu1.ForeColor = System.Drawing.Color.Black;
            this.radialMenu1.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.radialMenu1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.raidalhome,
            this.raidalmiperfil,
            this.raidalacercade,
            this.raidallogout});
            this.radialMenu1.Location = new System.Drawing.Point(584, 75);
            this.radialMenu1.Name = "radialMenu1";
            this.radialMenu1.Size = new System.Drawing.Size(28, 28);
            this.radialMenu1.Symbol = "";
            this.radialMenu1.SymbolSize = 17F;
            this.radialMenu1.TabIndex = 15;
            this.radialMenu1.Tag = "Home";
            this.radialMenu1.Text = "Raidal";
            this.radialMenu1.ItemClick += new System.EventHandler(this.radialMenu1_ItemClick);
            // 
            // raidalhome
            // 
            this.raidalhome.Name = "raidalhome";
            this.raidalhome.Text = "Home";
            // 
            // raidallogout
            // 
            this.raidallogout.Name = "raidallogout";
            this.raidallogout.Text = "Log Out";
            // 
            // raidalacercade
            // 
            this.raidalacercade.Name = "raidalacercade";
            this.raidalacercade.Text = "Acerca de";
            // 
            // raidalmiperfil
            // 
            this.raidalmiperfil.Name = "raidalmiperfil";
            this.raidalmiperfil.Text = "Mi Perfil";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.ForeColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(619, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(203, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 73);
            this.label1.TabIndex = 36;
            this.label1.Text = "SICAP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(256, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 39;
            this.label6.Text = "De Personal";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(188, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "Sistema de Control de Asistencia ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox2.ForeColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // frmUsuarioLogged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 126);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblrol);
            this.Controls.Add(this.lblnameuser);
            this.Controls.Add(this.radialMenu1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmUsuarioLogged";
            this.Text = "Usuario Logged";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblrol;
        private DevComponents.DotNetBar.LabelX lblnameuser;
        private DevComponents.DotNetBar.RadialMenu radialMenu1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevComponents.DotNetBar.RadialMenuItem raidalhome;
        private DevComponents.DotNetBar.RadialMenuItem raidallogout;
        private DevComponents.DotNetBar.RadialMenuItem raidalacercade;
        private DevComponents.DotNetBar.RadialMenuItem raidalmiperfil;
    }
}