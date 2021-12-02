using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyectoFinal
{
    class Conexion
    {
        public static string ConexionWin()
        {
            string cadcon = "Data Source=DESKTOP-EOJMAUC;" + "Initial Catalog=ProyectoFinal;" + "Integrated Security=true";
            return cadcon;
        }
    }
}
