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

        private void button1_Click(object sender, EventArgs e)
        {
            Falla lb = new Falla();
            DataTable dt = new DataTable();
            string texto = textBox1.Text;
            if (id_RADIOBUTTON.Checked)
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
                lb.buscalibro(dt, "SELECT * FROM LIBROS WHERE ID_LIBRO = " + textBox1.Text);
            }
            else
                if (libro_RADIOBUTTON.Checked)
                    lb.buscalibro(dt, "SELECT * FROM LIBROS WHERE NOMBRE = '" + textBox1.Text + "'");
                else
                    lb.buscalibro(dt, "SELECT * FROM LIBROS WHERE AUTOR = '" + textBox1.Text + "'");



            dataGridView1.DataSource = dt;
        }

       
    }
}
