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
    public partial class cotizalo : Form
    {
        string _id,_matricula, _marca, _modelo, _color, _precio, _imagen;
        decimal _precioFinal;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string plazo = rbContado.Checked ? "contado" : rb12Meses.Checked ? "12 Mesas" : rb24Mesas.Checked ? "24 Meses" : rb36Meses.Checked ? "36 Meses" : rb48Meses.Checked ? "48 Meses" : "";
                Coches coches = new Coches(1,_matricula, _marca, _modelo, comboBox1.SelectedItem.ToString(), decimal.Parse(lblPrecioFinal.Text), plazo,"");
                coches.AgregarCocheVendido();
                this.Close();
            }
            catch (Exception z)
            {
                MessageBox.Show("" + z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public cotizalo(string id,string matricula, string marca, string modelo, string precio, string imagen)
        {
            InitializeComponent();
            _id = id;
            _matricula = matricula;
            _marca = marca;
            _modelo = modelo;
            _color = "";
            _precioFinal = decimal.Parse(precio);
            _imagen = imagen;

            lblId.Text = id;
            lblMarca.Text = marca;
            lblModelo.Text = modelo;
            lblPrecioFinal.Text = precio;

            lblImagenCoche.Image = Image.FromFile(@"" + imagen);

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox r = sender as CheckBox;
            if (r.Checked)
            {
                lblImagenAcce.Image = Image.FromFile(@"imagenes/cubreAsientos.jpg");
                _precioFinal += 600;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) + 600);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
            else
            {
                _precioFinal -= 600;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) - 600);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox r = sender as CheckBox;
            if (r.Checked)
            {
                lblImagenAcce.Image = Image.FromFile(@"imagenes/rinesDeportivos.jpg");
                _precioFinal += 100;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) + 100);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
            else
            {
                _precioFinal -= 100;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) - 100);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox r = sender as CheckBox;
            if (r.Checked)
            {
                lblImagenAcce.Image = Image.FromFile(@"imagenes/focosLed.jpg");
                _precioFinal += 200;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) + 200);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
            else
            {
                _precioFinal -= 200;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) - 200);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox r = sender as CheckBox;
            if (r.Checked)
            {
                lblImagenAcce.Image = Image.FromFile(@"imagenes/equipoSonido.jpg");
                _precioFinal += 300;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) + 300);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
            else
            {
                _precioFinal -= 300;
                txtCostoExtra.Text = "" + (int.Parse(txtCostoExtra.Text) - 300);
                lblPrecioFinal.Text = "" + _precioFinal;
            }
        }

       

        
    }
}
