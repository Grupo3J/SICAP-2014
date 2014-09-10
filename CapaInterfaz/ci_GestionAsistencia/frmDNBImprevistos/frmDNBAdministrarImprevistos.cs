using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionAsistencia;
using DevComponents.DotNetBar.Controls;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaEntidades.GestionAsistencia;
using CapaDatos;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBAdministrarImprevistos : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarImprevistos()
        {
            InitializeComponent();
        }
        ImprevistoLN imprevisto = new ImprevistoLN();
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        AsistenciaLN asistencia = new AsistenciaLN();
        Imprevistos imp = new Imprevistos();
        DataGridViewButtonColumn coldescrip = new DataGridViewButtonColumn();
        DataGridViewButtonColumn colpers = new DataGridViewButtonColumn();
        private string idcalendario;

        private void frmDNBAdministrarImprevistos_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbcalendario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            foreach(sp_ListarCalendarioResult temp in calendario.ListarCalendario())
            {
                toolStripcmbcalendario.Items.Add(temp.NOMBRE);
            }
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

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridViewX1.Columns["btnDescripcion"].Index && e.ColumnIndex !=
                dataGridViewX1.Columns["btnPersonal"].Index) return;

            var linq = imprevisto.ListarImprevistoporCalendario(idcalendario);

            if (e.ColumnIndex == dataGridViewX1.Columns["btnDescripcion"].Index)
            {    
                frmDNBDescripcion descrip = new frmDNBDescripcion(linq[e.RowIndex].DESCRIPCION);
                descrip.ShowDialog();
            }
            else 
            {
                frmDNBVerPersonal vpersonal = new frmDNBVerPersonal(idcalendario, linq[e.RowIndex].IDIMPREVISTO);
                vpersonal.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDNBEditImprevisto impr = new frmDNBEditImprevisto(idcalendario);
            var linq = calendario.PersonalporCalendario(idcalendario);
            impr.dataGridViewX1.DataSource = linq.ToList();
            impr.listaizq = linq.ToList();
            impr.dataGridViewX2.DataSource = impr.listader;
            impr.ShowDialog();
            if (impr.OPTION == "OK")
            {
                try
                {
                    string id;
                    do
                    {
                        id = GenerarIdImprevisto();
                        imp.IdImprevisto = id;

                    }
                    while (imprevisto.ExisteImprevisto(id));
                    
                    imp.FechaInicio = impr.dtifechainicio.Value.Add(TimeSpan.Parse(impr.dtihoraentrada.Value.TimeOfDay.ToString()));
                    imp.FechaFinal = impr.dtifechainicio.Value.Add(TimeSpan.Parse(impr.dtihorafin.Value.TimeOfDay.ToString()));
                    imp.Descripcion = impr.textBoxX1.Text;

                    
                    string personas = "No se puede agregar un Imprevisto a las Siguientes Personas:\n";
                    int i = 0;
                    List<string> idfaltas = new List<string>();
                    foreach (sp_PersonalporCalendarioResult temp in impr.listader) 
                    {
                        if (asistencia.ContarAsistenciaPersonal(temp.CEDULA, imp.FechaInicio, idcalendario) != 0) 
                        {
                            personas += "* " + temp.NOMBRE + " " + temp.APELLIDO + "\n";
                            i++;
                        }
                        else if(faltas.ContarFaltaPersonalDia(temp.CEDULA, imp.FechaInicio, idcalendario) != 0)
                        {
                            var faltjustificadas = (from lt in faltas.ListarFaltasPersonalDia(idcalendario,imp.FechaInicio)
                                                       where lt.CEDULA == temp.CEDULA && lt.JUSTIFICACION==false select lt.IDFALTA).ToList();
                            if(faltjustificadas.Count>0)
                            idfaltas.Add(faltjustificadas[0].ToString());
                        }
                    }

                    if (idfaltas.Count > 0) 
                    {
                        DialogResult dialogResult = MessageBoxEx.Show("Existe Personal con Falta Injustificada ese Día\nDeseea Justificar Dicha Falta\nSi Selecciona NO será Excluida del Imprevisto", "Administración de Imprevistos", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            foreach(string temp in idfaltas)
                            {
                                Faltas f = new Faltas();
                                f.IdFaltas = temp;
                                f.Justificacion = true;
                                faltas.ModificarFaltasJustificacion(f);
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                        //do something else
                        impr.listader.RemoveAll(x => faltas.ContarFaltaPersonalDia(x.CEDULA, imp.FechaInicio, idcalendario) != 0);    
                        }
                    }
                    
                    impr.listader.RemoveAll(x => asistencia.ContarAsistenciaPersonal(x.CEDULA, imp.FechaInicio, idcalendario) != 0);
                    personas += "Debido a que poseen Asistencias ese Dia";
                    if (impr.listader.Count > 0)
                    {
                        var calend = (from lt in calendario.ListarCalendario()
                                    where lt.IDCALENDARIO == idcalendario
                                    select lt).ToList();
                        if (imp.FechaInicio >= calend[0].FECHAINICIO && imp.FechaFinal < calend[0].FECHAFIN)
                        {
                            var imprev = (from lt in imprevisto.ListarImprevistoporCalendario(idcalendario)
                                          where lt.FECHA.Value.Day == imp.FechaInicio.Day && lt.FECHA.Value.Month == imp.FechaInicio.Month && lt.FECHA.Value.Year == imp.FechaInicio.Year
                                          select lt).Count();
                            if (imprev == 0)
                            {
                                if (imp.FechaInicio <= imp.FechaFinal)
                                {
                                    imprevisto.InsertarImprevisto(imp);
                                    calendario.IngresarPersonalDet(impr.listader, idcalendario, imp.IdImprevisto);
                                    if (i != 0)
                                        MessageBoxEx.Show(personas);
                                }
                                else
                                {
                                    MessageBoxEx.Show("La Hora de Entrada debe ser Menor que la Hora de Salida");
                                }
                                
                            }
                            else
                            {
                                MessageBoxEx.Show(this, "Ya Existe un Imprevisto en esa Fecha", "Administración de Imprevistos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show(this, "La Fecha Establecida no esta en el Rango del Calendario", "Administrar Faltas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                    }
                    else
                        MessageBoxEx.Show("No se pudo agregar el Imprevisto\nRevise la Administracion de Faltas e Asistencia");
                    MostrarImprevistos(idcalendario);
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message+mes.StackTrace);
                }
            }
        }

        private void MostrarImprevistos(string idcalendario) 
        {
            //dataGridViewX1.DataSource = null;
            dataGridViewX1.Columns.Clear();
            dataGridViewX1.DataSource = imprevisto.ListarImprevistoporCalendario(idcalendario);
            dataGridViewX1.Columns[4].Visible = false;
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

        private string GenerarIdImprevisto()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);
            return "I" + num.ToString() + num2.ToString();
        }

        private void toolStripcmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex >= 0) 
            {
                idcalendario = calendario.ListarCalendario()[toolStripcmbcalendario.SelectedIndex].IDCALENDARIO;
                 MostrarImprevistos(idcalendario);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmDNBEditImprevisto impr = new frmDNBEditImprevisto(idcalendario);
            var linq = calendario.PersonalporCalendario(idcalendario);
            var linq2 = imprevisto.ListarPersonasporImprevisto(idcalendario, dataGridViewX1.CurrentRow.Cells[0].Value.ToString());
            
            foreach (sp_Obtener_Personas_ImprevistoResult temp in linq2)
            {
                sp_PersonalporCalendarioResult t = new sp_PersonalporCalendarioResult();
                t.CEDULA = temp.CEDULA;
                t.APELLIDO = temp.APELLIDO;
                t.CARGO = temp.CARGO;
                t.CIUDAD = temp.CIUDAD;
                t.CORREO = temp.CORREO;
                t.DATAFOTO = temp.DATAFOTO;
                t.DIRECCION = temp.DIRECCION;
                t.NOMBRE = temp.NOMBRE;
                t.SEXO = temp.SEXO;
                t.TELEFONO = temp.TELEFONO;
                t.TIPO = temp.TIPO;
                t.TITULO = temp.TITULO;
                impr.listader.Add(t);
            }
            var l = from p in linq
                       where !(linq2.Any(entry => entry.CEDULA == p.CEDULA))
                       select p;
            impr.dataGridViewX1.DataSource = l.ToList();
            impr.listaizq = l.ToList();
            impr.dataGridViewX2.DataSource = impr.listader;
            impr.textBoxX1.Text = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();
            impr.dtifechainicio.Value = Convert.ToDateTime(dataGridViewX1.CurrentRow.Cells[1].Value);
            impr.dtihoraentrada.Value = Convert.ToDateTime(dataGridViewX1.CurrentRow.Cells[2].Value);
            impr.dtihorafin.Value = Convert.ToDateTime(dataGridViewX1.CurrentRow.Cells[3].Value);
            impr.ShowDialog();
            if (impr.OPTION == "OK")
            {
                try
                {
                    imp.IdImprevisto = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                    imp.FechaInicio = impr.dtifechainicio.Value.Add(TimeSpan.Parse(impr.dtihoraentrada.Value.TimeOfDay.ToString()));
                    imp.FechaFinal = impr.dtifechainicio.Value.Add(TimeSpan.Parse(impr.dtihorafin.Value.TimeOfDay.ToString()));
                    imp.Descripcion = impr.textBoxX1.Text;
                    string personas = "No se puede agregar un Imprevisto a las Siguientes Personas:\n";
                    int i = 0;
                    List<string> idfaltas = new List<string>();
                    foreach (sp_PersonalporCalendarioResult temp in impr.listader)
                    {
                        if (asistencia.ContarAsistenciaPersonal(temp.CEDULA, imp.FechaInicio, idcalendario) != 0)
                        {
                            personas += "* " + temp.NOMBRE + " " + temp.APELLIDO + "\n";
                            i++;
                        }
                        else if (faltas.ContarFaltaPersonalDia(temp.CEDULA, imp.FechaInicio, idcalendario) != 0)
                        {
                            var faltjustificadas = (from lt in faltas.ListarFaltasPersonalDia(idcalendario, imp.FechaInicio)
                                                    where lt.CEDULA == temp.CEDULA && lt.JUSTIFICACION == false
                                                    select lt.IDFALTA).ToList();
                            if (faltjustificadas.Count > 0)
                                idfaltas.Add(faltjustificadas[0].ToString());
                        }
                    }

                    if (idfaltas.Count > 0)
                    {
                        DialogResult dialogResult = MessageBoxEx.Show("Existe Personal con Falta Injustificada ese Día\nDeseea Justificar Dicha Falta\nSi Selecciona NO será Excluida del Imprevisto", "Administración de Imprevistos", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            foreach (string temp in idfaltas)
                            {
                                Faltas f = new Faltas();
                                f.IdFaltas = temp;
                                f.Justificacion = true;
                                faltas.ModificarFaltasJustificacion(f);
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                            impr.listader.RemoveAll(x => faltas.ContarFaltaPersonalDia(x.CEDULA, imp.FechaInicio, idcalendario) != 0);
                        }
                    }
                    impr.listader.RemoveAll(x => asistencia.ContarAsistenciaPersonal(x.CEDULA, imp.FechaInicio, idcalendario) != 0 || faltas.ContarFaltaPersonalDia(x.CEDULA, imp.FechaInicio, idcalendario) != 0);
                    personas += "Debido a que poseen Faltas o Asistencias ese Dia";
                    if (impr.listader.Count > 0)
                    {
                        var calend = (from lt in calendario.ListarCalendario()
                                      where lt.IDCALENDARIO == idcalendario
                                      select lt).ToList();
                        if (imp.FechaInicio >= calend[0].FECHAINICIO && imp.FechaFinal < calend[0].FECHAFIN)
                        {
                            var imprev = (from lt in imprevisto.ListarImprevistoporCalendario(idcalendario) 
                                         where lt.FECHA.Value.Day==imp.FechaInicio.Day && lt.FECHA.Value.Month==imp.FechaInicio.Month && lt.FECHA.Value.Year==imp.FechaInicio.Year
                                         select lt).Count();
                            if (imprev == 0)
                            {
                                if (imp.FechaInicio <= imp.FechaFinal)
                                {
                                    imprevisto.ModificarImprevisto(imp);
                                    calendario.EliminarDetallePersonal(idcalendario, imp.IdImprevisto);
                                    calendario.IngresarPersonalDet(impr.listader, idcalendario, imp.IdImprevisto);
                                    if (i != 0)
                                        MessageBoxEx.Show(personas);
                                }
                                else 
                                {
                                    MessageBoxEx.Show("La Hora de Entrada debe ser Menor que la Hora de Salida");
                                }
                            }
                            else 
                            {
                                MessageBoxEx.Show(this,"Ya Existe un Imprevisto en esa Fecha","Administración de Imprevistos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show(this, "La Fecha Establecida no esta en el Rango del Calendario", "Administrar Faltas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        } 
                    }
                    else
                        MessageBoxEx.Show("No se pudo agregar el Imprevisto\nRevise la Administracion de Faltas e Asistencia");
                    MostrarImprevistos(idcalendario);
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0) 
            {
                DialogResult dialogResult = MessageBoxEx.Show("Deseea Eliminar el Imprevisto\n", "Administración de Imprevistos", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    calendario.EliminarDetallePersonal(idcalendario, dataGridViewX1.CurrentRow.Cells[0].Value.ToString());
                    imprevisto.EliminarImprevisto(dataGridViewX1.CurrentRow.Cells[0].Value.ToString());
                    MostrarImprevistos(idcalendario);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return;
                }
                
            }
        }
    }
}