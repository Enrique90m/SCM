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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void fALLASBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            fechasGroupBox.Enabled = false;
            numCompGroupBox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value,0);
            //rp.Show();            
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            mensualGroupBox.Visible = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            mensualGroupBox.Enabled = true; 
            fechasGroupBox.Enabled = false;      
            numCompGroupBox.Enabled = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            mensualGroupBox.Enabled = false;
            fechasGroupBox.Enabled = true;
            numCompGroupBox.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mensualGroupBox.Enabled = false;
            fechasGroupBox.Enabled = false;
            numCompGroupBox.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (mensualGroupBox.Enabled)
            {
                //calcula el mes  anterior
                DateTime mesAnetior;
                mesAnetior = dateTimePicker4.Value.AddDays(-30);
                ReporteFecha rp = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                rp.Show();
            }
            else
                if (fechasGroupBox.Enabled)
                {
                    ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value,dateTimePicker2.Value,0);
                    rp.Show();
                }
                else
                {
                    ReportesPorNumComp rp = new ReportesPorNumComp();
                    rp.numComp = numComptxtBox.Text;
                    rp.Show();
                }
        }     
        
    }
}
