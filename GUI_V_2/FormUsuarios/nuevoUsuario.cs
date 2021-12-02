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
    public partial class nuevoUsuario : Form
    {
        DataGridView tabla;
        public nuevoUsuario(DataGridView tabla)
        {
            InitializeComponent();
            this.tabla = tabla;
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasenia.Text.Equals(txtContrasenia2.Text))
                {
                    Usuarios usuarios = new Usuarios(1,txtNombre.Text, txtContrasenia.Text, coRol.SelectedItem.ToString());
                    usuarios.Agregar();
                    tabla.DataSource = usuarios.ConsultarUsuario();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña no es igual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception z)
            {
                MessageBox.Show(""+z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
