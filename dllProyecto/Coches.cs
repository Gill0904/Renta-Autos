using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dllProyecto
{
    public class Coches
    {
        private byte _id;
        private string _matricula;
        private string _marca;
        private string _modelo;
        private string _color;
        private decimal _precio;
        private string _plazo;
        private string _imagen;
        private string _Conexion;

        public byte Id { get => _id; set => _id = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Color { get => _color; set => _color = value; }
        public decimal Precio { get => _precio; set => _precio = value; }
        public string Plazo { get => _plazo; set => _plazo = value; }
        public string Imagen { get => _imagen; set => _imagen = value; }

        public Coches(byte id, string matricula, string marca, string modelo, string color, decimal precio, string plazo, string imagen)
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
            this.Precio = precio;
            this.Plazo = plazo;
            this.Imagen = imagen;
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCoche", cn);
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = _matricula;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 15).Value = _marca;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 15).Value = _modelo;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = _color;
                cmd.Parameters.Add("@precio", SqlDbType.Money).Value = _precio;
                cmd.Parameters.Add("@imagen", SqlDbType.VarChar).Value = _imagen;


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

        public bool AgregarCocheVendido()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCocheVendidos", cn);
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 15).Value = _matricula;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 15).Value = _marca;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 15).Value = _modelo;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 15).Value = _color;
                cmd.Parameters.Add("@plazo", SqlDbType.VarChar, 15).Value = _plazo;
                cmd.Parameters.Add("@precio", SqlDbType.Money).Value = _precio;
                cmd.Parameters.Add("@fechaVenta", SqlDbType.Date).Value = DateTime.Now;

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

        public bool Eliminar()
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


        public DataTable ConsultarCoches()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from Coches", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }

        public DataTable ConsultarCochesVendidos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from CochesVendidos", cn);
                cn.Open();
                dt.Load(cmd.ExecuteReader());
                cn.Close();
            }
            return dt;
        }


    }
}
