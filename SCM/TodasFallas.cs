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
            FallasDAL lb = new FallasDAL();
            DataTable dt = new DataTable();
            lb.obtieneTodasLasFallas(dt);
            dataGridView1.DataSource = dt;
            textBox1.Focus();
            dataGridView1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                MessageBox.Show("No ingreso ningun dato a buscar, porfavor verifique!");
                return;
            }

            FallasDAL lb = new FallasDAL();
            DataTable dt = new DataTable();
            string texto = textBox1.Text;
            if (NumFalla_Radiobtn.Checked)
            {
                try
                {
                    Int32.Parse(textBox1.Text);
                }
                catch
                {
                    MessageBox.Show("Ingreso algun dato que no es un numero, porfavor verifique!");
                    return;
                }
                if (checkBox1.Checked == true)
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumFalla = " + textBox1.Text);
                else
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumFalla = " + textBox1.Text + " AND Solucionada = 0");
            }
            else
                if (checkBox1.Checked == true)
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumComputadora = '" + textBox1.Text + "'");
                else
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumComputadora =  '"+ textBox1.Text + "' AND Solucionada = 0");
                         


            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FallasDAL fl = new FallasDAL();
            DataTable dt = new DataTable();
            if (checkBox1.Checked == true)
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
            else
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 0");
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ModificaFalla mf = new ModificaFalla(row);
            mf.Show();
            this.Dispose();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (checkBox1.Checked == true)
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
            else
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada ='No'");

            dataGridView1.DataSource = dt;
        }

    }
}
