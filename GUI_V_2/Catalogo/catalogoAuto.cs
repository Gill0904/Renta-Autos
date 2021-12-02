using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2.Catalogo
{
    public partial class catalogoAuto : UserControl
    {
        string _id, _matricula,_marca, _modelo, _color, _precio, _imagen;

        private void button1_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente(_id, _matricula, _marca, _modelo, _precio, _imagen);
            formCliente.Show();
        }

        public catalogoAuto(string id, string matricula,string marca, string modelo, string color, string precio, string imagen)
        {
            InitializeComponent();
            _id = id;
            _matricula = matricula;
            _marca = marca;
            _modelo = modelo;
            _color = color;
            _precio = precio;
            _imagen = imagen;

            imagenCoche.Image = Image.FromFile(@"" + imagen);
            lblMarca.Text = marca;
            lblModelo.Text = modelo;
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            informacion info = new informacion(_id,_marca,_modelo,_color,_precio,_imagen);
            info.ShowDialog();
        }
    }
}
