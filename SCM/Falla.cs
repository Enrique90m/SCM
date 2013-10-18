using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Data;

namespace SCM
{
    class Falla
    {
        public long numFalla;
        public string NumComputadora;
        public string descripcionFalla;
        public DateTime fechaAlta;
        public DateTime fechaBaja;

        public void AgregaFalla(Falla objetoFalla)
        {

            DataConections bd = new DataConections();
            SqlCeConnection conexion = bd.conectaConBD();
            try
            {
                string query = "INSERT INTO FALLAS VALUES(@numfalla,@numcompu,@desc,@fechaAlta,@fechaBaja)";
                SqlCeCommand comando = new SqlCeCommand(query, conexion);
                comando.Parameters.AddWithValue("@numfalla", objetoFalla.numFalla);
                comando.Parameters.AddWithValue("@numcompu", objetoFalla.NumComputadora);
                comando.Parameters.AddWithValue("@desc", objetoFalla.descripcionFalla);
                comando.Parameters.AddWithValue("@fechaAlta", objetoFalla.fechaAlta);
                comando.Parameters.AddWithValue("@fechaBaja", DBNull.Value);

                comando.ExecuteNonQuery();
                MessageBox.Show("Falla agregada correctamente!");

            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error durante el proceso de agregar la Falla, no se agrego ningun dato! \n \n " + e.ToString());
                return;
            }
            finally
            {
                conexion.Close();
            }
        }
        public long obtieneTotalDeFallas()
        {
            DataTable dt = new DataTable();
            DataConections bd = new DataConections();
            SqlCeConnection conexion = bd.conectaConBD();
            try
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM FALLAS", conexion);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("", "Error - No se pudo contar el total de Libros \n \n" + e.ToString());
            }
            long totalRegistros = dt.Rows.Count;
            return totalRegistros;
        }
        public DataTable obtieneTodasLasFallas(DataTable dt)
        {
            DataConections bd = new DataConections();
            SqlCeConnection conexion = bd.conectaConBD();
            try
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM FALLAS", conexion);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("", "Error - No se pudo contar el total de Libros \n \n" + e.ToString());
            }
            return dt;
        }
        public DataTable buscaFalla(DataTable dt, string comando)
        {
            DataConections conexion = new DataConections();
            SqlCeConnection cn = conexion.conectaConBD();
            try
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter(comando, cn);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error en el sistema: \n\n + " + e.ToString());
                return dt;
            }
            return dt;
        }
        public string BuscaRegistroDeFalla()
        {
            DataConections dc = new DataConections();
            SqlCeConnection cn = new SqlCeConnection();
            cn = dc.conectaConBD();
            string algo = "";
            return algo;
        }
    }
}
