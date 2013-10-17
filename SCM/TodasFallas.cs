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
    public partial class TodasFallas : Form
    {
        public TodasFallas()
        {
            InitializeComponent();
        }

        private void TodasFallas_Load(object sender, EventArgs e)
        {
            Falla lb = new Falla();
            DataTable dt = new DataTable();
            lb.obtieneTodasLasFallas(dt);
            dataGridView1.DataSource = dt;
            textBox1.Focus();
        }
    }
}
