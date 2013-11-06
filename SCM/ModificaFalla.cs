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
    public partial class ModificaFalla : Form
    {
        public ModificaFalla()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string datoAbuscar;
        }

        private void NumFalla_txt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NumFalla_txt.Text) || string.IsNullOrWhiteSpace(NumFalla_txt.Text))
            {
                MessageBox.Show("Debe capturar el numero de falla");
                return;
            }

            Falla ObjetoFalla = new Falla();
        }
    }
}
