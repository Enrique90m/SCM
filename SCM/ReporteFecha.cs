using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCM
{
    public partial class ReporteFecha : Form
    {
        public DateTime fecha1, fecha2;
        public ReporteFecha(DateTime pFecha1, DateTime pFecha2, int bandera)
        {
            InitializeComponent();
            fecha1 = pFecha1;
            fecha2 = pFecha2;

            //si bandera = 0 es reporte de fecha a fecha, si no es reporte mensual
            if (bandera == 0)
                label1.Text = "Reporte del   " + fecha1.ToShortDateString() + "    a     " + fecha2.ToShortDateString();
            else
                label1.Text = "Reporte mensual";

        }

        private void ReporteFecha_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdDataSet.BuscaFallaEntreFechas' Puede moverla o quitarla según sea necesario.
            this.BuscaFallaEntreFechasTableAdapter.Fill(this.bdDataSet.BuscaFallaEntreFechas,fecha1, fecha2);          
            

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
