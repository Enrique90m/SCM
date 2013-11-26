using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Data;

namespace SCM
{
    public class Falla
    {
        public long numFalla;
        public string NumComputadora;
        public string descripcionFalla;
        public DateTime fechaAlta;
        public DateTime fechaBaja;
        public bool Solucionada;
        public string categoria;
    }
}
