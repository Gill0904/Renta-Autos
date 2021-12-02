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

namespace GUI_V_2.FormVentas
{
    public partial class catalogoVentas : Form
    {
        public catalogoVentas()
        {
            InitializeComponent();
            Coches nuevoCoches = new Coches(1,"","","","",1,"","");
            dataGridView1.DataSource = nuevoCoches.ConsultarCochesVendidos();

        }
    }
}
