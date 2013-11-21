﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;


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
            numEquipoTextBox.Focus();
        }

        private void EquiposFormulario_Load(object sender, EventArgs e)
        {
           

        }

        private void inventarioDeEquiposYModificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            tabControl1.SelectTab(1);
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
            datoABuscar.Focus();
        }

        private void regresarAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
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
            numEquipoTextBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numEquipoTextBox.Text = null;
            salaTextBox.Text = null;
            marcaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void ActualizarTextbox_Click_1(object sender, EventArgs e)
        {
            //Valida que halla capturado lo basico: NumEquipo y Sala
            if (string.IsNullOrWhiteSpace(numEquipoTextBox1.Text) || string.IsNullOrWhiteSpace(salaTextBox1.Text))
            {
                MessageBox.Show("Falta capturar datos basicos, minimo se tiene que capturar:\n\n -Numero de equipo \n -Sala", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Si cambio el numEquipo original, verifica si el nuevo que ingreso ya existe, si es asi, tiene que cambiar el actual
            if (numEquipoTextBox1.Text != RespNumEquipo)
            {
                bool existe = EquiposDAL.existe(numEquipoTextBox1.Text);
                if (existe == true)
                {
                    MessageBox.Show("El Numero de equipo: " + numEquipoTextBox1.Text + " ya esta registrado en el sistema, modifiquelo e intentelo de nuevo","Error de duplicado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }

            Equipos oEquipo = new Equipos();
            oEquipo.NumEquipo = numEquipoTextBox1.Text;
            oEquipo.sala = salaTextBox1.Text;
            oEquipo.NumSerie = numSerieTextBox1.Text;
            oEquipo.Marca = marcaTextBox1.Text;
            int error = EquiposDAL.ActualizarInfoDeEquipo(oEquipo, RespNumEquipo);

            if (error > 0)
            {
                MessageBox.Show("Actualizacion correcta de los datos", "Finalizacion de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar los datos del equipo: " + numEquipoTextBox1.Text, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DataTable dt = new DataTable();
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                MessageBox.Show("El Numero de equipo: " + numEquipoTextBox.Text + " ya esta registrado anteriormente y debe ser unico, porfavor verifique sus datos", "Eror de duplicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                MessageBox.Show("Hubo un error al guardar el registro", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            numEquipoTextBox.Text = null;
            marcaTextBox.Text = null;
            salaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numEquipoTextBox.Text = null;
            marcaTextBox.Text = null;
            salaTextBox.Text = null;
            numSerieTextBox.Text = null;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            numEquipoTextBox1.Text = null;
            marcaTextBox1.Text = null;
            salaTextBox1.Text = null;
            numSerieTextBox1.Text = null;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (NumEquipo_Radiobtn.Checked == true)            
                dataGridView1.DataSource = EquiposDAL.buscaEquipo(dt,"SELECT * FROM EQUIPOS WHERE NumEquipo = '" + datoABuscar.Text+"'");
            else
                dataGridView1.DataSource = EquiposDAL.buscaEquipo(dt, "SELECT * FROM EQUIPOS WHERE Sala = '" + datoABuscar.Text+"'");
            
        }

        private void verTodos_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView1.DataSource = EquiposDAL.buscaEquipo(dt,"SELECT * FROM EQUIPOS");
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void Eiminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro de que desea eliminar el equipo numero " +  RespNumEquipo+"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (respuesta.Equals(DialogResult.No))
                return;

            EquiposDAL.EliminaEquipo(RespNumEquipo);
            DataTable dt = new DataTable();
            tabControl1.SelectTab(1);
            dataGridView1.DataSource = EquiposDAL.MostrarTodosLosEquipos(dt);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Valida que tenga datos minimos
            if (string.IsNullOrEmpty(numEquipoTextBox1.Text) || string.IsNullOrEmpty(salaTextBox1.Text))
            {
                MessageBox.Show("Debe de capturar el numero de computadora y sala antes de enviar el correo", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //envia correo    
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Credentials = new System.Net.NetworkCredential("enrique.19m@gmail.com", "elkike_9");
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.EnableSsl = true;

            try
            {
                mail.From = new MailAddress("enrique.19m@gmail.com", "SCRF - Registro de equipo " + numEquipoTextBox1.Text, System.Text.Encoding.UTF8);
                mail.To.Add("enrique_90m@hotmail.com");
                mail.Subject = "Notificacion de actualizacion de falla";
                mail.Body = " <div align=\"center\" style=\"border:2px solid blue\"><h2>Nuevo equipo en el sistema</h2></div></br></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de equipo: </b> " + numEquipoTextBox1.Text + "</h3></div></br>";
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de sala: </b>" + salaTextBox1.Text + "</h3></div></br>";
               
                if(!string.IsNullOrWhiteSpace(numSerieTextBox.Text))
                mail.Body += "<div aling=\"left\"> <h3><b> Numero de serie: </b> " + numSerieTextBox1.Text + "</h3></div></br>";

                if (!string.IsNullOrWhiteSpace(marcaTextBox1.Text))
                    mail.Body += "<div aling=\"left\"> <h3><b> Marca: </b> " +marcaTextBox1.Text + "</h3></div></br>";               

                mail.IsBodyHtml = true;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo enviar correo electronico , le presentamos algunas sugerencias y probables motivos de falla :\n \n-Verifique que tenga conexion a internet \n-Actualize el certificado de la pagina ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Correo enviado correctamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void regresarButtom_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contactenosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe ab = new AcercaDe();
            ab.Show();
        }

    }
}
