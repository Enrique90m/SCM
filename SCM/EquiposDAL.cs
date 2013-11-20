﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

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

            using (SqlCeConnection cn = DataConections.conectaConBD())
            {
                SqlCeCommand comm = new SqlCeCommand(SqlComand,cn);
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

            using (SqlCeConnection cn = DataConections.conectaConBD())
            {

                SqlCeCommand cm = new SqlCeCommand(sql,cn);
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

            using (SqlCeConnection cn = DataConections.conectaConBD())
            {
                try
                {
                    SqlCeDataAdapter da = new SqlCeDataAdapter(query, cn);
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

            using (SqlCeConnection cn = DataConections.conectaConBD())
            {
                SqlCeCommand cm = new SqlCeCommand(query, cn);
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
            using (SqlCeConnection cnn = DataConections.conectaConBD())
            {
                string query = @" SELECT Marca, NumSerie, Sala FROM EQUIPOS WHERE NumEquipo = @NumEquipo";
                SqlCeCommand cm = new SqlCeCommand(query,cnn);
                cm.Parameters.AddWithValue("@NumEquipo",pNumEquipo);

                SqlCeDataReader rd = cm.ExecuteReader();
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
    }
}
