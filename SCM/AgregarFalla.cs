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
    public partial class AgregarFalla : Form
    {
        public AgregarFalla()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Falla objetoFalla = new Falla();
            FallasDAL dl = new FallasDAL();
            objetoFalla.numFalla = dl.obtieneTotalDeFallas() + 1;
            objetoFalla.NumComputadora = txtNumEqui.Text;
            objetoFalla.descripcionFalla = txtDescripFalla.Text;
            objetoFalla.fechaAlta = DateTime.Today.Date;
          
             dl.AgregaFalla(objetoFalla);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }
        
    }
}
