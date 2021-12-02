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
    public partial class catalogoRevision : Form
    {
        byte idRevision;
        public catalogoRevision()
        {
            InitializeComponent();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            nuevaRevision nuevaRevision = new nuevaRevision(dataGridView1);
            nuevaRevision.ShowDialog();
        }

        private void catalogoRevision_Load(object sender, EventArgs e)
        {
            Revision nuevaRevision = new Revision(1,1,"","","","","","","","");
            dataGridView1.DataSource = nuevaRevision.ConsultarRevisiones();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            idRevision = byte.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Revision nuevaRevision = new Revision(idRevision,1,"","","","","","","","");
            nuevaRevision.Eliminar();
            dataGridView1.DataSource = nuevaRevision.ConsultarRevisiones();
        }
    }
}
