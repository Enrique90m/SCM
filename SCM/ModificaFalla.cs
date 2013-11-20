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
        DataGridViewRow row = new DataGridViewRow();
        public ModificaFalla(DataGridViewRow row1)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            row = row1;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numComputadoraTextBox.Text) || string.IsNullOrEmpty(descripcionFallaTextBox.Text))
            {
                MessageBox.Show("Debe de capturar el numero de computadora y descripcion antes de actualizar", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Falla falla = new Falla();
            falla.NumComputadora = numComputadoraTextBox.Text;
            falla.descripcionFalla = descripcionFallaTextBox.Text;
            falla.numFalla = int.Parse(numFallaTextBox.Text);
            
            if (solucionadaCheckBox.Checked == true)
                falla.Solucionada = true;
            else
                falla.Solucionada = false;

            if (radioButton1.Checked == true)
                falla.categoria = "Hardware";
            else
                falla.categoria = "Software";

            FallasDAL.ActualizaInformacion(falla);
        }       
       

        private void ModificaFalla_Load(object sender, EventArgs e)
        {
            numFallaTextBox.Text = row.Cells[0].Value.ToString();
            numComputadoraTextBox.Text = row.Cells[1].Value.ToString();
            descripcionFallaTextBox.Text = row.Cells[2].Value.ToString();

            if (bool.Parse(row.Cells[5].Value.ToString()) == true)
                solucionadaCheckBox.Checked = true;
            else
                solucionadaCheckBox.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TodasFallas tf = new TodasFallas();
            tf.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numComputadoraTextBox.Text = null;
            descripcionFallaTextBox.Text = null;
            solucionadaCheckBox.Checked = false;
        }
    }
}
