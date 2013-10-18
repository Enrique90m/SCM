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
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string datoAbuscar;

            if (string.IsNullOrEmpty(NumComp_txt.Text) || string.IsNullOrWhiteSpace(NumComp_txt.Text))
                return;


        }
    }
}
