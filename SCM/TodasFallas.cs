﻿using System;
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
            if ((string.IsNullOrEmpty(textBox1.Text)) || (string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                MessageBox.Show("No ingreso ningun dato a buscar, porfavor verifique!");
                return;
            }

            Falla lb = new Falla();
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
                lb.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumFalla = " + textBox1.Text);
            }
            else
                    lb.buscaFalla(dt, "SELECT * FROM FALLAS WHERE NumComputadora = " + textBox1.Text);
              
            //else
                  //  lb.buscaFalla(dt, "SELECT * FROM LIBROS WHERE AUTOR = '" + textBox1.Text + "'");



            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Falla fl = new Falla();
            DataTable dt = new DataTable();
            fl.buscaFalla(dt, "SELECT * FROM Fallas");
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fallas fl = new Fallas();
            fl.Show();
            this.Dispose();
        }

       
    }
}
