using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Biblioteca
{
    class ConexionBD
    {
        //OBJETO DE CONEXION
        public SqlCeConnection conexionSQL;
        //RUTA DE LA BASE DE DATOS
        public string path = @"Data Source=C:\SCB\SCB\BDLibros.sdf";
        public DataTable dt;
        public SqlCeDataAdapter da;


        //METODO PARA CONEXTAR CON LA BASE DE DATOS
        public SqlCeConnection conectaConBD()
        {

            conexionSQL = new SqlCeConnection(this.path);
            try
            {
                conexionSQL.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar con la base de datos fisica en el sistema, a continuacion se presenta el error\n" + e.ToString());
                return null;
            }
            return conexionSQL;
        }
    }
}
