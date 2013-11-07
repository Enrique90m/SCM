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
    public partial class Fallas : Form
    {
        public Fallas()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarFalla falla = new AgregarFalla();
            falla.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TodasFallas tf = new TodasFallas();
            tf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ModificaFalla mf = new ModificaFalla();
            //mf.Show();
        }
    }
}
