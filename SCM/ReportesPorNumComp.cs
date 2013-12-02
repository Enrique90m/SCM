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
    public partial class ReportesPorNumComp : Form
    {
        public string numComp { get; set; }
        public string bandera { get; set; }
      
        public ReportesPorNumComp()
        {
            InitializeComponent();
        }

        private void ReportesPorNumComp_Load(object sender, EventArgs e)
        {    
            // TODO: esta línea de código carga datos en la tabla 'bdDataSet.BuscaFallaPorNumComp' Puede moverla o quitarla según sea necesario.
            this.BuscaFallaPorNumCompTableAdapter.Fill(this.bdDataSet.BuscaFallaPorNumComp, numComp, bandera);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
