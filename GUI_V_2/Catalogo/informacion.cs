using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2.Catalogo
{
    public partial class informacion : Form
    {
        string _id, _marca, _modelo, _color, _precio, _imagen;
        public informacion(string id, string marca, string modelo, string color, string precio, string imagen)
        {
            InitializeComponent();
            _id = id;
            _marca = marca;
            _modelo = modelo;
            _color = color;
            _precio = precio;
            _imagen = imagen;

            lblId.Text = id;
            lblMarca.Text = marca;
            lblModelo.Text = modelo;
            lblColor.Text = color;
            lblPrecio.Text = precio;

            imagenCoche.Image = Image.FromFile(@"" + imagen);

        }

        private void informacion_Load(object sender, EventArgs e)
        {
           
        }
    }
}
