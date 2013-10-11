using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace SCM
{
    class Falla
    {
        public int numFalla;
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
                SqlCeCommand comando = new SqlCeCommand("INSERT INTO FALLAS VALUES('" + objetoFalla.numFalla + "','" + objetoFalla.NumComputadora + "','" + objetoFalla.descripcionFalla + "','" + objetoFalla.fechaAlta + "','" + objetoFalla.fechaBaja + "')", conexion);
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
    }
}
