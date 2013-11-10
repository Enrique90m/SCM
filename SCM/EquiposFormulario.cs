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
    public partial class EquiposFormulario : Form
    {
        public EquiposFormulario()
        {
            InitializeComponent();
        }

        private void usarElSistemaComoAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void EquiposFormulario_Load(object sender, EventArgs e)
        {

        }

        private void inventarioDeEquiposYModificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            tabControl1.SelectTab(1);
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
        }

        private void regresarAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Valida que halla capturado lo basico: NumEquipo y Sala
            if (string.IsNullOrWhiteSpace(numEquipoTextBox.Text) || string.IsNullOrWhiteSpace(salaTextBox.Text))
            {
                MessageBox.Show("Falta capturar datos basicos, minimo se tiene que capturar:\n\n -Numero de equipo \n -Sala", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Ya capturo datos minimos, ahora valida que no halla capturado un NumEquipo que ya exista
            if (EquiposDAL.existe(numEquipoTextBox.Text))
            {
                MessageBox.Show("El Numero de equipo: " + numEquipoTextBox.Text +" ya esta registrado anteriormente y debe ser unico, porfavor verifique sus datos","Eror de duplicacion",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                return;
            }
            
            //Ya se valido que capture todo y no exista duplicado, ahora llena los campos y lo agrega
            Equipos Equipo = new Equipos();
            Equipo.NumEquipo = numEquipoTextBox.Text;
            Equipo.Marca = marcaTextBox.Text;
            Equipo.NumSerie = numSerieTextBox.Text;
            Equipo.sala = salaTextBox.Text;

            int resultado = EquiposDAL.AgregarEquipo(Equipo);
            if (resultado > 0)
            {
                MessageBox.Show("Equipo " + numEquipoTextBox.Text + " guardado correctamente", "Equipo registrado", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el registro","Error de base de datos",MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
        }
       
    }
}
