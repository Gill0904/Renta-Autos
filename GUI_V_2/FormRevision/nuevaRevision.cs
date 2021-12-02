using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllProyecto;

namespace GUI_V_2.FormRevision
{
    public partial class nuevaRevision : Form
    {
        DataGridView tabla;
        public nuevaRevision(DataGridView tabla)
        {
            InitializeComponent();
            this.tabla = tabla;
            
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            try
            {
                string cambioAceite = lblcambioAceiteSi.Checked ? "si" : lblcambioAceiteNO.Checked ? "no" : "no especificado";
                string cambioFiltro = lblCambioFiltroSI.Checked ? "si" : lblCambioFiltroNO.Checked ? "no" : "no especificado";
                string revisionFrenos = lblCambioFiltroSI.Checked ? "si" : lblCambioFiltroNO.Checked ? "no" : "no especificado";
                Revision rv = new Revision(1,int.Parse(txtNumeroRevision.Text), txtMatricula.Text, txtMarca.Text, txtModelo.Text, cambioAceite, cambioFiltro, revisionFrenos, txtComentarios.Text, "INICIADA");
                rv.Agregar();
                tabla.DataSource = rv.ConsultarRevisiones();
                this.Close();
            }
            catch (Exception z)
            {
                MessageBox.Show(""+z.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
