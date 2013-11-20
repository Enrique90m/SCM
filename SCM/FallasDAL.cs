using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace SCM
{
    public class FallasDAL
    {
        public void AgregaFalla(Falla objetoFalla)
        {
            using (SqlCeConnection conn = DataConections.conectaConBD())
            {
                try
                {
                    string query = "INSERT INTO FALLAS VALUES(@numfalla,@numcompu,@desc,@fechaAlta,@fechaBaja,@solucionada,@categoria)";
                    SqlCeCommand comando = new SqlCeCommand(query, conn);
                    comando.Parameters.AddWithValue("@numfalla", objetoFalla.numFalla);
                    comando.Parameters.AddWithValue("@numcompu", objetoFalla.NumComputadora);
                    comando.Parameters.AddWithValue("@desc", objetoFalla.descripcionFalla);
                    comando.Parameters.AddWithValue("@fechaAlta", objetoFalla.fechaAlta);
                    comando.Parameters.AddWithValue("@fechaBaja", DBNull.Value);
                    comando.Parameters.AddWithValue("@solucionada", 0);
                    comando.Parameters.AddWithValue("@categoria",objetoFalla.categoria);

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
                    conn.Close();
                }
            }
        }
        public long obtieneTotalDeFallas()
        {
            DataTable dt = new DataTable();

            using (SqlCeConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM FALLAS", conexion);
                    da.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show("", "Error - No se pudo contar el total de fallas \n \n" + e.ToString());
                }
                finally
                {
                    conexion.Close();
                }
            }
            long totalRegistros = dt.Rows.Count;
            return totalRegistros;
        }
        public DataTable obtieneTodasLasFallas(DataTable dt)
        {
            DataConections bd = new DataConections();
            using (SqlCeConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM FALLAS WHERE Solucionada = 0", conexion);
                    da.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show("", "Error - No se pudo obtener el inventario del sistema \n \n" + e.ToString());
                }
            }
            return dt;
        }
        public static DataTable buscaFalla(DataTable dt, string comando)
        {
            using (SqlCeConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    SqlCeDataAdapter da = new SqlCeDataAdapter(comando, conexion);
                    da.Fill(dt);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error en el sistema: \n\n + " + e.ToString());
                    return dt;
                }
            }
            return dt;
        }
        public static void ActualizaInformacion(Falla falla)
        {
            using (SqlCeConnection conn = DataConections.conectaConBD())
            {
                SqlCeCommand comm = new SqlCeCommand("UPDATE FALLAS SET NumComputadora=@numcomp, descripcionFalla=@descrip, Solucionada=@sol, Categoria=@cat WHERE NumFalla = @numfalla", conn);
                comm.Parameters.Add("@numcomp",falla.NumComputadora);
                comm.Parameters.Add("@descrip",falla.descripcionFalla);
                comm.Parameters.Add("@sol",falla.Solucionada);
                comm.Parameters.Add("@numfalla",falla.numFalla);
                comm.Parameters.Add("@cat",falla.categoria);

                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Falla actualizada!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al actualizar /n/n/n" + e.ToString());
                }
            }
        }

    }
}
