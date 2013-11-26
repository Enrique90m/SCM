using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;

namespace SCM
{
    public class DataConections
    {
        public static SqlCeConnection conectaConBD()
        {
            SqlCeConnection conn = new SqlCeConnection(@"Data Source=|DataDirectory|\BD.sdf");
            try
            {                
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al abrir la base de datos, para mayor especificacion del problema se desglosara el error: \n\n" + e.ToString(),"Error de base de datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MessageBox.Show("Al no tener conexion a la base de datos se saldra del sistema por seguridad de los datos","Error del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            return conn;
        }
    }
}
