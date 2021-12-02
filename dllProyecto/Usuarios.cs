using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyecto
{
    public class Usuarios
    {
        private byte _id;
        private string _nombre;
        private string _contrasenia;
        private string _rol;
        private string _Conexion;

        public byte Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Contrasenia { get => _contrasenia; set => _contrasenia = value; }
        public string Rol { get => _rol; set => _rol = value; }

        public Usuarios(byte id, string nombre, string contrasenia, string rol)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Contrasenia = contrasenia;
            this.Rol = rol;
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarUsuario", cn);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 20).Value = _nombre;
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 20).Value = _contrasenia;
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

        public bool login()
        {
            bool resultado = false;
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT nombre,contrasena FROM Usuarios WHERE nombre='" + _nombre + "' AND contrasena='" + _contrasenia + "'", cn);
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

        public bool loginAdmin()
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

        public bool Eliminar()
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

        public DataTable ConsultarUsuario()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from Usuarios", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }
    }
}
