using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllProyecto
{
    public class Revision
    {
        private byte _id;
        private int _numeroRevision;
        private string _matricula;
        private string _marca;
        private string _modelo;
        private string _cambioAceite;
        private string _cambioFiltro;
        private string _cambioFrenos;
        private string _comentarios;
        private string _estadoRevision;
        private string _Conexion;

        public byte Id { get => _id; set => _id = value; }
        public int NumeroRevision { get => _numeroRevision; set => _numeroRevision = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string CambioAceite { get => _cambioAceite; set => _cambioAceite = value; }
        public string CambioFiltro { get => _cambioFiltro; set => _cambioFiltro = value; }
        public string CambioFrenos { get => _cambioFrenos; set => _cambioFrenos = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
        public string EstadoRevision { get => _estadoRevision; set => _estadoRevision = value; }

        public Revision(byte id, int numeroRevison, string matricula, string marca, string modelo, string cambioAceite, string cambioFiltro, string cambioFrenos,string comentarios,string estadoRevision)
        {
            this.Id = id;
            this.NumeroRevision = numeroRevison;
            this.Matricula = matricula;
            this.Marca = marca;
            this.Modelo = modelo;
            this.CambioAceite = cambioAceite;
            this.CambioFiltro = cambioFiltro;
            this.CambioFrenos = cambioFrenos;
            this.Comentarios = comentarios;
            this.EstadoRevision = estadoRevision;
            _Conexion = Conexion.ConexionWin();
        }

        public bool Agregar()
        {
            bool resultado = false;

            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarRevision", cn);
                cmd.Parameters.Add("@numeroRevision", SqlDbType.Int).Value = _numeroRevision;
                cmd.Parameters.Add("@matricula", SqlDbType.VarChar, 10).Value = _matricula;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar, 10).Value = _marca;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 10).Value = _modelo;
                cmd.Parameters.Add("@cambioAceite", SqlDbType.VarChar, 10).Value = _cambioAceite;
                cmd.Parameters.Add("@cambioFiltro", SqlDbType.VarChar, 10).Value = _cambioFiltro;
                cmd.Parameters.Add("@revisionFrenos", SqlDbType.VarChar, 10).Value = _cambioFrenos;
                cmd.Parameters.Add("@comentarios", SqlDbType.VarChar, 100).Value = _comentarios;
                cmd.Parameters.Add("@estadoRevision", SqlDbType.VarChar, 10).Value = _estadoRevision;

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

        public DataTable ConsultarRevisiones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(_Conexion))
            {
                SqlCommand cmd = new SqlCommand("select * from Revisiones", cn);
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
                SqlCommand cmd = new SqlCommand("usp_EliminarRevision", cn);
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
