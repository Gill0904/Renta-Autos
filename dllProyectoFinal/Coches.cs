using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyectoFinal
{
    class Coches
    {
        string _Conexion;
        public Coches()
        {
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar(string _matricula, string _marca, string _modelo, string _color, decimal _precio)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCliente", cn);
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = _matricula;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 15).Value = _marca;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 15).Value = _modelo;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = _color;
                cmd.Parameters.Add("@precio", SqlDbType.Money).Value = _precio;

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

        public bool AgregarCocheVendido(string _matricula, string _marca, string _modelo, string _color, decimal _precio)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCocheVendidos", cn);
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = _matricula;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 15).Value = _marca;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 15).Value = _modelo;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = _color;
                cmd.Parameters.Add("@precio", SqlDbType.Money).Value = _precio;

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

        public bool Eliminar(byte _id)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarCoche", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _id;
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
