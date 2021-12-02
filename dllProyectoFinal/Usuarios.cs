using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyectoFinal
{
    class Usuarios
    {
        string _Conexion;
        public Usuarios()
        {
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar(string _nombre, string _contrasena, string _rol)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarUsuario", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = _nombre;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 20).Value = _contrasena;
                cmd.Parameters.Add("@rol", SqlDbType.VarChar, 20).Value = _rol;
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

        public bool login(string _nombre, string _contrasena)
        {
            bool resultado = false;
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT nombre,contrasena FROM Usuarios WHERE nombre='" + _nombre + "' AND contrasena='" + _contrasena + "'", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                cn.Close();
                return resultado;
            }
        }

        public bool loginAdmin(string _nombre)
        {
            bool resultado = false;
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT nombre,contrasena FROM Usuarios WHERE nombre='" + _nombre + "' AND rol='ADMINISTRADOR'", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
                cn.Close();
                return resultado;
            }
        }

        public bool Eliminar(byte _id)
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_EliminarUsuario", cn);
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
