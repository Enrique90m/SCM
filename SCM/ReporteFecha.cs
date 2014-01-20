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
        public string bandera { get; set; }

        public ReporteFecha(DateTime pFecha1, DateTime pFecha2, int flag)
        {
            InitializeComponent();
            fecha1 = pFecha1;
            fecha2 = pFecha2;

            //si bandera = 0 es reporte de fecha a fecha, si no es reporte mensual
            if (flag == 0)
                label1.Text = "REPORTE DE " + fecha1.ToShortDateString() + " A " + fecha2.ToShortDateString();
            else if (flag == 1)
                label1.Text = "REPORTE MENSUAL";
            else
                label1.Text = "REPORTE ANUAL";

        }

        private void ReporteFecha_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdDataSet.BuscaFallaEntreFechas' Puede moverla o quitarla según sea necesario.
            this.BuscaFallaEntreFechasTableAdapter.Fill(this.bdDataSet.BuscaFallaEntreFechas,fecha1, fecha2,bandera);
            //this.seleccionarTodosTableAdapter1.Fill(this.bdDataSet.SeleccionarTodos);

            this.reportViewer1.RefreshReport();
        }

    }
}
