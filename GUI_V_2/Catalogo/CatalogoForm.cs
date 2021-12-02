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
    public partial class CatalogoForm : Form
    {
        Coches ch;
        public CatalogoForm()
        {
            InitializeComponent();
            ch = new Coches(1,"","","","",0,"","");
            llenarCatalogo();
        }

        public void llenarCatalogo()
        {
            DataTable tablaCoches = ch.ConsultarCoches();

            foreach (DataRow row in tablaCoches.Rows)
            {
                catalogoAuto auto = new catalogoAuto(row["id"].ToString(), row["matricula"].ToString(), row["marca"].ToString(),
                    row["modelo"].ToString(), row["color"].ToString(), row["precio"].ToString(), row["imagen"].ToString());
                flowLayoutPanel1.Controls.Add(auto);
                
            }
        }
        
    }
}
