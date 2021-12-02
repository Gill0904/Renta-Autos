using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyecto
{
    public class Clientes
    {
        #region Propiedades
        private byte _id;
        private string _nombre;
        private string _apepat;
        private string _apemat;
        private string _telefono;
        private string _direccion;
        private int _codigoPostal;
        private string _Conexion;

        public byte Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apepat { get => _apepat; set => _apepat = value; }
        public string Apemat { get => _apemat; set => _apemat = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public int CodigoPostal { get => _codigoPostal; set => _codigoPostal = value; }

        #endregion


        public Clientes(byte id, string nombre, string apepat, string apemat, string telefono, string direccion, int codigoPostal)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apepat = apepat;
            this.Apemat = apemat;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.CodigoPostal = codigoPostal;
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCliente", cn);
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

        public bool Eliminar()
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

        public System.Data.DataTable BuscarxID()
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
