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

            if (radioButton1.Checked)
                objetoFalla.categoria = radioButton1.Text;
            else
                objetoFalla.categoria = radioButton2.Text;
          
             dl.AgregaFalla(objetoFalla);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNumEqui_Leave(object sender, EventArgs e)
        {
            //Verifics que no sea vacio
            if (string.IsNullOrWhiteSpace(this.Text))
                return;

            //No esta vacio, procede a buscar el equipo por el NumEquipo proporcionado
            Equipos equipo = EquiposDAL.BuscaDatosEquipo(txtNumEqui.Text);

            if (string.IsNullOrWhiteSpace(equipo.Marca))
                return;

            marcaTextBox.Text = equipo.Marca;
            numSerieTextBox.Text = equipo.NumSerie;
            salaTextBox.Text = equipo.sala;
            txtDescripFalla.Focus();

        }

       
        
    }
}
