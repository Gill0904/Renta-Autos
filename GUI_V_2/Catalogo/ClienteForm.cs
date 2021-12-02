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

namespace GUI_V_2.Catalogo
{
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Clientes clientesN = new Clientes(1,txtNombre.Text, txtApPat.Text, txtApeMat.Text, txtTelefon.Text, txtDireccion.Text, int.Parse(txtCodigoPos.Text));
                clientesN.Agregar();

            }
            catch (Exception z)
            {
                MessageBox.Show(""+z.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
