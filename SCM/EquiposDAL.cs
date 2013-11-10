using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

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
                comm.Parameters.Add("NumEquipo",pNumEquipo);               
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
                cm.Parameters.Add("NumEquipo", oEquipo.NumEquipo);
                cm.Parameters.Add("Marca",oEquipo.Marca);
                cm.Parameters.Add("NumSerie",oEquipo.NumSerie);
                cm.Parameters.Add("Sala",oEquipo.sala);

                int resultado = cm.ExecuteNonQuery();
                return resultado;
            }
        }
    }
}
