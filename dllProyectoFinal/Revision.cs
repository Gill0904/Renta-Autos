using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyectoFinal
{
    class Revision
    {
        string _Conexion;
        public Revision()
        {
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar(int _numeroRevision, string _cambioAceite, string cambioFiltro, string _cambioFrenos)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarRevision", cn);
                cmd.Parameters.Add("@numeroRevision", SqlDbType.Int).Value = _numeroRevision;
                cmd.Parameters.Add("@cambioAceite", SqlDbType.Int).Value = _numeroRevision;


                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }
                cn.Close();
            }
            return resultado;
        }
    }
}
