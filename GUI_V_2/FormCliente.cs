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
using GUI_V_2.Catalogo;

namespace GUI_V_2
{
    public partial class FormCliente : Form
    {
        string _id, _matricula, _marca, _modelo, _color, _precio, _imagen;
        public FormCliente(string id, string matricula, string marca, string modelo, string precio, string imagen)
        {
            InitializeComponent();
            _id = id;
            _matricula = matricula;
            _marca = marca;
            _modelo = modelo;
            _precio = precio;
            _imagen = imagen;
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            Clientes nuevoCliente = new Clientes(1,txtNombre.Text, txtApePaterno.Text, txtApeMaterno.Text, txtTelefono.Text, txtDireccion.Text, int.Parse(txtCodigoPostal.Text));
            nuevoCliente.Agregar();

            cotizalo cotizalo = new cotizalo(_id,_matricula,_marca,_modelo,_precio,_imagen);
            cotizalo.Show();
            this.Close();
        }
    }
}
