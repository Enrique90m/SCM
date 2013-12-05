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

        DataTable dt = new DataTable();
        DataView dataView = new DataView();

        private void TodasFallas_Load(object sender, EventArgs e)
        {
            FallasDAL lb = new FallasDAL();         
            lb.obtieneTodasLasFallas(dt);
            dataGridView1.DataSource = dt;
            dataView = dt.DefaultView;
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
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE idFalla = " + textBox1.Text);
                else
                    FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE idFalla = " + textBox1.Text + " AND Solucionada = 0");
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
            FallasDAL.buscaFalla(dt,"SELECT * FROM fallas WHERE Solucionada = 'No' AND Eliminada = 'No'");
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

            //si los 2 estan check, pone todos los datos
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No'");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                return;
            }

            if (checkBox1.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Eliminada = 'No'");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
            }
            else
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada ='No' AND Eliminada = 'No'");
                dataView = dt.DefaultView;
                dataGridView1.DataSource = dt;
            }

          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //si los 2 estan check, pone todos los datos
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si" && dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    else
                        if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (checkBox2.Checked == false && checkBox1.Checked == true)
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Eliminada = 'No'");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGreen;
                return;
            }

            if (checkBox2.Checked == true)
            {              
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No'");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                return;
            }
            else
            {
                FallasDAL.buscaFalla(dt, "SELECT * FROM FALLAS WHERE Solucionada = 'No' AND Eliminada = 'No'");
                dataGridView1.DataSource = dt;
                dataView = dt.DefaultView;
            }
           
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (NumFalla_Radiobtn.Checked)
            {

                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox1.Text + "%'";
                    dataGridView1.DataSource = dataView;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        else
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
                else
                    if (checkBox2.Checked == true)
                    {
                        dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox1.Text + "%'";
                        dataGridView1.DataSource = dataView;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "Si")
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    }
                    else
                    {
                        dataView.RowFilter = "Convert(idFalla, 'System.String')LIKE '" + textBox1.Text + "%'";
                        dataGridView1.DataSource = dataView;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Si")
                                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;    
                    }
            }
                       
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumComp_Radiobtn.Checked)
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            }
            else
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
        }
    }
}
