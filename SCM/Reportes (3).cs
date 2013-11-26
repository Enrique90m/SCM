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
            this.Validate();
            this.fALLASBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDDataSet1);

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDDataSet1.FALLAS' table. You can move, or remove it, as needed.
            this.fALLASTableAdapter.Fill(this.bDDataSet1.FALLAS);

        }
    }
}
