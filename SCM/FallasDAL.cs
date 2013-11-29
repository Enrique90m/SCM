using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCM
{
    public class FallasDAL
    {
        public void AgregaFalla(Falla objetoFalla)
        {
            using (MySqlConnection conn = DataConections.conectaConBD())
            {
                try
                {
                    string query = "INSERT INTO FALLAS VALUES(@numfalla,@numcompu,@desc,@fechaAlta,@fechaBaja,@solucionada,@categoria,@elim)";
                   MySqlCommand comando = new MySqlCommand(query, conn);
                    comando.Parameters.AddWithValue("@numfalla", objetoFalla.numFalla);
                    comando.Parameters.AddWithValue("@numcompu", objetoFalla.NumComputadora);
                    comando.Parameters.AddWithValue("@desc", objetoFalla.descripcionFalla);
                    comando.Parameters.AddWithValue("@fechaAlta", objetoFalla.fechaAlta);
                    comando.Parameters.AddWithValue("@fechaBaja", DBNull.Value);
                    comando.Parameters.AddWithValue("@solucionada", "No");
                    comando.Parameters.AddWithValue("@categoria",objetoFalla.categoria);
                    comando.Parameters.AddWithValue("@elim","No");

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

            using (MySqlConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM FALLAS", conexion);
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
            using (MySqlConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM FALLAS WHERE Solucionada = 'No' AND Eliminada = 'No'", conexion);
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
            using (MySqlConnection conexion = DataConections.conectaConBD())
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(comando, conexion);
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
            using (MySqlConnection conn = DataConections.conectaConBD())
            {
               MySqlCommand comm = new MySqlCommand("UPDATE FALLAS SET NumComputadora=@numcomp, descripcionFalla=@descrip, Solucionada=@sol, Categoria=@cat, FechaBaja=@fbaja WHERE idFalla = @numfalla", conn);
                comm.Parameters.AddWithValue("@numcomp",falla.NumComputadora);
                comm.Parameters.AddWithValue("@descrip",falla.descripcionFalla);
                comm.Parameters.AddWithValue("@sol",falla.Solucionada);
                comm.Parameters.AddWithValue("@numfalla",falla.numFalla);
                comm.Parameters.AddWithValue("@cat",falla.categoria);
                //Verifica si fecha baja contiene null, si es asi manda como argumento null, lo hago asi puesto que DateTime NO hacepta null
                if (falla.fechaBaja != DateTime.MinValue)
                    comm.Parameters.AddWithValue("@fbaja", falla.fechaBaja);
                else
                    comm.Parameters.AddWithValue("@fbaja", DBNull.Value);

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
        public static void EliminaFalla(long numFalla)
        {
            using (MySqlConnection cn = DataConections.conectaConBD())
            {
                string query = @"UPDATE FALLAS SET Eliminada = 'Si' WHERE idFalla = @Numfalla";
               MySqlCommand cm = new MySqlCommand(query,cn);
                cm.Parameters.AddWithValue("@Numfalla",numFalla);
                try
                {
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Falla eliminada correctamente!","", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al borrar la falla por el siguiente error \n\n" + e.ToString() , "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

    }
}
