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
            objetoFalla.numFalla = objetoFalla.obtieneTotalDeFallas() + 1;
            objetoFalla.NumComputadora = txtNumEqui.Text;
            objetoFalla.descripcionFalla = txtDescripFalla.Text;
            objetoFalla.fechaAlta = DateTime.Today.Date;
          
            objetoFalla.AgregaFalla(objetoFalla);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }
        
    }
}
