using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyectoFinal
{
    class Clientes
    {
        string _Conexion;
        public Clientes()
        {
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar(string _codigo, string _nombre, string _apepat, string _apemat, string _telefono, string _direccion, int _codigoPostal)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCoche", cn);
                cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 15).Value = _codigo;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 15).Value = _nombre;
                cmd.Parameters.Add("@apepat", SqlDbType.VarChar, 15).Value = _apepat;
                cmd.Parameters.Add("@apemat", SqlDbType.VarChar, 15).Value = _apemat;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 15).Value = _telefono;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 15).Value = _direccion;
                cmd.Parameters.Add("@codigoPostal", SqlDbType.Int, 30).Value = _codigoPostal;
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



        public DataTable Consultar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from Clientes", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }

        public bool Eliminar(byte _id)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarCliente", cn);
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

        public System.Data.DataTable BuscarxID(byte _id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_BuscarCliente", cn);
                cmd.Parameters.Add("@ide", SqlDbType.TinyInt).Value = _id;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }
    }
}
