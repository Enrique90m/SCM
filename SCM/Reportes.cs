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
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteFecha rp = new ReporteFecha(dateTimePicker1.Value, dateTimePicker2.Value,0);
            rp.Show();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //calcula el mes 
            DateTime mesAnetior;
            mesAnetior = dateTimePicker4.Value.AddDays(-30);
            ReporteFecha rp = new ReporteFecha(mesAnetior, dateTimePicker4.Value,1);
            rp.Show();
        }
    }
}
