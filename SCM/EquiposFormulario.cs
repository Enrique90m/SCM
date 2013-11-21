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
        string RespNumEquipo;

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

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {       
            //Pone los datos en los txtbox
            numEquipoTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            marcaTextBox1.Text =  dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numSerieTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            salaTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
          
            //Si en dado caso, quiere cambiar el NumEquipo, se respalda en esta variable para poder encontrarlo
            //ya que si no se respalda, nunca lo encontrara al momento de actualizarlo
            RespNumEquipo = numEquipoTextBox1.Text;

            //Cambia de tab
            tabControl1.SelectTab(3);
        }

        private void ActualizarTextbox_Click(object sender, EventArgs e)
        {
            Equipos oEquipo = new Equipos();
            oEquipo.NumEquipo = numEquipoTextBox1.Text;
            oEquipo.sala = salaTextBox1.Text;
            oEquipo.NumSerie = numSerieTextBox1.Text;
            oEquipo.Marca = marcaTextBox1.Text;            
            int error =  EquiposDAL.ActualizarInfoDeEquipo(oEquipo,RespNumEquipo);

            if (error > 0)
            {
                MessageBox.Show("Actualizacion correcta de los datos", "Finalizacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos del equipo: " + numEquipoTextBox1.Text,"Error de base de datos", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            DataTable dt = new DataTable();
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numEquipoTextBox.Text = null;
            salaTextBox.Text = null;
            marcaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }       
       
    }
}
