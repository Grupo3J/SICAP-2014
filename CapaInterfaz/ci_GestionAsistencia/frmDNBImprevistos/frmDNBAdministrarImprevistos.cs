using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionAsistencia;
using DevComponents.DotNetBar.Controls;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBAdministrarImprevistos : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarImprevistos()
        {
            InitializeComponent();
        }
        ImprevistoLN imprevisto = new ImprevistoLN();
        DataGridViewButtonColumn coldescrip = new DataGridViewButtonColumn();
        DataGridViewButtonColumn colpers = new DataGridViewButtonColumn();

        private void frmDNBAdministrarImprevistos_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbcalendario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            dataGridViewX1.DataSource = imprevisto.ListarImprevistoporCalendario("123ab");
            dataGridViewX1.Columns[3].Visible = false;
            coldescrip.Name = "btnDescripcion";
            coldescrip.HeaderText = "DESCRIPCION";
            coldescrip.Text = "...";
            coldescrip.UseColumnTextForButtonValue = true;
            dataGridViewX1.Columns.Add(coldescrip);
            colpers.Name = "btnPersonal";
            colpers.HeaderText = "VER PERSONAL";
            //colpers.Text = "Ver";
            colpers.UseColumnTextForButtonValue = true;
            dataGridViewX1.Columns.Add(colpers);
        }

        private void dataGridViewX1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridViewX1.Columns[e.ColumnIndex].Name == "btnPersonal" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.dataGridViewX1.Rows[e.RowIndex].Cells["btnPersonal"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(Application.StartupPath + @"\personal.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 43, e.CellBounds.Top + 3);

                this.dataGridViewX1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.dataGridViewX1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 80;

                e.Handled = true;
            }
        }


    }
}