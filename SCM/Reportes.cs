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
                DateTime mesAnetior;

                 //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                if (checkBox1.Checked == false &&  checkBox2.Checked == false)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "0";
                    rp2.Show();
                }
                //INCLUYE ELIMINADAS Y SOLUCIONADAS
                else if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "3";
                    rp2.Show();
                }             
                //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                else if (checkBox1.Checked == true)
                {
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp.bandera = "1";
                    rp.Show();                
                }
                //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                else if (checkBox2.Checked == true)
                {                                  
                    mesAnetior = dateTimePicker4.Value.AddDays(-30);
                    ReporteFecha rp2 = new ReporteFecha(mesAnetior, dateTimePicker4.Value, 1);
                    rp2.bandera = "2";
                    rp2.Show();
                }               
            }
            else
                if (fechasGroupBox.Enabled)
                {  

                    //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                    if (checkBox1.Checked == false && checkBox2.Checked == false)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "0";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y SOLUCIONADAS
                    else if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "3";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                    else if (checkBox1.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "1";
                        rp.Show();
                    }
                    //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                    else if (checkBox2.Checked == true)
                    {
                        ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value, 0);
                        rp.bandera = "2";
                        rp.Show();
                    }   
                }
                else
                {                   
                    //NO INCLUYE NI ELIMINADAS NI SOLUCIONADAS
                    if (checkBox1.Checked == false && checkBox2.Checked == false)
                    {
                        ReportesPorNumComp rp = new ReportesPorNumComp();
                        rp.numComp = numComptxtBox.Text;
                        rp.bandera = "0";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y SOLUCIONADAS
                    else if (checkBox1.Checked == true && checkBox2.Checked == true)
                    {
                        ReportesPorNumComp rp = new ReportesPorNumComp();
                        rp.numComp = numComptxtBox.Text;
                        rp.bandera = "3";
                        rp.Show();
                    }
                    //INCLUYE ELIMINADAS Y NO SOLUCIONADAS
                    else if (checkBox1.Checked == true)
                    {
                        ReportesPorNumComp rp = new ReportesPorNumComp();
                        rp.numComp = numComptxtBox.Text;
                        rp.bandera = "1";
                        rp.Show();
                    }
                    //INCLUYE SOLUCIONADAS Y NO ELIMINADAS
                    else if (checkBox2.Checked == true)
                    {
                        ReportesPorNumComp rp = new ReportesPorNumComp();
                        rp.numComp = numComptxtBox.Text;
                        rp.bandera = "2";
                        rp.Show();
                    } 
                }
        }     
        
    }
}
