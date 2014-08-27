using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAsistencia.frmAsistencia
{
    public partial class frmAdministrarAsistencia : Form
    {
        public frmAdministrarAsistencia()
        {
            InitializeComponent();
        }
        
        private void frmAdministrarAsistencia_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "Ganó");
            dataGridView1.Columns.Add("", "Perdió");
            dataGridView1.Columns.Add("", "Ganó");
            dataGridView1.Columns.Add("", "Perdió");
            dataGridView1.Columns.Add("", "Ganó");
            dataGridView1.Columns.Add("", "Perdió");
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight * 2;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            string[] moths = { "Enero", "Febrero", "Marzo" };
            int j = 0;
            while(j<6)
            {
                Rectangle r1 = dataGridView1.GetCellDisplayRectangle(j, -1, true);
                r1.X += 1;
                r1.Y += 1;
                r1.Width = r1.Width * 2 - 2;
                r1.Height = r1.Height / 2 - 2;

                e.Graphics.FillRectangle(new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), r1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(moths[j / 2], dataGridView1.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                j += 2;
            }
        }   
    }
}
