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
    public class EquiposDAL
    {
        //Metodo para verificiar si existe un registro con otro NumEquipo igual
        public static bool existe(string pNumEquipo)
        {
            string SqlComand = @"SELECT COUNT(*) 
                               FROM EQUIPOS 
                               WHERE NumEquipo = @NumEquipo";

            using (MySqlConnection cn = DataConections.conectaConBD())
            {
               MySqlCommand comm = new MySqlCommand(SqlComand,cn);
                comm.Parameters.AddWithValue("@NumEquipo",pNumEquipo);               
                int TotalRegistros = Convert.ToInt32(comm.ExecuteScalar());

                if (TotalRegistros > 0)
                    return true;
                else
                    return false;
            }
        }
        public static int AgregarEquipo(Equipos oEquipo)
        {
            string sql = @"INSERT INTO EQUIPOS VALUES(@NumEquipo,@Marca,@NumSerie,@Sala)";

            using (MySqlConnection cn = DataConections.conectaConBD())
            {

               MySqlCommand cm = new MySqlCommand(sql,cn);
                cm.Parameters.AddWithValue("@NumEquipo", oEquipo.NumEquipo);
                cm.Parameters.AddWithValue("@Marca",oEquipo.Marca);
                cm.Parameters.AddWithValue("@NumSerie",oEquipo.NumSerie);
                cm.Parameters.AddWithValue("@Sala",oEquipo.sala);
              
                int resultado = cm.ExecuteNonQuery();
                return resultado;
            }
        }
        public static DataTable MostrarTodosLosEquipos(DataTable dt)
        {
            string query = @"SELECT * FROM EQUIPOS";

            using (MySqlConnection cn = DataConections.conectaConBD())
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show("No se pudo obtener el inventario de los equipos", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }
                return dt;
            }
        }
        public static int ActualizarInfoDeEquipo(Equipos oEquipo, string RespNumEquipo)
        {
            string query = " UPDATE EQUIPOS SET NumEquipo=@ne, Marca=@marca, NumSerie=@ns, Sala=@sala WHERE NumEquipo=@NumeroEquipo";
            int error;

            using (MySqlConnection cn = DataConections.conectaConBD())
            {
               MySqlCommand cm = new MySqlCommand(query, cn);
                cm.Parameters.AddWithValue("@ne", oEquipo.NumEquipo);
                cm.Parameters.AddWithValue("@marca", oEquipo.Marca);
                cm.Parameters.AddWithValue("@ns", oEquipo.NumSerie);
                cm.Parameters.AddWithValue("@sala", oEquipo.sala);
                cm.Parameters.AddWithValue("@NumeroEquipo", RespNumEquipo);

                error = cm.ExecuteNonQuery();
                cn.Close();
            }
                return error;
            
        }
        public static Equipos BuscaDatosEquipo(string pNumEquipo)
        {
            Equipos equipo = new Equipos();
            using (MySqlConnection cnn = DataConections.conectaConBD())
            {
                string query = @" SELECT Marca, NumSerie, Sala FROM EQUIPOS WHERE NumEquipo = @NumEquipo";
               MySqlCommand cm = new MySqlCommand(query,cnn);
                cm.Parameters.AddWithValue("@NumEquipo",pNumEquipo);

                MySqlDataReader rd = cm.ExecuteReader();
                bool EncontroEquipo = false;
               
                while (rd.Read())
                {
                    equipo.Marca = rd.GetString(0);
                    equipo.NumSerie = rd.GetString(1);
                    equipo.sala = rd.GetString(2);
                    EncontroEquipo = true;
                }

                if (EncontroEquipo == false)                
                    MessageBox.Show("No se encontro ningun equipo, verifique sus datos","Error de busqueda de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
                cnn.Close();
                return equipo;
            }
        }
        public static DataTable buscaEquipo(DataTable dt, string comando)
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
        public static void EliminaEquipo(string numEquipo)
        {
            using (MySqlConnection cn = DataConections.conectaConBD())
            {
                string query = @"DELETE FROM EQUIPOS WHERE NumEquipo = @Numeq";
               MySqlCommand cm = new MySqlCommand(query, cn);
                cm.Parameters.AddWithValue("@Numeq", numEquipo);
                try
                {
                    cm.ExecuteNonQuery();
                    MessageBox.Show("Equipo eliminado correctamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al borrar el equipo por el siguiente error: \n\n" + e.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}
