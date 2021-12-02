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

namespace GUI_V_2.FormUsuarios
{
    public partial class catalogoUsuarios : Form
    {
        byte idUsuario;
        public catalogoUsuarios()
        {
            InitializeComponent();
            Usuarios usuarios = new Usuarios(1,"","","");
            dataGridView1.DataSource = usuarios.ConsultarUsuario();
            
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            nuevoUsuario nuevoUsuario = new nuevoUsuario(dataGridView1);
            nuevoUsuario.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            idUsuario = byte.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios(idUsuario, "","","");
            usuarios.Eliminar();
            dataGridView1.DataSource = usuarios.ConsultarUsuario();
        }
    }
}
