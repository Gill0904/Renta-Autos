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

namespace GUI_V_2
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios user = new Usuarios(1, txtUsuario.Text, txtContrasenia.Text,"");
                if (user.login())
                {
                    if (user.loginAdmin())
                    {
                        Form1 nuevoForm = new Form1(true,txtUsuario.Text,"ADMINISTRADOR");
                        nuevoForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form1 nuevoForm = new Form1(false,txtUsuario.Text,"USUARIO");
                        nuevoForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Nombre y/o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception z)
            {
                MessageBox.Show("" +z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
