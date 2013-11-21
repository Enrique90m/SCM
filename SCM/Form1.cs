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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fallas falla = new Fallas();
            falla.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modulo en desarrollo", "Mensaje de SCRF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Reportes rp = new Reportes();
            //rp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EquiposFormulario ef = new EquiposFormulario();
            ef.Show();
            this.Hide();
        }
    }
}
